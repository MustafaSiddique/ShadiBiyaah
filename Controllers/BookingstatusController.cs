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
    public class BookingstatusController : ControllerBase
    {
        private readonly FypDBContext _context;

        public BookingstatusController(FypDBContext context)
        {
            _context = context;
        }

        // GET: api/Bookingstatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bookingstatus>>> GetBookingstatuses()
        {
            return await _context.Bookingstatuses.ToListAsync();
        }

        // GET: api/Bookingstatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bookingstatus>> GetBookingstatus(int id)
        {
            var bookingstatus = await _context.Bookingstatuses.FindAsync(id);

            if (bookingstatus == null)
            {
                return NotFound();
            }

            return bookingstatus;
        }

        // PUT: api/Bookingstatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingstatus(int id, Bookingstatus bookingstatus)
        {
            if (id != bookingstatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookingstatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingstatusExists(id))
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

        // POST: api/Bookingstatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bookingstatus>> PostBookingstatus(Bookingstatus bookingstatus)
        {
            _context.Bookingstatuses.Add(bookingstatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookingstatus", new { id = bookingstatus.Id }, bookingstatus);
        }

        // DELETE: api/Bookingstatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingstatus(int id)
        {
            var bookingstatus = await _context.Bookingstatuses.FindAsync(id);
            if (bookingstatus == null)
            {
                return NotFound();
            }

            _context.Bookingstatuses.Remove(bookingstatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingstatusExists(int id)
        {
            return _context.Bookingstatuses.Any(e => e.Id == id);
        }
    }
}
