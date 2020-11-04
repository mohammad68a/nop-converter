using System;
using System.Collections.Generic;

namespace Rabani.DistinctProducts.Web.Entities
{
    public partial class StockQuantityHistory
    {
        public int Id { get; set; }
        public float QuantityAdjustment { get; set; }
        public float StockQuantity { get; set; }
        public string Message { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public int ProductId { get; set; }
        public int? CombinationId { get; set; }
        public int? WarehouseId { get; set; }

        public virtual Product Product { get; set; }
    }
}
