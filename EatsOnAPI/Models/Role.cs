using System;
using System.Collections.Generic;

namespace EatsOnAPI.Models
{
    public partial class Role
    {
        public string NameRole { get; set; } = null!;
        public bool? Delete { get; set; }
    }
}
