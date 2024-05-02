using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace P6Enroll_APP.Models {
    public class Student {

        public RestRequest Request { get; set; }

        public int Id { get; set; }

        public string IdStudent { get; set; }

        public string Name { get; set; }

        public string BirthDate { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public async Task<List<Student>?> GetAllUserAsync() {
            try {
                string RouterSufix = string.Format("Students"); // Adjust this according to your API endpoint
                string URL = Services.WebAPIConnection.ProductionURLPrefix + RouterSufix;

                RestClient client = new RestClient(URL);
                Request = new RestRequest(URL, Method.Get);
                Request.AddHeader(Services.WebAPIConnection.ApiKeyName, Services.WebAPIConnection.ApiKeyValue);

                RestResponse response = await client.ExecuteAsync(Request);

                HttpStatusCode statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.OK) {
                    var list = JsonConvert.DeserializeObject<List<Student>>(response.Content);
                    return list;
                } else {
                    return null;
                }
            } catch (Exception ex) {
                string ErrorMsg = ex.Message;
                throw;
            }
        }

        public async Task<bool> InsertStudentAsync(P6Enroll_APP.Models.Student newStudent) {
            try {
                string RouterSufix = string.Format("Students");
                string URL = Services.WebAPIConnection.ProductionURLPrefix + RouterSufix;

                RestClient client = new RestClient(URL);
                Request = new RestRequest(URL, Method.Post);
                Request.AddHeader(Services.WebAPIConnection.ApiKeyName, Services.WebAPIConnection.ApiKeyValue);
                Request.AddBody(JsonConvert.SerializeObject(newStudent));

                RestResponse response = await client.ExecuteAsync(Request);

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

        internal async Task<bool> ModifyStudentAsync(Student newStudent) {
            throw new NotImplementedException();
        }

    }
}
