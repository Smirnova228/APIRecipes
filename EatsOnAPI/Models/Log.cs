using System;
using System.Collections.Generic;

namespace EatsOnAPI.Models
{
    public partial class Log
    {
        public int NumberLog { get; set; }
        public string Description { get; set; } = null!;
        public DateTime DateLog { get; set; }
        public int IdUser { get; set; }

    }
}
