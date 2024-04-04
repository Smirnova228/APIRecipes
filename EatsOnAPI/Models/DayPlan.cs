using System;
using System.Collections.Generic;

namespace EatsOnAPI.Models
{
    public partial class DayPlan
    {
        public int NumberPlan { get; set; }
        public DateTime DateEating { get; set; }
        public int CountDish { get; set; }
        public string NamePart { get; set; } = null!;
        public int ArticleDish { get; set; }
        public int IdUser { get; set; }
        public bool? Delete { get; set; }

    }
}
