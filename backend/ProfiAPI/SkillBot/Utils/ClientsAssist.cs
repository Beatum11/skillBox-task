using SkillBot.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBot.Utils
{
    public static class ClientsAssist
    {
        public static void UpdateClientInfo(string input, ClientDto clientInfo)
        {
            if (clientInfo.Name == null)
            {
                clientInfo.Name = input;
            }
            else if (clientInfo.Email == null)
            {
                clientInfo.Email = input;
            }
            else if (clientInfo.Message == null)
            {
                clientInfo.Message = input;
            }
        }
    }
}
