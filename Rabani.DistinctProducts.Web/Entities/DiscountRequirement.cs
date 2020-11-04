using System;
using System.Collections.Generic;

namespace Rabani.DistinctProducts.Web.Entities
{
    public partial class DiscountRequirement
    {
        public DiscountRequirement()
        {
            InverseParent = new HashSet<DiscountRequirement>();
        }

        public int Id { get; set; }
        public int DiscountId { get; set; }
        public string DiscountRequirementRuleSystemName { get; set; }
        public int? ParentId { get; set; }
        public int? InteractionTypeId { get; set; }
        public bool IsGroup { get; set; }

        public virtual Discount Discount { get; set; }
        public virtual DiscountRequirement Parent { get; set; }
        public virtual ICollection<DiscountRequirement> InverseParent { get; set; }
    }
}
