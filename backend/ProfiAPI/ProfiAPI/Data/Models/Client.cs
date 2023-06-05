using System.Security.Cryptography.X509Certificates;

namespace ProfiAPI.Data.Models
{
    public class Client
    {
        #region Fields

        private int id;
        private string? _name;
        private string? _email;
        private string? _message;
        private DateTime _created;

        #endregion

        #region Properties

        public int Id { get => id; set => id = value; }
        public string? Name { get => _name; set => _name = value; }
        public string? Email { get => _email; set => _email = value; }
        public string? Message { get => _message; set => _message = value; }
        public DateTime Created { get => _created; set => _created = value; }   

        #endregion

        #region Constructor 

        public Client(int id, string name, string email, string message, DateTime created)
        {
            Id = id;
            Name = name;
            Email = email;
            Message = message;
            Created = created;
        }
        #endregion  
    }
}
