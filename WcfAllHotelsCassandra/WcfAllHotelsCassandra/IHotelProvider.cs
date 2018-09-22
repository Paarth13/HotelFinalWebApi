using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Services;

namespace WcfAllHotelsCassandra
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHotelProvider" in both code and config file together.
    [ServiceContract]
    public interface IHotelService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/Hotels", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<HotelAttributes> GetAll();

        [OperationContract]
        [WebGet(UriTemplate = "/Hotels/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<RoomsAttributes> GetRooms(string id);

        [OperationContract]

        [WebInvoke(UriTemplate = "/Hotels/{id}", Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void UpdateRooms(string id, Bookings item);

    }


}
