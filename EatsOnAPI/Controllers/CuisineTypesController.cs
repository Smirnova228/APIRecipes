using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EatsOnAPI.Models;

namespace EatsOnAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuisineTypesController : ControllerBase
    {
        private readonly EatsOnContext _context;

        public CuisineTypesController(EatsOnContext context)
        {
            _context = context;
        }

        // GET: api/CuisineTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CuisineTypes>>> GetCuisineTypes()
        {
          if (_context.CuisineTypes == null)
          {
              return NotFound();
          }
            return await _context.CuisineTypes.ToListAsync();
        }

        // GET: api/CuisineTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CuisineTypes>> GetCuisineTypes(string id)
        {
          if (_context.CuisineTypes == null)
          {
              return NotFound();
          }
            var cuisineTypes = await _context.CuisineTypes.FindAsync(id);

            if (cuisineTypes == null)
            {
                return NotFound();
            }

            return cuisineTypes;
        }

        // PUT: api/CuisineTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCuisineTypes(string id, CuisineTypes cuisineTypes)
        {
            if (id != cuisineTypes.CuisineName)
            {
                return BadRequest();
            }

            _context.Entry(cuisineTypes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuisineTypesExists(id))
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

        // POST: api/CuisineTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CuisineTypes>> PostCuisineTypes(CuisineTypes cuisineTypes)
        {
          if (_context.CuisineTypes == null)
          {
              return Problem("Entity set 'EatsOnContext.CuisineTypes'  is null.");
          }
            _context.CuisineTypes.Add(cuisineTypes);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CuisineTypesExists(cuisineTypes.CuisineName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCuisineTypes", new { id = cuisineTypes.CuisineName }, cuisineTypes);
        }

        // DELETE: api/CuisineTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuisineTypes(string id)
        {
            if (_context.CuisineTypes == null)
            {
                return NotFound();
            }
            var cuisineTypes = await _context.CuisineTypes.FindAsync(id);
            if (cuisineTypes == null)
            {
                return NotFound();
            }

            _context.CuisineTypes.Remove(cuisineTypes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CuisineTypesExists(string id)
        {
            return (_context.CuisineTypes?.Any(e => e.CuisineName == id)).GetValueOrDefault();
        }
    }
}
