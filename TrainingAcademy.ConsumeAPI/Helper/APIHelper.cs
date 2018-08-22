using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using TrainingAcademy.ConsumeAPI.Models;

namespace TrainingAcademy.ConsumeAPI.Helper
{
    public class APIHelper<T>
    {
        public async Task<T> GetCourses(string url)
        {
            var result = default(T);
            string baseUrl = ConfigurationManager.AppSettings["baseUrl"];
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                System.Net.Http.HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    JavaScriptSerializer oJS = new JavaScriptSerializer();
                    result = oJS.Deserialize<T>(data);
                    return result;

                }
                return result;
            }
        }
        public async Task<T> ClientPutRequest(string RequestURI, DTOJson dTO)
        {

            var result = default(T);
            string baseUrl = ConfigurationManager.AppSettings["baseUrl"];

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PutAsJsonAsync(RequestURI, dTO);
            //return response;
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                JavaScriptSerializer oJS = new JavaScriptSerializer();
                result = oJS.Deserialize<T>(data);
                return result;
                
            }
            return result;
        }

        public async Task<T> ClientPostRequest(string RequestURI, DTOJson dTO)
        {

            var result = default(T);
            string baseUrl = ConfigurationManager.AppSettings["baseUrl"];

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PostAsJsonAsync(RequestURI, dTO);
            //return response;
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                JavaScriptSerializer oJS = new JavaScriptSerializer();
                result = oJS.Deserialize<T>(data);
                return result;

            }
            return result;
        }

        public async Task<T> ClientDeleteRequest(string RequestURI)
        {
            var result = default(T);
            string baseUrl = ConfigurationManager.AppSettings["baseUrl"];
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            HttpResponseMessage response = client.DeleteAsync(RequestURI).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                JavaScriptSerializer oJS = new JavaScriptSerializer();
                result = oJS.Deserialize<T>(data);
                return result;
            }
            return result;
        }
    }
}
