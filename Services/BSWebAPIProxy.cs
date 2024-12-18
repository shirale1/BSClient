using BSClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BSClient.Services
{
    public class BSWebAPIProxy
    {

        private static string serverIP = "9shzggn0-5083.euw.devtunnels.ms";
        private HttpClient client;
        private string baseUrl;
        public static string BaseAddress = " https://9shzggn0-5083.euw.devtunnels.ms/api/";
        private static string ImageBaseAddress = "https://9shzggn0-5083.euw.devtunnels.ms/";

        public BSWebAPIProxy()
        {
            //Set client handler to support cookies!!
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = new System.Net.CookieContainer();

            this.client = new HttpClient(handler);
            this.baseUrl = BaseAddress;
        }


        public async Task<Users?> LoginAsync(LoginInfo userInfo)
        {
            //Set URI to the specific function API
            string url = $"{this.baseUrl}login";
            try
            {
                //Call the server API
                string json = JsonSerializer.Serialize(userInfo);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                //Check status
                if (response.IsSuccessStatusCode)
                {
                    //Extract the content as string
                    string resContent = await response.Content.ReadAsStringAsync();
                    //Desrialize result
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    Babysiter? bResult = JsonSerializer.Deserialize<Babysiter>(resContent, options);
                    if (bResult == null || bResult.Age == null)
                    {
                        Parent? pResult = JsonSerializer.Deserialize<Parent>(resContent, options);
                        return pResult;
                    }
                    else
                        return bResult;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Babysiter?> RegisterBabysiter(Babysiter b)
        {
            //Set URI to the specific function API
            string url = $"{this.baseUrl}registerBabysiter";
            try
            {
                //Call the server API
                string json = JsonSerializer.Serialize(b);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                //Check status
                if (response.IsSuccessStatusCode)
                {
                    //Extract the content as string
                    string resContent = await response.Content.ReadAsStringAsync();
                    //Desrialize result
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    Babysiter? result = JsonSerializer.Deserialize<Babysiter>(resContent, options);
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Parent?> RegisterParent(Parent p)
        {
            //Set URI to the specific function API
            string url = $"{this.baseUrl}registerParent";
            try
            {
                //Call the server API
                string json = JsonSerializer.Serialize(p);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                //Check status
                if (response.IsSuccessStatusCode)
                {
                    //Extract the content as string
                    string resContent = await response.Content.ReadAsStringAsync();
                    //Desrialize result
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    Parent? result = JsonSerializer.Deserialize<Parent>(resContent, options);
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

