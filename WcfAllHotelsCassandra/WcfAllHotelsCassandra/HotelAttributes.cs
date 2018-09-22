using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfAllHotelsCassandra
{
    public class HotelAttributes
    {
        public int id { get; set; }
        public string hotelName { get; set; }
        public string hotelAddress { get; set; }
        public int rating { get; set; }
        public int pincode { get; set; }
    }
}