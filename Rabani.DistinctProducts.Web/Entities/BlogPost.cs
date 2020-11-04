using System;
using System.Collections.Generic;

namespace Rabani.DistinctProducts.Web.Entities
{
    public partial class BlogPost
    {
        public BlogPost()
        {
            BlogComment = new HashSet<BlogComment>();
        }

        public int Id { get; set; }
        public int LanguageId { get; set; }
        public bool IncludeInSitemap { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string BodyOverview { get; set; }
        public bool AllowComments { get; set; }
        public string Tags { get; set; }
        public DateTime? StartDateUtc { get; set; }
        public DateTime? EndDateUtc { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public bool LimitedToStores { get; set; }
        public DateTime CreatedOnUtc { get; set; }

        public virtual Language Language { get; set; }
        public virtual ICollection<BlogComment> BlogComment { get; set; }
    }
}
