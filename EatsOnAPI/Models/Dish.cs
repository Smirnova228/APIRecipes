using System;
using System.Collections.Generic;

namespace EatsOnAPI.Models
{
    public partial class Dish
    {

        public int ArticleDish { get; set; }
        public string NameDish { get; set; } = null!;
        public string DescriptionDish { get; set; } = null!;
        public byte[] ImageDish { get; set; } = null!;
        public decimal Coast { get; set; }
        public decimal TimeCook { get; set; }
        public string NameCategory { get; set; } = null!;
        public string NameProperty { get; set; } = null!;
        public bool? Delete { get; set; }
        public string? CuisineTypeID { get; set; }
        public string? MealTimeID { get; set; }
        public string? DietTypeID { get; set; }
        public int Calories {  get; set; }
    }
}
