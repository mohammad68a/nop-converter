using System;
using System.Collections.Generic;

namespace Rabani.DistinctProducts.Web.Entities
{
    public partial class Language
    {
        public Language()
        {
            BlogPost = new HashSet<BlogPost>();
            LocaleStringResource = new HashSet<LocaleStringResource>();
            LocalizedProperty = new HashSet<LocalizedProperty>();
            News = new HashSet<News>();
            Poll = new HashSet<Poll>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LanguageCulture { get; set; }
        public string UniqueSeoCode { get; set; }
        public string FlagImageFileName { get; set; }
        public bool Rtl { get; set; }
        public bool LimitedToStores { get; set; }
        public int DefaultCurrencyId { get; set; }
        public bool Published { get; set; }
        public int DisplayOrder { get; set; }

        public virtual ICollection<BlogPost> BlogPost { get; set; }
        public virtual ICollection<LocaleStringResource> LocaleStringResource { get; set; }
        public virtual ICollection<LocalizedProperty> LocalizedProperty { get; set; }
        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<Poll> Poll { get; set; }
    }
}
