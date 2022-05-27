using System;
using System.Collections.Generic;

namespace Tennis
{
    public partial class Player
    {
        public Player()
        {
            MatchPlayer1Navigations = new HashSet<Match>();
            MatchPlayer2Navigations = new HashSet<Match>();
            MatchWinnerNavigations = new HashSet<Match>();
            PlayerStats = new HashSet<PlayerStat>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public long? Rank { get; set; }

        public virtual ICollection<Match> MatchPlayer1Navigations { get; set; }
        public virtual ICollection<Match> MatchPlayer2Navigations { get; set; }
        public virtual ICollection<Match> MatchWinnerNavigations { get; set; }
        public virtual ICollection<PlayerStat> PlayerStats { get; set; }
    }
}
