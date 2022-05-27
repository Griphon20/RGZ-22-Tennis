using System;
using System.Collections.Generic;

namespace Tennis
{
    public partial class Tourney
    {
        public Tourney()
        {
            Quarters = new HashSet<Quarter>();
        }

        public long Id { get; set; }
        public string? Place { get; set; }
        public string? Name { get; set; }
        public long? Season { get; set; }

        public virtual Season? SeasonNavigation { get; set; }
        public virtual ICollection<Quarter> Quarters { get; set; }
    }
}
