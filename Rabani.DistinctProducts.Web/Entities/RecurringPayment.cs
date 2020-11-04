using System;
using System.Collections.Generic;

namespace Rabani.DistinctProducts.Web.Entities
{
    public partial class RecurringPayment
    {
        public RecurringPayment()
        {
            RecurringPaymentHistory = new HashSet<RecurringPaymentHistory>();
        }

        public int Id { get; set; }
        public int CycleLength { get; set; }
        public int CyclePeriodId { get; set; }
        public int TotalCycles { get; set; }
        public DateTime StartDateUtc { get; set; }
        public bool IsActive { get; set; }
        public bool LastPaymentFailed { get; set; }
        public bool Deleted { get; set; }
        public int InitialOrderId { get; set; }
        public DateTime CreatedOnUtc { get; set; }

        public virtual Order InitialOrder { get; set; }
        public virtual ICollection<RecurringPaymentHistory> RecurringPaymentHistory { get; set; }
    }
}
