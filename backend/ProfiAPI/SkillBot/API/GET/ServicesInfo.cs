using Newtonsoft.Json;
using SkillBot.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBot.API
{
    public static class ServicesInfo
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<ServiceDto[]> GetServices()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://localhost:7106/api/Services")
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var services = JsonConvert.DeserializeObject<ServiceDto[]>(body);
                return services;
            }
        }
    }
}
