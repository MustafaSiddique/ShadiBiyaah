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
    public class CarddetailController : ControllerBase
    {
        private readonly FypDBContext _context;

        public CarddetailController(FypDBContext context)
        {
            _context = context;
        }

        // GET: api/Carddetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carddetail>>> GetCarddetails()
        {
            return await _context.Carddetails.ToListAsync();
        }

        // GET: api/Carddetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carddetail>> GetCarddetail(int id)
        {
            var carddetail = await _context.Carddetails.FindAsync(id);

            if (carddetail == null)
            {
                return NotFound();
            }

            return carddetail;
        }

        // PUT: api/Carddetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarddetail(int id, Carddetail carddetail)
        {
            if (id != carddetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(carddetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarddetailExists(id))
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

        // POST: api/Carddetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Carddetail>> PostCarddetail(Carddetail carddetail)
        {
            _context.Carddetails.Add(carddetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarddetail", new { id = carddetail.Id }, carddetail);
        }

        // DELETE: api/Carddetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarddetail(int id)
        {
            var carddetail = await _context.Carddetails.FindAsync(id);
            if (carddetail == null)
            {
                return NotFound();
            }

            _context.Carddetails.Remove(carddetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarddetailExists(int id)
        {
            return _context.Carddetails.Any(e => e.Id == id);
        }
    }
}
