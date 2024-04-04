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
    public class PropertiesController : ControllerBase
    {
        private readonly EatsOnContext _context;

        public PropertiesController(EatsOnContext context)
        {
            _context = context;
        }

        // GET: api/Properties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Property>>> GetProperties()
        {
          if (_context.Properties == null)
          {
              return NotFound();
          }
            return await _context.Properties.ToListAsync();
        }

        // GET: api/Properties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Property>> GetProperty(string id)
        {
          if (_context.Properties == null)
          {
              return NotFound();
          }
            var @property = await _context.Properties.FindAsync(id);

            if (@property == null)
            {
                return NotFound();
            }

            return @property;
        }

        // PUT: api/Properties/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProperty(string id, Property @property)
        {
            if (id != @property.NameProperty)
            {
                return BadRequest();
            }

            _context.Entry(@property).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyExists(id))
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

        // POST: api/Properties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Property>> PostProperty(Property @property)
        {
          if (_context.Properties == null)
          {
              return Problem("Entity set 'EatsOnContext.Properties'  is null.");
          }
            _context.Properties.Add(@property);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PropertyExists(@property.NameProperty))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProperty", new { id = @property.NameProperty }, @property);
        }

        // DELETE: api/Properties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(string id)
        {
            if (_context.Properties == null)
            {
                return NotFound();
            }
            var @property = await _context.Properties.FindAsync(id);
            if (@property == null)
            {
                return NotFound();
            }

            _context.Properties.Remove(@property);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PropertyExists(string id)
        {
            return (_context.Properties?.Any(e => e.NameProperty == id)).GetValueOrDefault();
        }
    }
}
