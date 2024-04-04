using System;
using System.Collections.Generic;

namespace EatsOnAPI.Models
{
    public partial class DishComponent
    {
        public int Number { get; set; }
        public int ArticleDish { get; set; }
        public int NumberComponent { get; set; }
        public bool? Delete { get; set; }

    }
}
