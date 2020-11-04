using System;
using System.Collections.Generic;

namespace Rabani.DistinctProducts.Web.Entities
{
    public partial class GiftCard
    {
        public GiftCard()
        {
            GiftCardUsageHistory = new HashSet<GiftCardUsageHistory>();
        }

        public int Id { get; set; }
        public int? PurchasedWithOrderItemId { get; set; }
        public int GiftCardTypeId { get; set; }
        public decimal Amount { get; set; }
        public bool IsGiftCardActivated { get; set; }
        public string GiftCardCouponCode { get; set; }
        public string RecipientName { get; set; }
        public string RecipientEmail { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string Message { get; set; }
        public bool IsRecipientNotified { get; set; }
        public DateTime CreatedOnUtc { get; set; }

        public virtual OrderItem PurchasedWithOrderItem { get; set; }
        public virtual ICollection<GiftCardUsageHistory> GiftCardUsageHistory { get; set; }
    }
}
