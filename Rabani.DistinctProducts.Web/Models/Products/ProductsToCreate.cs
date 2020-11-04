using System.Collections.Generic;
using System.Linq;

namespace Rabani.DistinctProducts.Web.Models.Products
{
    public class ProductsToCreate
    {
        public int MasterProductId { get; set; }
        public string MasterProductNewSku { get; set; }
        public string MasterProductNewName { get; set; }

        public List<ProductNewValue> SpecificProducts { get; set; }

        public int[] SpecificProductIds => SpecificProducts.Select(s => s.ProductId).ToArray();

        public ProductNewValue MasterProduct
        {
            get
            {
                return SpecificProducts.FirstOrDefault(w => w.ProductId == MasterProductId);
            }
        }

        public List<ProductNewValue> SlaveProductIds
        {
            get
            {
                return SpecificProducts.Where(w => w.ProductId != MasterProductId).ToList();
            }
        }
    }
}