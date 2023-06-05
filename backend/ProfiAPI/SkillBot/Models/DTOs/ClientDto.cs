using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBot.Models.DTOs
{
    public class ClientDto
    {
        #region Fields

        private string? _name;
        private string? _email;
        private string? _message;

        #endregion

        #region Properties
        public string? Name { get => _name; set => _name = value; }
        public string? Email { get => _email; set => _email = value; }
        public string? Message { get => _message; set => _message = value; }
        #endregion

        #region Constructor 

        public ClientDto(string name, string email, string message)
        {
            Name = name;
            Email = email;
            Message = message;
        }

        public ClientDto()
        {

        }
        #endregion  
    }
}
