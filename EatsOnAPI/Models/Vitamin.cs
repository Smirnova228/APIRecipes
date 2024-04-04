using System;
using System.Collections.Generic;

namespace EatsOnAPI.Models
{
    public partial class Vitamin
    {
        public string NameVitamin { get; set; } = null!;
        public string UsefulProperties { get; set; } = null!;
        public bool? Delete { get; set; }

    }
}
