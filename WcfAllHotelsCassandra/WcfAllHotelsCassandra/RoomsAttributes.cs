using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfAllHotelsCassandra
{
    public class RoomsAttributes
    {
        public int hotelid { get; set; }
        public int available { get; set; }
        public int cost { get; set; }
        public string type { get; set; }
    }
}