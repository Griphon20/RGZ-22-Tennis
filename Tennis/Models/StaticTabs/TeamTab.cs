using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Tennis.Models.Database;

namespace Tennis.Models.StaticTabs
{
    public class TeamTab : StaticTab
    {
        public TeamTab(string h = "", DbSet<Team>? dBS = null) : base(h)
        {
            DBS = dBS;
            DataColumns = new List<string>(); 
            DataColumns.Add("Name");
            DataColumns.Add("Points");
            DataColumns.Add("Conference");
            DataColumns.Add("Division");
        }

        new public DbSet<Team>? DBS { get; set; }
    }
}
