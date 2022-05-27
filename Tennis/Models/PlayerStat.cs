using System;
using System.Collections.Generic;

namespace Tennis
{
    public partial class PlayerStat
    {
        public long Id { get; set; }
        public long? Aces { get; set; }
        public long? DoubleFaults { get; set; }
        public long? Score { get; set; }
        public long? Match { get; set; }
        public long? Player { get; set; }

        public virtual Match? MatchNavigation { get; set; }
        public virtual Player? PlayerNavigation { get; set; }
    }
}
