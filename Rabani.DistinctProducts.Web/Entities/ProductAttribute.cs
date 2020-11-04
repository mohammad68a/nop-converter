using System;
using System.Collections.Generic;

namespace Rabani.DistinctProducts.Web.Entities
{
    public partial class ProductAttribute
    {
        public ProductAttribute()
        {
            PredefinedProductAttributeValue = new HashSet<PredefinedProductAttributeValue>();
            ProductProductAttributeMapping = new HashSet<ProductProductAttributeMapping>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PredefinedProductAttributeValue> PredefinedProductAttributeValue { get; set; }
        public virtual ICollection<ProductProductAttributeMapping> ProductProductAttributeMapping { get; set; }
    }
}
