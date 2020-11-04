using System;
using System.Collections.Generic;

namespace Rabani.DistinctProducts.Web.Entities
{
    public partial class Store
    {
        public Store()
        {
            BlogComment = new HashSet<BlogComment>();
            NewsComment = new HashSet<NewsComment>();
            ProductReview = new HashSet<ProductReview>();
            StoreMapping = new HashSet<StoreMapping>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public bool SslEnabled { get; set; }
        public string Hosts { get; set; }
        public int DefaultLanguageId { get; set; }
        public int DisplayOrder { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPhoneNumber { get; set; }
        public string CompanyVat { get; set; }

        public virtual ICollection<BlogComment> BlogComment { get; set; }
        public virtual ICollection<NewsComment> NewsComment { get; set; }
        public virtual ICollection<ProductReview> ProductReview { get; set; }
        public virtual ICollection<StoreMapping> StoreMapping { get; set; }
    }
}
