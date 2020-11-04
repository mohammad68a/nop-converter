using System;
using System.Collections.Generic;

namespace Rabani.DistinctProducts.Web.Entities
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            DiscountAppliedToManufacturers = new HashSet<DiscountAppliedToManufacturers>();
            ProductManufacturerMapping = new HashSet<ProductManufacturerMapping>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ManufacturerTemplateId { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public int PictureId { get; set; }
        public int PageSize { get; set; }
        public bool AllowCustomersToSelectPageSize { get; set; }
        public string PageSizeOptions { get; set; }
        public string PriceRanges { get; set; }
        public bool SubjectToAcl { get; set; }
        public bool LimitedToStores { get; set; }
        public bool Published { get; set; }
        public bool Deleted { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual ICollection<DiscountAppliedToManufacturers> DiscountAppliedToManufacturers { get; set; }
        public virtual ICollection<ProductManufacturerMapping> ProductManufacturerMapping { get; set; }
    }
}
