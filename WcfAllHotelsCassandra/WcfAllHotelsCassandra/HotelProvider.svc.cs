using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfAllHotelsCassandra
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HotelProvider" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select HotelProvider.svc or HotelProvider.svc.cs at the Solution Explorer and start debugging.
    public class HotelProvider : IHotelService
    {
        public List<HotelAttributes> GetAll()
        {
            IRepository db = new Cassandra();
            List<HotelAttributes> hotelList = new List<HotelAttributes>();
            hotelList = db.Hotels();
            return hotelList;
        }

        public List<RoomsAttributes> GetRooms(string id)
        {
            IRepository db = new Cassandra();
            List<RoomsAttributes> roomsList = new List<RoomsAttributes>();
            roomsList = db.Rooms(id);
            return roomsList;
        }

        public void UpdateRooms(string id, Bookings item)
        {
            IRepository db = new Cassandra();
            db.UpdateRooms(item);

        }
    }
}
