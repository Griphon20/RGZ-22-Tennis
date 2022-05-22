using System;
using System.Collections.Generic;

namespace Tennis.Models.Database
{
    public partial class Player
    {
        public string Fio { get; set; } = null!;
        public string? TeamName { get; set; }
        public long? Age { get; set; }
        public byte[]? BirthDate { get; set; }
        public string? Position { get; set; }

        public virtual Team? TeamNameNavigation { get; set; }
    }
}
