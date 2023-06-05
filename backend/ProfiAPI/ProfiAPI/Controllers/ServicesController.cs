using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfiAPI.Data.IF;
using ProfiAPI.Data.Models;
using ProfiAPI.Utils;

namespace ProfiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        #region Basic Set-Up

        private readonly ApplicationDbContext _context;

        public ServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion


        #region GET

        // GET: api/Services
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetServices()
        {
           return ContextHelp.NullCheck(_context) ? NotFound() : 
                                            await ContextHelp.FindItemsAsync<Service>
                                                                            (_context);
        }

        // GET: api/Services/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetService(int id)
        {
            if (ContextHelp.NullCheck(_context))
                  return NotFound();

            var service = await ContextHelp.FindItemAsync<Service>(id, _context);

            if (service == null)
                return NotFound();

            return service;
        }

        #endregion

        #region PUT

        // PUT: api/Services/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutService(int id, Service service)
        {
            if (id != service.Id)
                return BadRequest();

            if (!ContextHelp.NullCheck(_context))
            {
                var serviceToUpdate = await ContextHelp.FindItemAsync<Service>(id, _context);

                if (serviceToUpdate == null)
                    return NotFound();
                else
                {
                    // Update properties
                    serviceToUpdate.Title = service.Title;
                    serviceToUpdate.Description = service.Description;

                    // Save the changes
                    await ContextHelp.UpdateAndSave(_context, serviceToUpdate);
                }
            }

            return NoContent();
        }

        #endregion

        #region POST

        // POST: api/Services
        [HttpPost]
        public async Task<ActionResult<Service>> PostService(Service service)
        {
          if (ContextHelp.NullCheck(_context))
              return Problem("Entity set 'Services' is null.");
          else
            await ContextHelp.AddAndSave(_context, service);

            return CreatedAtAction("GetService", new { id = service.Id }, service);
        }

        #endregion

        #region DELETE

        // DELETE: api/Services/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            if (ContextHelp.NullCheck(_context))
                return NotFound();

            var service = await ContextHelp.FindItemAsync<Service>(id, _context);

            if (service == null)
                return NotFound();
            else
                await ContextHelp.RemoveAndSave(_context, service);
            
            return NoContent();
        }

        #endregion
    }
}
