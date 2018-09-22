using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfAllHotelsCassandra
{
    public class Cassandra : IRepository
    {
        public List<HotelAttributes> Hotels()
        {
            List<HotelAttributes> tokens = new List<HotelAttributes>();

            string query = "Select * from hotels.hotel;";
            Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            ISession session = cluster.Connect("hotels");
            var result = session.Execute(query);
            foreach (var row in result)
            {
                HotelAttributes values = new HotelAttributes();
                values.id = row.GetValue<int>("hotelid");
                values.hotelName = row.GetValue<string>("hotelname");
                values.hotelAddress = row.GetValue<string>("hoteladdress");
                values.pincode = row.GetValue<int>("pincode");
                values.rating = row.GetValue<int>("rating");
                tokens.Add(values);

            }
            return tokens;
        }

        public List<RoomsAttributes> Rooms(string id)
        {
            List<RoomsAttributes> tokens = new List<RoomsAttributes>();
            int Id = int.Parse(id);
            string query = "Select * from hotels.rooms where hotelid=" + id + ";";
            Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            ISession session = cluster.Connect("hotels");
            var result = session.Execute(query);
            foreach (var row in result)
            {
                RoomsAttributes values = new RoomsAttributes();
                values.hotelid = row.GetValue<int>("hotelid");
                values.available = row.GetValue<int>("available");
                values.type = row.GetValue<string>("type");
                values.cost = row.GetValue<int>("cost");
                tokens.Add(values);

            }
            return tokens;
        }

        public void UpdateRooms(Bookings item)
        {
            Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            ISession session = cluster.Connect("hotels");
            int availablerooms = 0;
            int noRooms = item.numberOfRooms;
            int id = item.hotelid;


            string query = "SELECT * FROM  hotels.rooms where type= '" + item.type + "' AND hotelid=" + id;
            var res = session.Execute(query);
            foreach (var row in res)
            {
                availablerooms = int.Parse(row.GetValue<int>("available").ToString());


                // Do something with the value
            }
            availablerooms = availablerooms - noRooms;
            query = "Update hotels.rooms Set available =  " + availablerooms + " Where type = '" + item.type + "' AND hotelid=" + id;
            session.Execute(query);
        }



    }
}




