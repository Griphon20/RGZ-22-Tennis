using System;
using System.Collections.Generic;

namespace Tennis
{
    public partial class Quarter
    {
        public Quarter()
        {
            Matches = new HashSet<Match>();
        }

        public long Id { get; set; }
        public long? QtrType { get; set; }
        public long? Tourney { get; set; }

        public virtual Tourney? TourneyNavigation { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
    }
}
