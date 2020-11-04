using System;
using System.Collections.Generic;

namespace Rabani.DistinctProducts.Web.Entities
{
    public partial class Discount
    {
        public Discount()
        {
            DiscountAppliedToCategories = new HashSet<DiscountAppliedToCategories>();
            DiscountAppliedToManufacturers = new HashSet<DiscountAppliedToManufacturers>();
            DiscountAppliedToProducts = new HashSet<DiscountAppliedToProducts>();
            DiscountRequirement = new HashSet<DiscountRequirement>();
            DiscountUsageHistory = new HashSet<DiscountUsageHistory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int DiscountTypeId { get; set; }
        public bool UsePercentage { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal? MaximumDiscountAmount { get; set; }
        public DateTime? StartDateUtc { get; set; }
        public DateTime? EndDateUtc { get; set; }
        public bool RequiresCouponCode { get; set; }
        public string CouponCode { get; set; }
        public bool IsCumulative { get; set; }
        public int DiscountLimitationId { get; set; }
        public int LimitationTimes { get; set; }
        public int? MaximumDiscountedQuantity { get; set; }
        public bool AppliedToSubCategories { get; set; }

        public virtual ICollection<DiscountAppliedToCategories> DiscountAppliedToCategories { get; set; }
        public virtual ICollection<DiscountAppliedToManufacturers> DiscountAppliedToManufacturers { get; set; }
        public virtual ICollection<DiscountAppliedToProducts> DiscountAppliedToProducts { get; set; }
        public virtual ICollection<DiscountRequirement> DiscountRequirement { get; set; }
        public virtual ICollection<DiscountUsageHistory> DiscountUsageHistory { get; set; }
    }
}
