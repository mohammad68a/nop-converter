using Kendo.Mvc.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Rabani.DistinctProducts.Web.Constants;
using Rabani.DistinctProducts.Web.Entities;
using Rabani.DistinctProducts.Web.Mappings.Factories;
using Rabani.DistinctProducts.Web.Models;
using Rabani.DistinctProducts.Web.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rabani.DistinctProducts.Web.Services
{
    public interface IProductService
    {
        Task AddFeaturesToMasterProductAsync(int newProductId, int masterProductId, List<ProductNewValue> relatives);
        Task<int> CloneProductAsync(int productId, string newSku, string newName);
        IQueryable<Product> GetAsNoTracking();
        Task<List<Product>> GetByProductIdsAsync(int[] ids);
        Task<List<ProductToConfirm>> GetProductToConfirmsListAsync(Dictionary<int, string> productKeys, string viewPageUrl);
        Task<Product> GetFirstOrDefaultAsync(int id);
        Task<Product> GetFirstOrDefaultWithIncludesAsync(int id);
        Task<Product> GetSingleOrDefaultAsync(string productSku);
        Task UpdateProductPublishStatusAsync(int productId, bool isPublish);
        Task UpdateRecoveryProductIdAsync(int[] specificProductIds, int newProductId, bool isPublish);
    }

    public class ProductService : IProductService, IDisposable
    {
        private readonly RabaniContext _context;
        private readonly IConfiguration _configuration;

        public ProductService(RabaniContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> CloneProductAsync(int productId, string newSku, string newName)
        {
            var productInOneLevel = await GetFirstOrDefaultAsync(productId);

            if (productInOneLevel == null)
                throw new Exception("Product not found!!!");

            var newProduct = ProductFactory.CreateNewProductFromExistedProduct(productInOneLevel, newSku, newName, false);

            ProductFactory.AddFeatures(await GetFirstOrDefaultWithIncludesAsync(productId), ref newProduct);

            _context.Product.Add(newProduct);

            await _context.SaveChangesAsync();

            return newProduct.Id;
        }

        public async Task AddFeaturesToMasterProductAsync(int newProductId, int masterProductId, List<ProductNewValue> relatives)
        {
            int pictureIndex = 0,
                displayIndex = 0;

            //Add new Color attributes
            var colorAttribute = await _context.ProductAttribute.FindAsync(
                _configuration.GetValue<int>("AttributeRecordIds:ColorAttributeId"));

            var newAttributeMapping = new ProductProductAttributeMapping
            {
                DisplayOrder = 0,
                IsRequired = true,
                ProductId = newProductId,
                TextPrompt = colorAttribute.Name,
                ProductAttributeId = colorAttribute.Id,
                AttributeControlTypeId = _configuration.GetValue<int>("AttributeRecordIds:AttributeControlTypeId"),
            };

            _context.ProductProductAttributeMapping.Add(newAttributeMapping);

            await _context.SaveChangesAsync();

            foreach (var relativeProduct in relatives)
            {
                var otherProduct = await GetFirstOrDefaultWithIncludesAsync(relativeProduct.ProductId);
                if (otherProduct == null)
                    continue;

                var prictureId = otherProduct.ProductPictureMapping.OrderByDescending(o => o.DisplayOrder).FirstOrDefault()?.PictureId ?? 0;

                foreach (var pictureMapping in otherProduct.ProductPictureMapping)
                {
                    _context.ProductPictureMapping.Add(new ProductPictureMapping
                    {
                        ProductId = newProductId,
                        DisplayOrder = ++pictureIndex,
                        PictureId = pictureMapping.PictureId,
                    });
                }

                var attributeValue = new ProductAttributeValue
                {
                    PictureId = prictureId,
                    AttributeValueTypeId = 0,
                    DisplayOrder = displayIndex++,
                    Name = relativeProduct.ColorName,
                    ImageSquaresPictureId = prictureId,
                    ProductAttributeMappingId = newAttributeMapping.Id,
                    IsPreSelected = relativeProduct.ProductId == masterProductId,
                };

                _context.ProductAttributeValue.Add(attributeValue);

                await _context.SaveChangesAsync();

                _context.ProductAttributeCombination.Add(new ProductAttributeCombination
                {
                    PictureId = prictureId,
                    ProductId = newProductId,
                    Sku = relativeProduct.SkuCode,
                    OverriddenPrice = otherProduct.Price,
                    StockQuantity = otherProduct.StockQuantity,
                    AttributesXml = $"<Attributes><ProductAttribute ID=\"{newAttributeMapping.Id}\"><ProductAttributeValue><Value>{attributeValue.Id}</Value></ProductAttributeValue></ProductAttribute></Attributes>"
                });
            }

            await _context.SaveChangesAsync();
        }

        public Task<Product> GetFirstOrDefaultWithIncludesAsync(int id)
        {
            return GetAsNoTracking()
                            .Where(w => w.Id == id)
                            .Include(c => c.BackInStockSubscription)
                            .Include(c => c.ProductAttributeCombination)
                            .Include(c => c.ProductManufacturerMapping)
                            .Include(c => c.ProductPictureMapping)
                            .Include(c => c.ProductProductAttributeMapping)
                            .Include(c => c.ProductProductTagMapping)
                            .Include(c => c.ProductReview)
                            .Include(c => c.ProductSpecificationAttributeMapping).ThenInclude(tc => tc.SpecificationAttributeOption)
                            .Include(c => c.ProductWarehouseInventory)
                            .Include(c => c.StockQuantityHistory)
                            .Include(c => c.TierPrice)
                            .FirstOrDefaultAsync();
        }

        public Task<Product> GetFirstOrDefaultAsync(int id)
        {
            return GetAsNoTracking().Where(w => w.Id == id).FirstOrDefaultAsync();
        }

        public IQueryable<Product> GetAsNoTracking() => _context.Product.AsNoTracking().AsQueryable();

        public Task<List<Product>> GetByProductIdsAsync(int[] ids)
        {
            return GetAsNoTracking().Where(w => ids.Contains(w.Id)).ToListAsync();
        }

        public Task<Product> GetSingleOrDefaultAsync(string productSku)
        {
            return GetAsNoTracking().Where(w => w.Sku == productSku).SingleOrDefaultAsync();
        }

        public Task UpdateRecoveryProductIdAsync(int[] specificProductIds, int newProductId, bool isPublish)
        {
            var products = _context.Product
                    .Where(w => specificProductIds.Contains(w.Id))
                    .AsQueryable();

            foreach (var product in products)
            {
                product.Published = isPublish;

                product.RecoveryProductId = newProductId;
            }

            return _context.SaveChangesAsync();
        }

        public async Task UpdateProductPublishStatusAsync(int productId, bool isPublish)
        {
            var product = await _context.Product.FindAsync(productId);

            product.Published = isPublish;

            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductToConfirm>> GetProductToConfirmsListAsync(Dictionary<int, string> productKeys, string viewPageUrl)
        {
            var productIds = productKeys.Select(s => s.Key).ToArray();

            var products = await GetAsNoTracking().Where(w => productIds.Contains(w.Id)).ToListAsync();

            var result = new List<ProductToConfirm>();

            foreach (KeyValuePair<int, string> item in productKeys)
            {
                var product = products.FirstOrDefault(p => p.Id == item.Key);
                if (product == null)
                    continue;

                result.Add(new ProductToConfirm
                {
                    ProductId = item.Key,
                    CsvFileName = item.Value,
                    ProductName = product.Name,
                    ProductPageUrl = viewPageUrl.Replace(AppSettingKeys.IdParam, item.Key.ToString()),
                });
            }

            return result;
        }
    }
}