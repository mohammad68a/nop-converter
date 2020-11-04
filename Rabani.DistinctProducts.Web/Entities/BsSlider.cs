using System;
using System.Collections.Generic;

namespace Rabani.DistinctProducts.Web.Entities
{
    public partial class BsSlider
    {
        public int Id { get; set; }
        public int PictureId { get; set; }
        public DateTime? SliderActiveStartDate { get; set; }
        public DateTime? SliderActiveEndDate { get; set; }
        public bool IsProduct { get; set; }
        public int ProdOrCatId { get; set; }
    }
}
