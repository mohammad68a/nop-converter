using System;
using System.Collections.Generic;

namespace Rabani.DistinctProducts.Web.Entities
{
    public partial class Country
    {
        public Country()
        {
            Address = new HashSet<Address>();
            ShippingMethodRestrictions = new HashSet<ShippingMethodRestrictions>();
            StateProvince = new HashSet<StateProvince>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool AllowsBilling { get; set; }
        public bool AllowsShipping { get; set; }
        public string TwoLetterIsoCode { get; set; }
        public string ThreeLetterIsoCode { get; set; }
        public int NumericIsoCode { get; set; }
        public bool SubjectToVat { get; set; }
        public bool Published { get; set; }
        public int DisplayOrder { get; set; }
        public bool LimitedToStores { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<ShippingMethodRestrictions> ShippingMethodRestrictions { get; set; }
        public virtual ICollection<StateProvince> StateProvince { get; set; }
    }
}
