using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using webAPI.Model;

namespace webAPI.Controllers
{
    [Route("home/[action]")]
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            string Token = await GetToken();
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient httpClient = new HttpClient(clientHandler);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer "+Token.ToString());
      //      httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml+json");
            var response = await httpClient.GetAsync("https://localhost:44365/api/categoryapi");
            string result = response.Content.ReadAsStringAsync().Result;
            return View();
        }
        public async Task<string> GetToken()
        {
            string Token = String.Empty;
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri("https://localhost:44365");
                //Lấy AccessToken
                string urlPath = "api/token";
                var requestData = new User();
                requestData.Email = "thanhduy@gmail.com";

                var json = JsonConvert.SerializeObject(requestData);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(urlPath, data);

                 Token = response.Content.ReadAsStringAsync().Result;

            }
            return Token;
        }
    }
}
