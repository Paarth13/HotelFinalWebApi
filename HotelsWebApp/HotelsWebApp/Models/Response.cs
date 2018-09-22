using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelsWebApp.Models
{
    public class Response
    {
        public int id { get; set; }
        public string hotelName { get; set; }
        public string hotelAddress { get; set; }
        public int rating { get; set; }
        public int pincode { get; set; }

        public string HotelContactNumber { get; set; }
        public string HotelDescription { get; set; }
        public string HotelAmenities { get; set; }
        public string HotelPolicy { get; set; }
        public List<string> HotelImageURL { get; set; }
    }
}