using System;
using System.Collections.Generic;

namespace EatsOnAPI.Models
{
    public partial class Ingredient
    {
        public string NameIngredient { get; set; } = null!;
        public string Description { get; set; } = null!;
        public byte[] ImageIngredient { get; set; } = null!;
        public string NameVitamin { get; set; } = null!;
        public string NameProperty { get; set; } = null!;
        public bool? Delete { get; set; }

    }
}
