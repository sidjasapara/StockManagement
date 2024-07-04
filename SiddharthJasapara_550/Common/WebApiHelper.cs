using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SiddharthJasapara_550.Common
{
    public class WebApiHelper
    {
        public static async Task<string> HttpRequestResponse(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient(new HttpClientHandler { UseCookies = false }))
                {
                    client.BaseAddress = new Uri("http://localhost:62675/");
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var token = HttpContext.Current.Request.Cookies["jwt"];
                    if (token != null)
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.Value);
                        //client.DefaultRequestHeaders.Add("Cookie", $"jwt={token.Value}");
                    }

                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        return response.Content.ReadAsStringAsync().Result;
                    }
                    return null;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //For POST request
        public static async Task<string> HttpPostRequestResponse(string jsonContent, string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:62675/");
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    var token = HttpContext.Current.Request.Cookies["Jwt"];
                    if (token != null)
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.Value);
                        client.DefaultRequestHeaders.Add("Cookie", $"jwt={token.Value}");
                    }
                    var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, httpContent);

                    if (response.IsSuccessStatusCode)
                    {
                        return response.Content.ReadAsStringAsync().Result;
                    }
                    return null;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}