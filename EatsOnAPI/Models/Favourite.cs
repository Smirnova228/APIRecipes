using System;
using System.Collections.Generic;

namespace EatsOnAPI.Models
{
    public partial class Favourite
    {
        public int NumberFavourite { get; set; }
        public int ArticleDish { get; set; }
        public int IdUser { get; set; }
        public bool? Delete { get; set; }
    }
}
