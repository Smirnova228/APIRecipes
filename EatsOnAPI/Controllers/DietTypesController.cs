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
    public class DietTypesController : ControllerBase
    {
        private readonly EatsOnContext _context;

        public DietTypesController(EatsOnContext context)
        {
            _context = context;
        }

        // GET: api/DietTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DietTypes>>> GetDietTypes()
        {
          if (_context.DietTypes == null)
          {
              return NotFound();
          }
            return await _context.DietTypes.ToListAsync();
        }

        // GET: api/DietTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DietTypes>> GetDietTypes(string id)
        {
          if (_context.DietTypes == null)
          {
              return NotFound();
          }
            var dietTypes = await _context.DietTypes.FindAsync(id);

            if (dietTypes == null)
            {
                return NotFound();
            }

            return dietTypes;
        }

        // PUT: api/DietTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDietTypes(string id, DietTypes dietTypes)
        {
            if (id != dietTypes.DietTypeName)
            {
                return BadRequest();
            }

            _context.Entry(dietTypes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DietTypesExists(id))
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

        // POST: api/DietTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DietTypes>> PostDietTypes(DietTypes dietTypes)
        {
          if (_context.DietTypes == null)
          {
              return Problem("Entity set 'EatsOnContext.DietTypes'  is null.");
          }
            _context.DietTypes.Add(dietTypes);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DietTypesExists(dietTypes.DietTypeName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDietTypes", new { id = dietTypes.DietTypeName }, dietTypes);
        }

        // DELETE: api/DietTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDietTypes(string id)
        {
            if (_context.DietTypes == null)
            {
                return NotFound();
            }
            var dietTypes = await _context.DietTypes.FindAsync(id);
            if (dietTypes == null)
            {
                return NotFound();
            }

            _context.DietTypes.Remove(dietTypes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DietTypesExists(string id)
        {
            return (_context.DietTypes?.Any(e => e.DietTypeName == id)).GetValueOrDefault();
        }
    }
}
