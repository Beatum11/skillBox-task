using Microsoft.VisualBasic;
using Newtonsoft.Json;
using SkillBot.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBot.API.GET
{
    public static class ProjectsInfo
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<ProjectDto[]> GetProjects()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://localhost:7106/api/Projects")
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var projects = JsonConvert.DeserializeObject<ProjectDto[]>(body);
                return projects;
            }
        }
        

    }
}
