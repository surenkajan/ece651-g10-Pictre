using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace UoW.Pictre.ServiceUtils
{
    public static class RestClient
    {
        public static string MakeHttpRequest(string endPoint, string method, string contentType, string data)
        {
            string responseBody = null;
            
            if(method.ToUpper().Equals("GET") || method.ToUpper().Equals("POST") 
                || method.ToUpper().Equals("PUT") || method.ToUpper().Equals("DELETE"))
            {
                return null;
            }
            

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(endPoint);
            request.Method = method.ToUpper();

            if (("POST,PUT").Split(',').Contains(method.ToUpper()))
            {
                if (!String.IsNullOrEmpty(contentType))
                {
                    request.ContentType = contentType;
                }

                if (data != null)
                {
                    byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                    request.GetRequestStream().Write(dataBytes, 0, dataBytes.Length);
                    request.GetRequestStream().Close();

                    request.ContentLength = dataBytes.Length;
                }

            }

            HttpWebResponse response;
            try
            {
                using (response = (HttpWebResponse)request.GetResponse())
                {
                    if(response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new WebException("Error code from Pictre: " + response.StatusCode);
                    }
                    //Process response stream can be JSON, XML or HTML ... etc
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        if(responseStream != null)
                        {
                            using (StreamReader reader = new StreamReader(responseStream))
                            {
                                responseBody = reader.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch(WebException e)
            {
                response = (HttpWebResponse)e.Response;
            }
          
            return responseBody;

            //How to Consume this in Pictre Front End: Deserialize the object(s)
            //JsonSerializer jsonSerializer = new JsonSerializer(typeof(PanoramioData));
            //PanoramioData photos = (PanoramioData)jsonSerializer.Deserialze(responseBody.GetResponseStream());
            //var serializedJson = Newtonsoft.Json.JsonConvert.SerializeObject(myDataObject);
        }
        
    }

    public class PictreHttpClient
    {
        private static volatile PictreHttpClient instance = null;
        static HttpClient client = new HttpClient();

        //singleton class
        private PictreHttpClient()
        {
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["PictreServicesBaseAddress"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public static PictreHttpClient getInstance()
        {
            if (instance == null)
                instance = new PictreHttpClient();


            return instance;
        }

        public static async Task<T> GetTAsync<T>(string requestUri)
        {
            T t = default(T);
            //using (var client = new HttpClient())
            //{
                HttpResponseMessage response = await client.GetAsync(requestUri);
                if (response.IsSuccessStatusCode)
                {
                    t = await response.Content.ReadAsAsync<T>();
                }
            //}
            return t;
        }

        public static async Task<Uri> CreateTAsync<T>(string requestUri,T t)
        {
            //requestUri --> "api/products"
            HttpResponseMessage response = await client.PostAsJsonAsync(requestUri, t);
            response.EnsureSuccessStatusCode();

            // Return the URI of the created resource.
            return response.Headers.Location;
        }

        public static async Task<T> UpdateTAsync<T>(string requestUri, T t)
        {
            //requestUri --> $"api/products/{product.Id}"
            HttpResponseMessage response = await client.PutAsJsonAsync(requestUri, t);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            t = await response.Content.ReadAsAsync<T>();
            return t;
        }

        public static async Task<HttpStatusCode> DeleteTAsync(string requestUri, string id)
        {
            //$"api/products/{id}"
            HttpResponseMessage response = await client.DeleteAsync($"{requestUri}/{id}");
            return response.StatusCode;
        }

    }
}
