using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfiAPI.Data.IF;
using ProfiAPI.Data.Models;
using ProfiAPI.Utils;

namespace ProfiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        #region Basic Set-Up

        private readonly ApplicationDbContext _context;

        public ClientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region GET

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return ContextHelp.NullCheck(_context) ? NotFound() :
                                             await ContextHelp.FindItemsAsync<Client>
                                                                             (_context);
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            if (ContextHelp.NullCheck(_context))
                return NotFound();

            var client = await ContextHelp.FindItemAsync<Client>(id, _context);

            if (client == null)
                return NotFound();
            else
                return client;
        }

        #endregion

        #region PUT

        // PUT: api/Clients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClients(int id, Client client)
        {
            if (id != client.Id)
                return BadRequest();

            if (!ContextHelp.NullCheck(_context))
            {
                var clientToUpdate = await ContextHelp.FindItemAsync<Client>(id, _context);

                if (clientToUpdate == null)
                    return NotFound();
                else
                {
                    // Update properties
                    clientToUpdate.Name = client.Name;
                    clientToUpdate.Email = client.Email;
                    clientToUpdate.Message = client.Message;
                    clientToUpdate.Created = DateTime.Now;

                    // Save the changes
                    await ContextHelp.UpdateAndSave(_context, clientToUpdate);
                }
            }

            return NoContent();
        }

        #endregion

        #region POST

        // POST: api/Clients
        [HttpPost]
        public async Task<ActionResult<Client>> PostClients(Client client)
        {
            client.Created = DateTime.Now;

            if (ContextHelp.NullCheck(_context))
                return Problem("Entity set 'Projects' is null.");
            else
                await ContextHelp.AddAndSave(_context, client);

            return Ok();
        }

        #endregion

        #region DELETE

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClients(int id)
        {
            if (ContextHelp.NullCheck(_context))
                return NotFound();

            var client = await ContextHelp.FindItemAsync<Client>(id, _context);

            if (client == null)
                return NotFound();
            else
                await ContextHelp.RemoveAndSave(_context, client);

            return NoContent();
        }

        #endregion
    }
}
