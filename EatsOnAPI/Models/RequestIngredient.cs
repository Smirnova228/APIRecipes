using System;
using System.Collections.Generic;

namespace EatsOnAPI.Models
{
    public partial class RequestIngredient
    {

        public int IDRequestIngredient { get; set; }
        public string name { get; set; }
        public int count { get; set; }
        public int RequestId { get; set; }
        
    }
}
