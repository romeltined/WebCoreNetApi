using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCoreNetApi;
using WebCoreNetApi.Models;

namespace WebCoreNetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DhtsController : ControllerBase
    {
        private readonly ArduinoContext _context;

        public DhtsController(ArduinoContext context)
        {
            _context = context;
        }

        // GET: api/Dhts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dht>>> GetDhts()
        {
            return await _context.Dhts.ToListAsync();
        }

        // GET: api/Dhts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dht>> GetDht(int id)
        {
            var dht = await _context.Dhts.FindAsync(id);

            if (dht == null)
            {
                return NotFound();
            }

            return dht;
        }

        // PUT: api/Dhts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDht(int id, Dht dht)
        {
            if (id != dht.Id)
            {
                return BadRequest();
            }

            _context.Entry(dht).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DhtExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Dhts
        [HttpPost]
        public async Task<ActionResult<Dht>> PostDht(Dht dht)
        {
            dht.CreatedDateTime = DateTime.UtcNow;
            _context.Dhts.Add(dht);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDht", new { id = dht.Id }, dht);
        }

        // DELETE: api/Dhts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dht>> DeleteDht(int id)
        {
            var dht = await _context.Dhts.FindAsync(id);
            if (dht == null)
            {
                return NotFound();
            }

            _context.Dhts.Remove(dht);
            await _context.SaveChangesAsync();

            return dht;
        }

        private bool DhtExists(int id)
        {
            return _context.Dhts.Any(e => e.Id == id);
        }
    }
}
