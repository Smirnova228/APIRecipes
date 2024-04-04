using System;
using System.Collections.Generic;

namespace EatsOnAPI.Models
{
    public partial class Component
    {
        public int NumberComponent { get; set; }
        public int CountComponent { get; set; }
        public string NameComponent { get; set; } = null!;
        public bool? Delete { get; set; }
    }
}
