#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FypDb.Models;

namespace FypDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicetypeController : ControllerBase
    {
        private readonly FypDBContext _context;

        public ServicetypeController(FypDBContext context)
        {
            _context = context;
        }

        // GET: api/Servicetype
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servicetype>>> GetServicetypes()
        {
            return await _context.Servicetypes.ToListAsync();
        }

        // GET: api/Servicetype/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Servicetype>> GetServicetype(int id)
        {
            var servicetype = await _context.Servicetypes.FindAsync(id);

            if (servicetype == null)
            {
                return NotFound();
            }

            return servicetype;
        }

        // PUT: api/Servicetype/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServicetype(int id, Servicetype servicetype)
        {
            if (id != servicetype.Id)
            {
                return BadRequest();
            }

            _context.Entry(servicetype).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicetypeExists(id))
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

        // POST: api/Servicetype
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Servicetype>> PostServicetype(Servicetype servicetype)
        {
            _context.Servicetypes.Add(servicetype);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServicetype", new { id = servicetype.Id }, servicetype);
        }

        // DELETE: api/Servicetype/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServicetype(int id)
        {
            var servicetype = await _context.Servicetypes.FindAsync(id);
            if (servicetype == null)
            {
                return NotFound();
            }

            _context.Servicetypes.Remove(servicetype);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServicetypeExists(int id)
        {
            return _context.Servicetypes.Any(e => e.Id == id);
        }
    }
}
