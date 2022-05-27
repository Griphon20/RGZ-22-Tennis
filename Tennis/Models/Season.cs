using System;
using System.Collections.Generic;

namespace Tennis
{
    public partial class Season
    {
        public Season()
        {
            Tourneys = new HashSet<Tourney>();
        }

        public long Id { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Tourney> Tourneys { get; set; }
    }
}
