using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfiAPI.Data.IF;
using ProfiAPI.Data.Models;
using ProfiAPI.Utils;

namespace ProfiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatesFilterController : ControllerBase
    {
        #region Basic set-up

        private readonly ApplicationDbContext _context;

        public DatesFilterController(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        // GET: api/
        [HttpGet("today")]
        public async Task<ActionResult<IEnumerable<Client>>> GetTodaysClients()
        {
            var todaysDate = DateTime.Today;

            if (ContextHelp.NullCheck(_context))
                return NotFound();
            else
            {
                var clients = await ContextHelp.FindItemsAsync<Client>(_context);
                var todaysClient = clients.Where(client => client.Created.Date == todaysDate);
                return Ok(todaysClient);
            }
                                             
        }

        // GET: api/
        [HttpGet("yesterday")]
        public async Task<ActionResult<IEnumerable<Client>>> GetYesterdaysClients()
        {
            var yesterdaysDate = DateTime.Today.AddDays(-1);

            if (ContextHelp.NullCheck(_context))
                return NotFound();
            else
            {
                var clients = await ContextHelp.FindItemsAsync<Client>(_context);
                var todaysClient = clients.Where(client => client.Created.Date == yesterdaysDate);
                return Ok(todaysClient);
            }

        }
    }
}
