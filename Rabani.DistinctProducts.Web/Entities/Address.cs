using System;
using System.Collections.Generic;

namespace Rabani.DistinctProducts.Web.Entities
{
    public partial class Address
    {
        public Address()
        {
            Affiliate = new HashSet<Affiliate>();
            CustomerAddresses = new HashSet<CustomerAddresses>();
            CustomerBillingAddress = new HashSet<Customer>();
            CustomerShippingAddress = new HashSet<Customer>();
            OrderBillingAddress = new HashSet<Order>();
            OrderPickupAddress = new HashSet<Order>();
            OrderShippingAddress = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public int? CountryId { get; set; }
        public int? StateProvinceId { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ZipPostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string CustomAttributes { get; set; }
        public DateTime CreatedOnUtc { get; set; }

        public virtual Country Country { get; set; }
        public virtual StateProvince StateProvince { get; set; }
        public virtual ICollection<Affiliate> Affiliate { get; set; }
        public virtual ICollection<CustomerAddresses> CustomerAddresses { get; set; }
        public virtual ICollection<Customer> CustomerBillingAddress { get; set; }
        public virtual ICollection<Customer> CustomerShippingAddress { get; set; }
        public virtual ICollection<Order> OrderBillingAddress { get; set; }
        public virtual ICollection<Order> OrderPickupAddress { get; set; }
        public virtual ICollection<Order> OrderShippingAddress { get; set; }
    }
}
