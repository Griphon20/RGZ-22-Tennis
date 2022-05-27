using System;
using System.Collections.Generic;

namespace Tennis
{
    public partial class Match
    {
        public Match()
        {
            PlayerStats = new HashSet<PlayerStat>();
        }

        public long Id { get; set; }
        public long? Winner { get; set; }
        public long? Player1 { get; set; }
        public long? Player2 { get; set; }
        public long? Quarter { get; set; }

        public virtual Player? Player1Navigation { get; set; }
        public virtual Player? Player2Navigation { get; set; }
        public virtual Quarter? QuarterNavigation { get; set; }
        public virtual Player? WinnerNavigation { get; set; }
        public virtual ICollection<PlayerStat> PlayerStats { get; set; }
    }
}
