using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfiAPI.Data.IF;
using ProfiAPI.Data.Models;
using ProfiAPI.Utils;

namespace ProfiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        #region Basic Set-Up

        private readonly ApplicationDbContext _context;

        public BlogPostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region GET

        // GET: api/BlogPosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogPost>>> GetBlogPosts()
        {
            return ContextHelp.NullCheck(_context) ? NotFound() :
                                             await ContextHelp.FindItemsAsync<BlogPost>
                                                                             (_context);
        }

        // GET: api/BlogPosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogPost>> GetBlogPost(int id)
        {
            if (ContextHelp.NullCheck(_context))
                return NotFound();

            var blogPost = await ContextHelp.FindItemAsync<BlogPost>(id, _context);

            if (blogPost == null)
                return NotFound();
            else
                return blogPost;
        }

        #endregion

        #region PUT

        // PUT: api/BlogPosts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlogPost(int id, BlogPost blogPost)
        {
            if (id != blogPost.Id)
                return BadRequest();

            if (!ContextHelp.NullCheck(_context))
            {
                var postToUpdate = await ContextHelp.FindItemAsync<BlogPost>(id, _context);

                if (postToUpdate == null)
                    return NotFound();
                else
                {
                    // Update properties
                    postToUpdate.Image = blogPost.Image;
                    postToUpdate.Title = blogPost.Title;
                    postToUpdate.Content = blogPost.Content;

                    // Save the changes
                    await ContextHelp.UpdateAndSave(_context, postToUpdate);
                }
            }

            return NoContent();
        }

        #endregion

        #region POST

        // POST: api/BlogPosts
        [HttpPost]
        public async Task<ActionResult<BlogPost>> PostBlogPost(BlogPost blogPost)
        {
            blogPost.Created = DateTime.Now;

            if (ContextHelp.NullCheck(_context))
                return Problem("Entity set 'Projects' is null.");
            else
                await ContextHelp.AddAndSave(_context, blogPost);

            return Ok();
        }

        #endregion

        #region DELETE

        // DELETE: api/BlogPosts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogPosts(int id)
        {
            if (ContextHelp.NullCheck(_context))
                return NotFound();

            var post = await ContextHelp.FindItemAsync<BlogPost>(id, _context);

            if (post == null)
                return NotFound();
            else
                await ContextHelp.RemoveAndSave(_context, post);

            return NoContent();
        }

        #endregion
    }
}
