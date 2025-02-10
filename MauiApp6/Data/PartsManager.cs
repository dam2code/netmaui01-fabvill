using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using MauiApp6.Modelos;

namespace MauiApp6.Data
{
    internal class PartsManager
    {
        static readonly string BaseAddress = "URL_GOES_HERE";  // Reemplaza con la URL correcta de tu API
        static readonly string Url = $"{BaseAddress}/api/";
        private static string authorizationKey;

        static HttpClient client;

        private static async Task<HttpClient> GetClient()
        {
            if (client != null)
                return client;

            client = new HttpClient();

            if (string.IsNullOrEmpty(authorizationKey))
            {
               
                authorizationKey = await client.GetStringAsync($"{Url}login");
                authorizationKey = JsonSerializer.Deserialize<string>(authorizationKey);
            }

           
            client.DefaultRequestHeaders.Add("Authorization", authorizationKey);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            return client;
        }


        public static async Task<IEnumerable<Part>> GetAll()
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return new List<Part>();

            var client = await GetClient();
            string result = await client.GetStringAsync($"{Url}parts");

            return JsonSerializer.Deserialize<List<Part>>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
        }

        public static async Task<Part> Add(string partName, string supplier, string partType)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return new Part();

            var client = await GetClient();

            var part = new Part()
            {
                PartName = partName,
                Suppliers = new List<string> { supplier },
                PartID = string.Empty, 
                PartType = partType,
                PartAvailableDate = DateTime.Now.Date
            };

            var msg = new HttpRequestMessage(HttpMethod.Post, $"{Url}parts");
            msg.Content = JsonContent.Create(part);  

     
            var response = await client.SendAsync(msg);
            response.EnsureSuccessStatusCode();  

            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Part>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public static async Task Update(Part part)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return;

            var client = await GetClient();

            var msg = new HttpRequestMessage(HttpMethod.Put, $"{Url}parts/{part.PartID}");
            msg.Content = JsonContent.Create(part); 

            var response = await client.SendAsync(msg);
            response.EnsureSuccessStatusCode(); 
        }


        public static async Task Delete(string partID)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return;

            var client = await GetClient();

            var msg = new HttpRequestMessage(HttpMethod.Delete, $"{Url}parts/{partID}");

            var response = await client.SendAsync(msg);
            response.EnsureSuccessStatusCode(); 
        }
    }
}
