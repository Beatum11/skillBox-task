using Newtonsoft.Json;
using SkillBot.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBot.API.POST
{
    public static class ApplicationRequest
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public static async Task PostDataAsync(ClientDto clientDto)
        {
            // Convert the data we want to send into JSON
            var jsonClient = JsonConvert.SerializeObject(clientDto);

            // Put the JSON into a finalClient object
            var finalClient = new StringContent(jsonClient, Encoding.UTF8, "application/json");

            // Post the data
            var response = await httpClient.PostAsync("https://localhost:7106/api/Clients", finalClient);

            // Make sure the request was successful
            response.EnsureSuccessStatusCode();
        }

    }
}
