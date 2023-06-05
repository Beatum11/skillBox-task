namespace ProfiAPI.Data.Models
{
    public class Service
    {
        #region Fields
        private int _id;
        private string? _title;
        private string? _description;
        #endregion

        #region Properties
        public int Id { get => _id; set => _id = value; }
        public string? Title { get => _title; set => _title = value; }
        public string? Description { get => _description; set => _description = value; }

        #endregion

        #region Constructor 

        public Service(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }

        #endregion
    }
}
