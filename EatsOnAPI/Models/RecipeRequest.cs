using System;
using System.Collections.Generic;

namespace EatsOnAPI.Models
{
    public partial class RecipeRequest
    {
        public int IdRecipeRequest { get; set; }
        public string NameRecipe { get; set; } = null!;
        public string DescriptionRecipe { get; set; } = null!;
        public string? ImageRecipe { get; set; }
        public decimal Coast { get; set; }
        public int UserId { get; set; }
        public decimal TimeCook { get; set; }
        public string status { get; set; }
    }
}
