using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Tennis.Models.Database;

namespace Tennis.Models.StaticTabs
{
    public class PlayerStatsTab : StaticTab
    {
        public PlayerStatsTab(string h = "", DbSet<PlayerStats>? dBS = null) : base(h)
        {
            DBS = dBS;
            DataColumns = new List<string>();
            DataColumns.Add("MatchName");
            DataColumns.Add("Score");
            DataColumns.Add("TypeOfWin");
            DataColumns.Add("Duration");
            DataColumns.Add("Deletions");
        }

        new public DbSet<PlayerStats>? DBS { get; set; }
    }
}
