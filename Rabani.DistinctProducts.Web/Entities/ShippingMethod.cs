using System;
using System.Collections.Generic;

namespace Rabani.DistinctProducts.Web.Entities
{
    public partial class ShippingMethod
    {
        public ShippingMethod()
        {
            ShippingMethodRestrictions = new HashSet<ShippingMethodRestrictions>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }

        public virtual ICollection<ShippingMethodRestrictions> ShippingMethodRestrictions { get; set; }
    }
}
