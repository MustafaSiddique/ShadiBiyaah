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
    public class PackagedetailController : ControllerBase
    {
        private readonly FypDBContext _context;

        public PackagedetailController(FypDBContext context)
        {
            _context = context;
        }

        // GET: api/Packagedetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Packagedetail>>> GetPackagedetails()
        {
            return await _context.Packagedetails.ToListAsync();
        }

        // GET: api/Packagedetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Packagedetail>> GetPackagedetail(int id)
        {
            var packagedetail = await _context.Packagedetails.FindAsync(id);

            if (packagedetail == null)
            {
                return NotFound();
            }

            return packagedetail;
        }

        // PUT: api/Packagedetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPackagedetail(int id, Packagedetail packagedetail)
        {
            if (id != packagedetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(packagedetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackagedetailExists(id))
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

        // POST: api/Packagedetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Packagedetail>> PostPackagedetail(Packagedetail packagedetail)
        {
            _context.Packagedetails.Add(packagedetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPackagedetail", new { id = packagedetail.Id }, packagedetail);
        }

        // DELETE: api/Packagedetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackagedetail(int id)
        {
            var packagedetail = await _context.Packagedetails.FindAsync(id);
            if (packagedetail == null)
            {
                return NotFound();
            }

            _context.Packagedetails.Remove(packagedetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PackagedetailExists(int id)
        {
            return _context.Packagedetails.Any(e => e.Id == id);
        }
    }
}
