using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using RestSharp;


namespace P6Enroll_APP.Models
{
    public class Professor
    {

        public int Id { get; set; }

        public string IdProfessor { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Assignment { get; set; } = null!;

        public RestRequest? request { get; set; }

        

        public async Task<List<Professor>?> GetAllUsersAsync()
        {
            try
            {
                string RouterSufix = string.Format("Professors");
                string URL = Services.WebAPIConnection.ProductionURLPrefix + RouterSufix;

                RestClient client = new RestClient(URL);
                request = new RestRequest(URL, Method.Get);
                request.AddHeader(Services.WebAPIConnection.ApiKeyName, Services.WebAPIConnection.ApiKeyValue);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.OK)
                {
                    var list = JsonConvert.DeserializeObject<List<Professor>>(response.Content);
                    return list;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string ErrorMsg = ex.Message;
                throw;
            }
        }

        public async Task<bool> modifyProfessorAsync(P6Enroll_APP.Models.Professor newProfessor)
        {
            try
            {
                string RouterSufix = string.Format("Professors/{0}", newProfessor.Id);
                string URL = Services.WebAPIConnection.ProductionURLPrefix + RouterSufix;

                RestClient client = new RestClient(URL);
                request = new RestRequest(URL, Method.Put);
                request.AddHeader(Services.WebAPIConnection.ApiKeyName, Services.WebAPIConnection.ApiKeyValue);
                //request.AddHeader(ContentType, Services.WebAPIConnection.ApiKeyValue);
                request.AddBody(JsonConvert.SerializeObject(newProfessor));

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {

                    return false;
                }
            }
            catch (Exception ex)
            {
                string ErrorMsg = ex.Message;
                throw;
            }
        }

        public async Task<bool> insertProfessorAsync(P6Enroll_APP.Models.Professor newProfessor)
        {
            try
            {
                string RouterSufix = string.Format("Professors");
                string URL = Services.WebAPIConnection.ProductionURLPrefix + RouterSufix;

                RestClient client = new RestClient(URL);
                request = new RestRequest(URL, Method.Post);
                request.AddHeader(Services.WebAPIConnection.ApiKeyName, Services.WebAPIConnection.ApiKeyValue);
                request.AddBody(JsonConvert.SerializeObject(newProfessor));

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.Created)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string ErrorMsg = ex.Message;
                throw;
            }
        }






        //Cierre clase public 
    }

}
