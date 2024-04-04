using System;
using System.Collections.Generic;

namespace EatsOnAPI.Models
{
    public partial class User
    {
        public int IdUser { get; set; }
        public string NumberPhone { get; set; } = null!;
        public string Nickname { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Salt { get; set; } = null!;
        public string NameRole { get; set; } = null!;
        public bool? Delete { get; set; }
        public string Image { get; set; } = null!;
    }
}
