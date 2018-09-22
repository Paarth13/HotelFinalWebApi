using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelsWebApp.Models
{
    public class BookedItem
    {
        public int hotelid { get; set; }
        public string hotelName { get; set; }
        public int numberOfRooms { get; set; }
        public string type { get; set; }
    }
}