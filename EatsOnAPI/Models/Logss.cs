using System;
using System.Collections.Generic;

namespace EatsOnAPI.Models
{
    public partial class Logss
    {
        public int Id { get; set; }
        public DateTime? Timestamp { get; set; }
        public string? Level { get; set; }
        public string? Message { get; set; }
    }
}
