using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Tennis.Models.Database;

namespace Tennis.Models.StaticTabs
{
    public class PlayerTab : StaticTab
    {
        public PlayerTab(string h = "", DbSet<Player>? dBS = null) : base(h)
        {
            DBS = dBS;
            DataColumns = new List<string>();
            DataColumns.Add("id");
            DataColumns.Add("name");
            DataColumns.Add("country");
            DataColumns.Add("runk");
        }

        new public DbSet<Player>? DBS { get; set; }
    }
}
