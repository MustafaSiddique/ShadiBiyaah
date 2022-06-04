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
    public class VendorcontactdetailController : ControllerBase
    {
        private readonly FypDBContext _context;

        public VendorcontactdetailController(FypDBContext context)
        {
            _context = context;
        }

        // GET: api/Vendorcontactdetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendorcontactdetail>>> GetVendorcontactdetails()
        {
            return await _context.Vendorcontactdetails.ToListAsync();
        }

        // GET: api/Vendorcontactdetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vendorcontactdetail>> GetVendorcontactdetail(int id)
        {
            var vendorcontactdetail = await _context.Vendorcontactdetails.FindAsync(id);

            if (vendorcontactdetail == null)
            {
                return NotFound();
            }

            return vendorcontactdetail;
        }

        // PUT: api/Vendorcontactdetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendorcontactdetail(int id, Vendorcontactdetail vendorcontactdetail)
        {
            if (id != vendorcontactdetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(vendorcontactdetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendorcontactdetailExists(id))
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

        // POST: api/Vendorcontactdetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vendorcontactdetail>> PostVendorcontactdetail(Vendorcontactdetail vendorcontactdetail)
        {
            _context.Vendorcontactdetails.Add(vendorcontactdetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVendorcontactdetail", new { id = vendorcontactdetail.Id }, vendorcontactdetail);
        }

        // DELETE: api/Vendorcontactdetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendorcontactdetail(int id)
        {
            var vendorcontactdetail = await _context.Vendorcontactdetails.FindAsync(id);
            if (vendorcontactdetail == null)
            {
                return NotFound();
            }

            _context.Vendorcontactdetails.Remove(vendorcontactdetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VendorcontactdetailExists(int id)
        {
            return _context.Vendorcontactdetails.Any(e => e.Id == id);
        }
    }
}
