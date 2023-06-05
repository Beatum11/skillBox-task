namespace ProfiAPI.Data.Models
{
    public class Project
    {
        #region Fields

        private int id;
        private string? _cover;
        private string? _title;
        private string? _description;

        #endregion

        #region Properties

        public int Id { get => id; set => id = value; }
        public string? Cover { get => _cover; set => _cover = value; }

        public string? Title { get => _title; set => _title = value; }

        public string? Description { get => _description; set => _description = value; }

        #endregion

        #region Constructor 

        public Project(int id, string cover, string title, string description)
        {
            Id = id;
            Cover = cover;
            Title = title;
            Description = description;
        }
        #endregion  
    }
}
