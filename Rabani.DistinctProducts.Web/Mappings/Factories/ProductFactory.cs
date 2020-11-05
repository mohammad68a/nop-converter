using Rabani.DistinctProducts.Web.Entities;
using Rabani.DistinctProducts.Web.Extensions;
using Rabani.DistinctProducts.Web.Mappings.Models;
using Rabani.DistinctProducts.Web.Models;
using Rabani.DistinctProducts.Web.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rabani.DistinctProducts.Web.Mappings.Factories
{
    public class ProductFactory
    {
        public static List<ChangeIdProductModel> GetNewProductMappingsList(int newId, int mainId, int[] relatedIds)
        {
            var result = new List<ChangeIdProductModel>();
            var all_ids = new List<int> { mainId };
            all_ids.AddRange(relatedIds);
            foreach (var id in all_ids)
            {
                result.Add(new ChangeIdProductModel
                {
                    OldProductId = id,
                    NewProductId = newId,
                });
            }
            return result;
        }

        public static Product CreateNewProductFromExistedProduct(Product product, string sku, string name, bool published = true)
        {
            product.Id = 0;
            product.Sku = sku;
            product.Name = name;
            product.Published = published;
            return product;
        }

        public static void AddFeatures(Product masterProduct, ref Product newProduct)
        {
            // DiscountAppliedToProducts
            AddDiscountAppliedToProducts(newProduct, masterProduct.DiscountAppliedToProducts);

            // ProductPictureMapping
            //AddProductPictureMapping(newProduct, masterProduct.ProductPictureMapping.OrderBy(o => o.DisplayOrder));

            // ProductProductAttributeMapping ** CHECK IT
            //WAddProductProductAttributeMapping(newProduct, masterProduct.ProductProductAttributeMapping);

            // ProductProductTagMapping
            AddProductProductTagMapping(newProduct, masterProduct.ProductProductTagMapping);

            // ProductSpecificationAttributeMapping
            AddProductSpecificationAttributeMapping(newProduct, masterProduct.ProductSpecificationAttributeMapping);

            // StockQuantityHistory
            AddStockQuantityHistory(newProduct, masterProduct.StockQuantityHistory);

            // TierPrice
            AddTierPrice(newProduct, masterProduct.TierPrice);
        }

        public static Dictionary<int, string> GetProductIdAndFileName(string[] fileNames)
        {
            return fileNames
                    .Select(fileName => new KeyValuePair<int, string>(int.Parse(fileName.Split('-')[0]), fileName))
                    .ToDictionary(x => x.Key, x => x.Value);
        }

        private static void AddTierPrice(Product newProduct, ICollection<TierPrice> tierPrice)
        {
            if (tierPrice.Any())
            {
                foreach (var item in tierPrice)
                {
                    newProduct.TierPrice.Add(new TierPrice
                    {
                        Price = item.Price,
                        StoreId = item.StoreId,
                        Quantity = item.Quantity,
                        ProductId = newProduct.Id,
                        CustomerRoleId = item.CustomerRoleId,
                        EndDateTimeUtc = item.EndDateTimeUtc,
                        StartDateTimeUtc = item.StartDateTimeUtc,
                    });
                }
            }
        }

        private static void AddStockQuantityHistory(Product newProduct, ICollection<StockQuantityHistory> stockQuantityHistory)
        {
            if (stockQuantityHistory.Any())
            {
                var nowUtc = DateTime.UtcNow;
                foreach (var item in stockQuantityHistory)
                {
                    newProduct.StockQuantityHistory.Add(new StockQuantityHistory
                    {
                        CreatedOnUtc = nowUtc,
                        Message = item.Message,
                        ProductId = newProduct.Id,
                        WarehouseId = item.WarehouseId,
                        CombinationId = item.CombinationId,
                        QuantityAdjustment = item.QuantityAdjustment,
                        StockQuantity = item.StockQuantity, //**
                    });
                }
            }
        }

        private static void AddProductSpecificationAttributeMapping(Product newProduct, ICollection<ProductSpecificationAttributeMapping> productSpecificationAttributeMappings)
        {
            if (productSpecificationAttributeMappings.Any())
            {
                foreach (var item in productSpecificationAttributeMappings)
                {
                    newProduct.ProductSpecificationAttributeMapping.Add(new ProductSpecificationAttributeMapping
                    {
                        ProductId = newProduct.Id,
                        CustomValue = item.CustomValue,
                        DisplayOrder = item.DisplayOrder,
                        AllowFiltering = item.AllowFiltering,
                        AttributeTypeId = item.AttributeTypeId,
                        ShowOnProductPage = item.ShowOnProductPage,
                        SpecificationAttributeOptionId = item.SpecificationAttributeOptionId,
                    });
                }
            }
        }

        private static void AddProductProductTagMapping(Product newProduct, ICollection<ProductProductTagMapping> productProductTagMappings)
        {
            if (productProductTagMappings.Any())
            {
                foreach (var item in productProductTagMappings)
                {
                    newProduct.ProductProductTagMapping.Add(new ProductProductTagMapping
                    {
                        ProductId = newProduct.Id,
                        ProductTagId = item.ProductTagId,
                    });
                }
            }
        }

        private static void AddProductProductAttributeMapping(Product newProduct, ICollection<ProductProductAttributeMapping> productProductAttributeMapping)
        {
            if (productProductAttributeMapping.Any())
            {
                foreach (var item in productProductAttributeMapping)
                {
                    newProduct.ProductProductAttributeMapping.Add(new ProductProductAttributeMapping
                    {
                        ProductId = newProduct.Id,
                        DisplayOrder = item.DisplayOrder,
                        IsRequired = item.IsRequired,
                        TextPrompt = item.TextPrompt,
                        DefaultValue = item.DefaultValue,
                        ProductAttributeId = item.ProductAttributeId,
                        ProductAttributeValue = item.ProductAttributeValue,
                    });
                }
            }
        }

        private static void AddProductPictureMapping(Product newProduct, IOrderedEnumerable<ProductPictureMapping> productPictureMapping)
        {
            if (productPictureMapping.Any())
            {
                var pictureOrderIndex = 0;
                foreach (ProductPictureMapping item in productPictureMapping)
                {
                    newProduct.ProductPictureMapping.Add(new ProductPictureMapping
                    {
                        ProductId = newProduct.Id,
                        PictureId = item.PictureId,
                        DisplayOrder = pictureOrderIndex++,
                    });
                }
            }
        }

        private static void AddDiscountAppliedToProducts(Product newProduct, ICollection<DiscountAppliedToProducts> discountAppliedToProducts)
        {
            if (discountAppliedToProducts.Any())
            {
                foreach (var item in discountAppliedToProducts)
                {
                    newProduct.DiscountAppliedToProducts.Add(new DiscountAppliedToProducts
                    {
                        ProductId = newProduct.Id,
                        DiscountId = item.DiscountId,
                    });
                    item.ProductId = newProduct.Id;
                }
            }
        }
    }
}