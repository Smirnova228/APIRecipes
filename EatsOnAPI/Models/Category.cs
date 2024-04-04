using System;
using System.Collections.Generic;

namespace EatsOnAPI.Models
{
    public partial class Category
    {
        public string NameCategory { get; set; } = null!;
        public bool? Delete { get; set; }
    }
}
