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
    public class PaymentstatusController : ControllerBase
    {
        private readonly FypDBContext _context;

        public PaymentstatusController(FypDBContext context)
        {
            _context = context;
        }

        // GET: api/Paymentstatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paymentstatus>>> GetPaymentstatuses()
        {
            return await _context.Paymentstatuses.ToListAsync();
        }

        // GET: api/Paymentstatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paymentstatus>> GetPaymentstatus(int id)
        {
            var paymentstatus = await _context.Paymentstatuses.FindAsync(id);

            if (paymentstatus == null)
            {
                return NotFound();
            }

            return paymentstatus;
        }

        // PUT: api/Paymentstatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentstatus(int id, Paymentstatus paymentstatus)
        {
            if (id != paymentstatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(paymentstatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentstatusExists(id))
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

        // POST: api/Paymentstatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Paymentstatus>> PostPaymentstatus(Paymentstatus paymentstatus)
        {
            _context.Paymentstatuses.Add(paymentstatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentstatus", new { id = paymentstatus.Id }, paymentstatus);
        }

        // DELETE: api/Paymentstatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentstatus(int id)
        {
            var paymentstatus = await _context.Paymentstatuses.FindAsync(id);
            if (paymentstatus == null)
            {
                return NotFound();
            }

            _context.Paymentstatuses.Remove(paymentstatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentstatusExists(int id)
        {
            return _context.Paymentstatuses.Any(e => e.Id == id);
        }
    }
}
