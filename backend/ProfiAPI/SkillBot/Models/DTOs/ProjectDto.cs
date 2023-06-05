using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBot.Models.DTOs
{
    public class ProjectDto
    {
        #region Fields
        private string? _title;
        private string? _description;
        #endregion

        #region Properties
        public string? Title { get => _title; set => _title = value; }
        public string? Description { get => _description; set => _description = value; }

        #endregion

        #region Constructor 

        public ProjectDto(string title, string description)
        {
            Title = title;
            Description = description;
        }
        #endregion  
    }
}
