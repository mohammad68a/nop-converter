using System;
using System.Collections.Generic;

namespace Rabani.DistinctProducts.Web.Entities
{
    public partial class PollAnswer
    {
        public PollAnswer()
        {
            PollVotingRecord = new HashSet<PollVotingRecord>();
        }

        public int Id { get; set; }
        public int PollId { get; set; }
        public string Name { get; set; }
        public int NumberOfVotes { get; set; }
        public int DisplayOrder { get; set; }

        public virtual Poll Poll { get; set; }
        public virtual ICollection<PollVotingRecord> PollVotingRecord { get; set; }
    }
}
