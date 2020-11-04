using System;
using System.Collections.Generic;

namespace Rabani.DistinctProducts.Web.Entities
{
    public partial class StorePickupPoint
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AddressId { get; set; }
        public decimal PickupFee { get; set; }
        public string OpeningHours { get; set; }
        public int DisplayOrder { get; set; }
        public int StoreId { get; set; }
    }
}
