using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Szkola.Data.Web;
using Szkola.Services.Interfaces;

namespace Szkola.Services
{
    public class HttpService : IHttpService
    {
        public async Task<GetResponse> AccessToken(string code)
        {
            var response = new GetResponse()
            {
                IsSuccess = false
            };

            var accessTokenRequest = new { authorization_code = code };

            using (var client = new HttpClient())
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(accessTokenRequest));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var reply = await client.PostAsync("http://api.nintriva.net/v1/accesstoken", content);
                if (!reply.IsSuccessStatusCode)
                {
                    return response;
                }

                var read = await reply.Content.ReadAsStringAsync();
                var jsonResponse = JsonConvert.DeserializeObject<AccessTokenResponse>(read);
                response.IsSuccess = true;
                response.Response = jsonResponse;
            }

            return response;
        }

        public async Task<GetResponse> Authorize(string username, string password)
        {
            var response = new GetResponse()
            {
                IsSuccess = false
            };

            var request = new LoginRequest()
            {
                Username = username,
                Password = password
            };

            using (var client = new HttpClient())
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(request));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var reply = await client.PostAsync("http://api.nintriva.net/v1/authorize", content);
                if (!reply.IsSuccessStatusCode)
                {
                    return response;
                }

                var read = await reply.Content.ReadAsStringAsync();
                var jsonResponse = JsonConvert.DeserializeObject<LoginResponse>(read);
                response.IsSuccess = true;
                response.Response = jsonResponse;
            }

            return response;
        }


        public async Task<GetResponse> GetPersonalData()
        {
            var response = new GetResponse()
            {
                IsSuccess = false
            };
            
            if (string.IsNullOrWhiteSpace(App.AccessToken))
            {
                return response;
            }

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-Access-Token", App.AccessToken);
                var reply = await client.GetAsync("http://api.nintriva.net/v1/me");
                if (!reply.IsSuccessStatusCode)
                {
                    return response;
                }

                var read = await reply.Content.ReadAsStringAsync();
                var jsonResponse = JsonConvert.DeserializeObject<MeResponse>(read);
                response.IsSuccess = true;
                response.Response = jsonResponse;
            }

            return response;
        }
    }
}
