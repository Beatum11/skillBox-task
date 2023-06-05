using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfiAPI.Data.IF;
using ProfiAPI.Data.Models;
using ProfiAPI.Utils;

namespace ProfiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        #region Basic Set-Up

        private readonly ApplicationDbContext _context;

        public ProjectsController (ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region GET

        // GET: api/Projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            return ContextHelp.NullCheck(_context) ? NotFound() :
                                             await ContextHelp.FindItemsAsync<Project>
                                                                             (_context);
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            if (ContextHelp.NullCheck(_context))
                return NotFound();

            var project = await ContextHelp.FindItemAsync<Project>(id, _context);

            if (project == null)
                return NotFound();
            else
                return project;
        }

        #endregion

        #region PUT

        // PUT: api/Projects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, Project project)
        {
            if (id != project.Id)
                return BadRequest();

            if (!ContextHelp.NullCheck(_context))
            {
                var projectToUpdate = await ContextHelp.FindItemAsync<Project>(id, _context);

                if (projectToUpdate == null)
                    return NotFound();
                else
                {
                    // Update properties
                    projectToUpdate.Cover = project.Cover;
                    projectToUpdate.Title = project.Title;
                    projectToUpdate.Description = project.Description;

                    // Save the changes
                    await ContextHelp.UpdateAndSave(_context, projectToUpdate);
                }
            }

            return NoContent();
        }

        #endregion

        #region POST

        // POST: api/Projects
        [HttpPost]
        public async Task<ActionResult<Project>> PostProject(Project project)
        {
            if (ContextHelp.NullCheck(_context))
                return Problem("Entity set 'Projects' is null.");
            else
                await ContextHelp.AddAndSave(_context, project);

            return Ok();
        }

        #endregion

        #region DELETE

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            if (ContextHelp.NullCheck(_context))
                return NotFound();

            var project = await ContextHelp.FindItemAsync<Project>(id, _context);

            if (project == null)
                return NotFound();
            else
                await ContextHelp.RemoveAndSave(_context, project);

            return NoContent();
        }

        #endregion
    }
}
