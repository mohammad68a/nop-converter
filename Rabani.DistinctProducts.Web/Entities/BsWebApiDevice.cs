using System;
using System.Collections.Generic;

namespace Rabani.DistinctProducts.Web.Entities
{
    public partial class BsWebApiDevice
    {
        public int Id { get; set; }
        public string DeviceToken { get; set; }
        public int DeviceTypeId { get; set; }
        public int CustomerId { get; set; }
        public string SubscriptionId { get; set; }
        public bool IsRegistered { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
        public int DeviceType { get; set; }
    }
}
