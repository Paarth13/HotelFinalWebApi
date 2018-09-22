using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfAllHotelsCassandra
{
    interface IRepository
    {
        List<HotelAttributes> Hotels();
        List<RoomsAttributes> Rooms(string id);
        void UpdateRooms(Bookings item);
    }
}
