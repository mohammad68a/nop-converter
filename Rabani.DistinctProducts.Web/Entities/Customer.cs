using System;
using System.Collections.Generic;

namespace Rabani.DistinctProducts.Web.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            ActivityLog = new HashSet<ActivityLog>();
            BackInStockSubscription = new HashSet<BackInStockSubscription>();
            BlogComment = new HashSet<BlogComment>();
            CustomerAddresses = new HashSet<CustomerAddresses>();
            CustomerCustomerRoleMapping = new HashSet<CustomerCustomerRoleMapping>();
            CustomerPassword = new HashSet<CustomerPassword>();
            ExternalAuthenticationRecord = new HashSet<ExternalAuthenticationRecord>();
            ForumsPost = new HashSet<ForumsPost>();
            ForumsPrivateMessageFromCustomer = new HashSet<ForumsPrivateMessage>();
            ForumsPrivateMessageToCustomer = new HashSet<ForumsPrivateMessage>();
            ForumsSubscription = new HashSet<ForumsSubscription>();
            ForumsTopic = new HashSet<ForumsTopic>();
            Log = new HashSet<Log>();
            NewsComment = new HashSet<NewsComment>();
            Order = new HashSet<Order>();
            PollVotingRecord = new HashSet<PollVotingRecord>();
            ProductReview = new HashSet<ProductReview>();
            ReturnRequest = new HashSet<ReturnRequest>();
            RewardPointsHistory = new HashSet<RewardPointsHistory>();
            ShoppingCartItem = new HashSet<ShoppingCartItem>();
        }

        public int Id { get; set; }
        public Guid CustomerGuid { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string EmailToRevalidate { get; set; }
        public string AdminComment { get; set; }
        public bool IsTaxExempt { get; set; }
        public int AffiliateId { get; set; }
        public int VendorId { get; set; }
        public bool HasShoppingCartItems { get; set; }
        public bool RequireReLogin { get; set; }
        public int FailedLoginAttempts { get; set; }
        public DateTime? CannotLoginUntilDateUtc { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public bool IsSystemAccount { get; set; }
        public string SystemName { get; set; }
        public string LastIpAddress { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? LastLoginDateUtc { get; set; }
        public DateTime LastActivityDateUtc { get; set; }
        public int RegisteredInStoreId { get; set; }
        public int? BillingAddressId { get; set; }
        public int? ShippingAddressId { get; set; }

        public virtual Address BillingAddress { get; set; }
        public virtual Address ShippingAddress { get; set; }
        public virtual ICollection<ActivityLog> ActivityLog { get; set; }
        public virtual ICollection<BackInStockSubscription> BackInStockSubscription { get; set; }
        public virtual ICollection<BlogComment> BlogComment { get; set; }
        public virtual ICollection<CustomerAddresses> CustomerAddresses { get; set; }
        public virtual ICollection<CustomerCustomerRoleMapping> CustomerCustomerRoleMapping { get; set; }
        public virtual ICollection<CustomerPassword> CustomerPassword { get; set; }
        public virtual ICollection<ExternalAuthenticationRecord> ExternalAuthenticationRecord { get; set; }
        public virtual ICollection<ForumsPost> ForumsPost { get; set; }
        public virtual ICollection<ForumsPrivateMessage> ForumsPrivateMessageFromCustomer { get; set; }
        public virtual ICollection<ForumsPrivateMessage> ForumsPrivateMessageToCustomer { get; set; }
        public virtual ICollection<ForumsSubscription> ForumsSubscription { get; set; }
        public virtual ICollection<ForumsTopic> ForumsTopic { get; set; }
        public virtual ICollection<Log> Log { get; set; }
        public virtual ICollection<NewsComment> NewsComment { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<PollVotingRecord> PollVotingRecord { get; set; }
        public virtual ICollection<ProductReview> ProductReview { get; set; }
        public virtual ICollection<ReturnRequest> ReturnRequest { get; set; }
        public virtual ICollection<RewardPointsHistory> RewardPointsHistory { get; set; }
        public virtual ICollection<ShoppingCartItem> ShoppingCartItem { get; set; }
    }
}
