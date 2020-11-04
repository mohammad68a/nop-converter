using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Rabani.DistinctProducts.Web.Enums;
using Rabani.DistinctProducts.Web.Extensions;
using Rabani.DistinctProducts.Web.Mappings.Factories;
using Rabani.DistinctProducts.Web.Models;
using Rabani.DistinctProducts.Web.Models.Products;
using Rabani.DistinctProducts.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rabani.DistinctProducts.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICsvFileService _csvFileService;
        private readonly IConfiguration _configuration;

        public ProductsController(IProductService productService, ICsvFileService csvFileService, IConfiguration configuration)
        {
            _productService = productService;
            _csvFileService = csvFileService;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpGet, HttpPost]
        public DataSourceResult GetData([DataSourceRequest] DataSourceRequest request)
        {
            return _productService.GetAsNoTracking().Select(product => new ProductItem
            {
                Id = product.Id,
                Price = product.Price,
                ProductName = product.Name,
                ProductCode = product.Sku,
                IsPublish = product.Published,
                Stock = product.StockQuantity,
                QuantityType = product.StockQuantityType.ToString(),
                TypeName = ((ProductType)product.ProductTypeId).GetDisplayName(),
                ImageBase64 = product.ProductPictureMapping.FirstOrDefault().Picture.PictureBinary.BinaryData.BinaryToBase64String(),
            })
            .ToDataSourceResult(request);
        }

        [HttpPost]
        public async Task<IActionResult> Select(int[] productIds)
        {
            var items = await _productService.GetByProductIdsAsync(productIds);
            var model = new List<SelectProduct>();
            items.ForEach(product => model.Add(new SelectProduct
            {
                Id = product.Id,
                Sku = product.Sku,
                Name = product.Name,
            }));
            return PartialView("_Select", model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductsToCreate model)
        {
            if (!model.SpecificProducts?.Any() ?? false)
                return BadRequest("کالایی ارسال نشده است!");

            if (model.MasterProductId <= 0)
                return BadRequest("کالای اصلی مشخص نشده است!");

            var newProductId = await _productService.CloneProductAsync(model.MasterProductId, model.MasterProductNewSku, model.MasterProductNewName);

            await _productService.AddFeaturesToMasterProductAsync(newProductId, model.MasterProductId, model.SpecificProducts);
            
            //var csvList = ProductFactory.GetNewProductMappingsList(newProductId, model.MasterProductId, model.SpecificProducts.Select(s => s.ProductId).ToArray());

            //_csvFileService.CreateFile(csvList, $"{Guid.NewGuid():N}.csv");

            return Ok(new { baseUrl = _configuration.GetValue<string>("AdminPanelUrl"), newProductId });
        }

        [HttpPost]
        public async Task<IActionResult> Confirm(NewProductConfirm model)
        {
            await _productService.UpdateRecoveryProductIdAsync(model.SpecificProductIds, model.NewProductId);

            await _productService.UpdateProductPublishStatusAsync(model.NewProductId, true);

            return Ok();
        }
    }
}