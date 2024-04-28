using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;

namespace P6Enroll_APP.Models
{
    public class Location {
        public RestRequest? request { get; set; }

        public int Id { get; set; }

        public string IdLocation { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;

        //public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

        public async Task<List<Location>?> GetAllUsersAsync() {
            try {
                string RouterSufix = string.Format("Locations");
                string URL = Services.WebAPIConnection.ProductionURLPrefix + RouterSufix;

                RestClient client = new RestClient(URL);
                request = new RestRequest(URL, Method.Get);
                request.AddHeader(Services.WebAPIConnection.ApiKeyName, Services.WebAPIConnection.ApiKeyValue);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.OK) {
                    var list = JsonConvert.DeserializeObject<List<Location>>(response.Content);
                    return list;
                } else {
                    return null;
                }
            } catch (Exception ex) {
                string ErrorMsg = ex.Message;
                throw;
            }
        }
    }
}
