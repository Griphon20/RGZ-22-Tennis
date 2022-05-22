using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Tennis.Models.Database;

namespace Tennis.Models.StaticTabs
{
    public class MatchTab : StaticTab
    {
        public MatchTab(string h = "", DbSet<Match>? dBS = null) : base(h)
        {
            DBS = dBS;
            DataColumns = new List<string>();
            DataColumns.Add("id");
            DataColumns.Add("winner");
            DataColumns.Add("player1");
            DataColumns.Add("player2");
            DataColumns.Add("Quarter");
        }

        new public DbSet<Match>? DBS { get; set; }
    }
}
