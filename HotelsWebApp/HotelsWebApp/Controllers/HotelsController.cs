using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelsWebApp.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using static HotelsWebApp.Models.Logger;

namespace HotelsWebApp.Controllers
{
    public class HotelsController : ApiController
    {
        // GET: api/Hotels
        List<Response> Hotels = new List<Response>();
        public async Task<List<Response>> GetHotels()
        {
            LogManager.Instance.WriteLog("In Get Calling Third party service ");
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:64226/HotelProvider.svc/Hotels");
            List<HotelAttributesWcf> content = new List<HotelAttributesWcf>();
            if (response.StatusCode == HttpStatusCode.OK)

            {
                content = await response.Content.ReadAsAsync<List<HotelAttributesWcf>>();
            }
            LogManager.Instance.WriteLog("In Get Calling JSON file for remaining features.");
            string filepath = "C:/Users/pvashisht/source/repos/HotelsWebApp/HotelsWebApp/bin/HotelStatic.JSON";
            string result = string.Empty;
            List<HotelsJSON> HotelList = new List<HotelsJSON>();
            using (StreamReader r = new StreamReader(filepath))
            {
                var json = r.ReadToEnd();
                HotelList = JsonConvert.DeserializeObject<List<HotelsJSON>>(json);

            }
            LogManager.Instance.WriteLog("In Get Forming one hotel objects with all attributes.");
            for (int i = 0; i < content.Count; i++)
            {
                Response obj = new Response();
                obj.id = content[i].id;
                obj.hotelName = content[i].hotelName;
                obj.rating = content[i].rating;
                obj.pincode = content[i].pincode;
                obj.hotelAddress = content[i].hotelAddress;
                obj.HotelAmenities = HotelList[i].HotelAmenities;
                obj.HotelContactNumber = HotelList[i].HotelContactNumber;
                obj.HotelDescription = HotelList[i].HotelDescription;
                obj.HotelPolicy = HotelList[i].HotelPolicy;
                obj.HotelImageURL = HotelList[i].HotelImageURL;
                Hotels.Add(obj);
            }
            return Hotels;
        }

        // GET: api/Hotels/5
        public async Task<List<Rooms>> GetRooms(int id)
        {
            LogManager.Instance.WriteLog("Getting all rooms for a particular hotel.");
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:64226/HotelProvider.svc/Hotels/" + id);
            List<Rooms> content = new List<Rooms>();
            if (response.StatusCode == HttpStatusCode.OK)

            {
                content = await response.Content.ReadAsAsync<List<Rooms>>();
            }
            return content;
        }

        // POST: api/Hotels
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Hotels/5
        public async Task Put(int id, [FromBody]BookedItem item)
        {
            LogManager.Instance.WriteLog("Sending request to third party to update the values.");
            item.hotelid = id;
            string url = "http://localhost:64226/HotelProvider.svc/Hotels/" + id;
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage response = await httpClient.PutAsJsonAsync(url, item);
            LogManager.Instance.WriteLog("Booking done in my sql");
            IRepository db = new SqlDatabase();
            db.bookRooms(item);
        }


        // DELETE: api/Hotels/5
        public void Delete(int id)
        {
        }
    }
}
