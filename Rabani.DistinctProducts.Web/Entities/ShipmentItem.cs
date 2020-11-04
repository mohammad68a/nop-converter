using System;
using System.Collections.Generic;

namespace Rabani.DistinctProducts.Web.Entities
{
    public partial class ShipmentItem
    {
        public int Id { get; set; }
        public int ShipmentId { get; set; }
        public int OrderItemId { get; set; }
        public float Quantity { get; set; }
        public int WarehouseId { get; set; }

        public virtual Shipment Shipment { get; set; }
    }
}
