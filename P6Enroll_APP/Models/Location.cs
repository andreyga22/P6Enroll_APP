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

        public async Task<bool> modifyLocationAsync(P6Enroll_APP.Models.Location newLocation) {
            try {
                string RouterSufix = string.Format("Locations/{0}", newLocation.Id);
                string URL = Services.WebAPIConnection.ProductionURLPrefix + RouterSufix;

                RestClient client = new RestClient(URL);
                request = new RestRequest(URL, Method.Put);
                request.AddHeader(Services.WebAPIConnection.ApiKeyName, Services.WebAPIConnection.ApiKeyValue);
                //request.AddHeader(ContentType, Services.WebAPIConnection.ApiKeyValue);
                request.AddBody(JsonConvert.SerializeObject(newLocation));

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.OK) {
                    return true;
                } else {

                    return false;
                }
            } catch (Exception ex) {
                string ErrorMsg = ex.Message;
                throw;
            }
        }

        public async Task<bool> insertLocationAsync(P6Enroll_APP.Models.Location newLocation) {
            try {
                string RouterSufix = string.Format("Locations");
                string URL = Services.WebAPIConnection.ProductionURLPrefix + RouterSufix;

                RestClient client = new RestClient(URL);
                request = new RestRequest(URL, Method.Post);
                request.AddHeader(Services.WebAPIConnection.ApiKeyName, Services.WebAPIConnection.ApiKeyValue);
                request.AddBody(JsonConvert.SerializeObject(newLocation));

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.Created) {
                    return true;
                } else {
                    return false;
                }
            } catch (Exception ex) {
                string ErrorMsg = ex.Message;
                throw;
            }
        }
    }
}
