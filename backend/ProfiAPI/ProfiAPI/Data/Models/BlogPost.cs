namespace ProfiAPI.Data.Models
{
    public class BlogPost
    {
        #region Fields

        private int id;
        private string? _image;
        private string? _title;
        private string? _content;
        private DateTime? _created;

        #endregion

        #region Properties

        public int Id { get => id; set => id = value; }
        public string? Image { get => _image; set => _image = value; }
        public string? Title { get => _title; set => _title = value; }
        public string? Content { get => _content; set => _content = value; }

        public DateTime? Created { get => _created; set => _created = value; }

        #endregion

        #region Constructor 

        public BlogPost(int id, string image, string title, string content, DateTime? created)
        {
            Id = id;
            Image = image;
            Title = title;
            Content = content;
            Created = created;
        }
        #endregion  
    }
}
