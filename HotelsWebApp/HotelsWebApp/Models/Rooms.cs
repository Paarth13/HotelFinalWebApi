using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelsWebApp.Models
{
    public class Rooms
    {
        public int hotelid { get; set; }
        public int available { get; set; }
        public int cost { get; set; }
        public string type { get; set; }
    }
}