using System;
using System.Collections.Generic;

namespace Rabani.DistinctProducts.Web.Entities
{
    public partial class HomePageComponent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Component { get; set; }
        public int Order { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Published { get; set; }
        public string Options { get; set; }
    }
}
