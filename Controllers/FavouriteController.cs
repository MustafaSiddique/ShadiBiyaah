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
    public class FavouriteController : ControllerBase
    {
        private readonly FypDBContext _context;

        public FavouriteController(FypDBContext context)
        {
            _context = context;
        }

        // GET: api/Favourite
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Favourite>>> GetFavourites()
        {
            return await _context.Favourites.ToListAsync();
        }

        // GET: api/Favourite/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Favourite>> GetFavourite(int id)
        {
            var favourite = await _context.Favourites.FindAsync(id);

            if (favourite == null)
            {
                return NotFound();
            }

            return favourite;
        }

        // GET Favourites by ClientId
        [HttpGet("GetFavouritesOfClient/{id}")]
        public async Task<ActionResult<IEnumerable<Favourite>>> GetFavouritesOfClient(int id)
        {
            return _context.Favourites.Where(f => f.ClientId == id)
                                      .Include(s => s.Service).ToList();
        }

        // PUT: api/Favourite/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavourite(int id, Favourite favourite)
        {
            if (id != favourite.Id)
            {
                return BadRequest();
            }

            _context.Entry(favourite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavouriteExists(id))
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

        // POST: api/Favourite
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Favourite>> PostFavourite(Favourite favourite)
        {
            _context.Favourites.Add(favourite);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FavouriteExists(favourite.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFavourite", new { id = favourite.Id }, favourite);
        }

        // DELETE: api/Favourite/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavourite(int id)
        {
            var favourite = await _context.Favourites.FindAsync(id);
            if (favourite == null)
            {
                return NotFound();
            }

            _context.Favourites.Remove(favourite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FavouriteExists(int id)
        {
            return _context.Favourites.Any(e => e.Id == id);
        }
    }
}
