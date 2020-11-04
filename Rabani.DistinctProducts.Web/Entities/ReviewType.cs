using System;
using System.Collections.Generic;

namespace Rabani.DistinctProducts.Web.Entities
{
    public partial class ReviewType
    {
        public ReviewType()
        {
            ProductReviewReviewTypeMapping = new HashSet<ProductReviewReviewTypeMapping>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }
        public bool VisibleToAllCustomers { get; set; }
        public bool IsRequired { get; set; }

        public virtual ICollection<ProductReviewReviewTypeMapping> ProductReviewReviewTypeMapping { get; set; }
    }
}
