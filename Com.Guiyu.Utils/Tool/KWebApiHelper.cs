using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using Com.Guiyu.Utils.Auth;
using Com.Guiyu.Utils.Config;


namespace Com.Guiyu.Utils.Tool
{
    public static class KWebApiHelper<T>
    {

        public static T Get(string baseUrl, string requestUrl, bool token)
        {
            string mediaType = "application/json";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));

                if (token)
                {
                    client.DefaultRequestHeaders.Add(KAuthConfig.YijinTokenRequestName, KTokenHelper.GetYijinTokenRequestStr(baseUrl + requestUrl));
                }

                // New code:
                HttpResponseMessage response = client.GetAsync(requestUrl).Result;
               

                if (response.IsSuccessStatusCode)
                {

                    T res = response.Content.ReadAsAsync<T>().Result;
                    return res;
                }
            }
            return default(T);
        }
    
        public static Task<T> GetAsAsync(string baseUrl, string requestUrl, bool token=true)
        {
            string mediaType = "application/json";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
                if(token)
                {
                    client.DefaultRequestHeaders.Add(KAuthConfig.YijinTokenRequestName, KTokenHelper.GetYijinTokenRequestStr(baseUrl + requestUrl));
                }

                // New code:
                HttpResponseMessage response = client.GetAsync(requestUrl).Result;
                

                if (response.IsSuccessStatusCode)
                {

                    
                    Task<T> res = response.Content.ReadAsAsync<T>();
                   
                    return  res;
                }
            }
       
            return null;
        }


        public static Task<T> PostAsAsync<M>(string baseUrl, string requestUrl, M data )
        {
            string mediaType = "application/json";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add(KAuthConfig.YijinTokenRequestName, KTokenHelper.GetYijinTokenRequestStr(baseUrl + requestUrl + "_" + JsonConvert.SerializeObject(data)));
               
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
            
                // New code:
                HttpResponseMessage response = client.PostAsJsonAsync<M>(requestUrl,data).Result;


                if (response.IsSuccessStatusCode)
                {

                    Task<T> res = response.Content.ReadAsAsync<T>();
                    
                    return res;
                }
            }
            return null;
        }


        public static T Post<M>(string baseUrl, string requestUrl, M data)
        {
            string mediaType = "application/json";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

            ;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add(KAuthConfig.YijinTokenRequestName, KTokenHelper.GetYijinTokenRequestStr(baseUrl + requestUrl + "_" + JsonConvert.SerializeObject(data)));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));

                // New code:
                HttpResponseMessage response = client.PostAsJsonAsync<M>(requestUrl, data).Result;
               

                if (response.IsSuccessStatusCode)
                {

                    T res = response.Content.ReadAsAsync<T>().Result;
                    return res;
                }
                else
                {

                    return default(T);
                }
            }
         
        }
    }
}
