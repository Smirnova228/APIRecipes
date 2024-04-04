using System;
using System.Collections.Generic;

namespace EatsOnAPI.Models
{
    public partial class Property
    {
        public string NameProperty { get; set; } = null!;
        public string DescriptionProperty { get; set; } = null!;
        public bool? Delete { get; set; }

    }
}
