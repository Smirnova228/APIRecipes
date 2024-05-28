using System;
using System.Collections.Generic;

namespace EatsOnAPI.Models
{
    public partial class Feedback
    {
        public int NumberFeedback { get; set; }
        public decimal Rating { get; set; }
        public DateTime DateFeedback { get; set; }
        public string Advantages { get; set; } = null!;
        public string Disadvantages { get; set; } = null!;
        public int ArticleDish { get; set; }
        public int IdUser { get; set; }
        public bool? Delete { get; set; }
    }
}
