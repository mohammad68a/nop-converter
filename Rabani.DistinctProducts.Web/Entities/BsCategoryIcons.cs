using System;
using System.Collections.Generic;

namespace Rabani.DistinctProducts.Web.Entities
{
    public partial class BsCategoryIcons
    {
        public int Id { get; set; }
        public int SubCategoryId { get; set; }
        public string Extension { get; set; }
    }
}
