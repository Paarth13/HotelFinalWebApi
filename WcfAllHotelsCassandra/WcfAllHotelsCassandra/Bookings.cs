using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfAllHotelsCassandra
{
    public class Bookings
    {
        public int hotelid { get; set; }
        public string hotelName { get; set; }
        public string type { get; set; }
        public int numberOfRooms { get; set; }
    }
}