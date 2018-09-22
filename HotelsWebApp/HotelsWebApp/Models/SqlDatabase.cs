using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HotelsWebApp.Models
{
    public class SqlDatabase : IRepository
    {
        private SqlConnection con;
        private void connection()
        {
            string constr = @"Data Source=TAVDESK026;Initial Catalog=RoomBooking;User Id=sa;Password=test123!@#";
            con = new SqlConnection(constr);

        }
        public void bookRooms(BookedItem item)
        {
            connection();
            con.Open();
            string query = "Insert into Bookings(HotelId,RoomType,NumberOfRooms) values(@hotelid,@type,@NoofRooms)";
            SqlCommand sqlCommand = new SqlCommand(query, con);
           
            sqlCommand.Parameters.Add(new SqlParameter("type", item.type));
            sqlCommand.Parameters.Add(new SqlParameter("hotelid", item.hotelid));
            sqlCommand.Parameters.Add(new SqlParameter("NoofRooms", item.numberOfRooms));
            sqlCommand.ExecuteNonQuery();

            con.Close();
        }
    }
}