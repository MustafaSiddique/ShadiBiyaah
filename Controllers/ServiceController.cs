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
    public class ServiceController : ControllerBase
    {
        private readonly FypDBContext _context;

        public ServiceController(FypDBContext context)
        {
            _context = context;
        }

        // GET: api/Service
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetServices()
        {
            return await _context.Services.ToListAsync();
        }

        // GET: api/Service/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetService(int id)
        {
            var service = await _context.Services.FindAsync(id);

            if (service == null)
            {
                return NotFound();
            }

            return service;
        }

        // GET ServiceDetailsPage
        [HttpGet("GetServiceDetailsPage/{id}")]
        public async Task<ActionResult<Service>> GetServiceDetailsPage(int id)
        {
            var service = _context.Services
                                           .Include(s => s.Vendor)
                                           .ThenInclude(vend => vend.Vendorcontactdetails)
                                           .Where(s => s.Id == id).FirstOrDefault();
            if (service == null)
            {
                return NotFound();
            }

            return service;
        }

        // GET All Venues
        [HttpGet("AllVenues")]
        public async Task<ActionResult<IEnumerable<Service>>> GetAllVenues()
        {
            return await _context.Services.Where(s => s.ServiceCategoryId == 1).ToListAsync();
        }

        // GET All Catering
        [HttpGet("AllCatering")]
        public async Task<ActionResult<IEnumerable<Service>>> GetAllCatering()
        {
            return await _context.Services.Where(s => s.ServiceCategoryId == 2).ToListAsync();
        }

        // GET All Guest Houses
        [HttpGet("AllGuestHouses")]
        public async Task<ActionResult<IEnumerable<Service>>> GetAllGuestHouses()
        {
            return await _context.Services.Where(s => s.ServiceCategoryId == 3).ToListAsync();
        }

        // GET Photographers
        [HttpGet("AllPhotographer")]
        public async Task<ActionResult<IEnumerable<Service>>> GetAllPhotographer()
        {
            return await _context.Services.Where(s => s.ServiceCategoryId == 4).ToListAsync();
        }

        // GET Parlors/Salons
        [HttpGet("AllParlors")]
        public async Task<ActionResult<IEnumerable<Service>>> GetAllParlors()
        {
            return await _context.Services.Where(s => s.ServiceCategoryId == 5).ToListAsync();
        }



        // PUT: api/Service/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutService(int id, Service service)
        {
            if (id != service.Id)
            {
                return BadRequest();
            }

            _context.Entry(service).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExists(id))
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

        // POST: api/Service
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Service>> PostService(Service service)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetService", new { id = service.Id }, service);
        }

        // DELETE: api/Service/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceExists(int id)
        {
            return _context.Services.Any(e => e.Id == id);
        }
    }
}
