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
    public class ServicecategoryController : ControllerBase
    {
        private readonly FypDBContext _context;

        public ServicecategoryController(FypDBContext context)
        {
            _context = context;
        }

        // GET: api/Servicecategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servicecategory>>> GetServicecategories()
        {
            return await _context.Servicecategories.ToListAsync();
        }

        // GET: api/Servicecategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Servicecategory>> GetServicecategory(int id)
        {
            var servicecategory = await _context.Servicecategories.FindAsync(id);

            if (servicecategory == null)
            {
                return NotFound();
            }

            return servicecategory;
        }

        // PUT: api/Servicecategory/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServicecategory(int id, Servicecategory servicecategory)
        {
            if (id != servicecategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(servicecategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicecategoryExists(id))
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

        // POST: api/Servicecategory
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Servicecategory>> PostServicecategory(Servicecategory servicecategory)
        {
            _context.Servicecategories.Add(servicecategory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ServicecategoryExists(servicecategory.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetServicecategory", new { id = servicecategory.Id }, servicecategory);
        }

        // DELETE: api/Servicecategory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServicecategory(int id)
        {
            var servicecategory = await _context.Servicecategories.FindAsync(id);
            if (servicecategory == null)
            {
                return NotFound();
            }

            _context.Servicecategories.Remove(servicecategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServicecategoryExists(int id)
        {
            return _context.Servicecategories.Any(e => e.Id == id);
        }
    }
}
