using System;
using System.Collections.Generic;

namespace EatsOnAPI.Models
{
    public partial class UserQuestion
    {
        public int IdUserQuestion { get; set; }
        public string Status { get; set; } = null!;
        public string DescriptionQuestion { get; set; } = null!;
        public int UserId { get; set; }
        public string Answer { get; set; }

    }
}
