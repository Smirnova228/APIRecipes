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
    public class PartDaysController : ControllerBase
    {
        private readonly EatsOnContext _context;

        public PartDaysController(EatsOnContext context)
        {
            _context = context;
        }

        // GET: api/PartDays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartDay>>> GetPartDays()
        {
          if (_context.PartDays == null)
          {
              return NotFound();
          }
            return await _context.PartDays.ToListAsync();
        }

        // GET: api/PartDays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PartDay>> GetPartDay(string id)
        {
          if (_context.PartDays == null)
          {
              return NotFound();
          }
            var partDay = await _context.PartDays.FindAsync(id);

            if (partDay == null)
            {
                return NotFound();
            }

            return partDay;
        }

        // PUT: api/PartDays/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartDay(string id, PartDay partDay)
        {
            if (id != partDay.NamePart)
            {
                return BadRequest();
            }

            _context.Entry(partDay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartDayExists(id))
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

        // POST: api/PartDays
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PartDay>> PostPartDay(PartDay partDay)
        {
          if (_context.PartDays == null)
          {
              return Problem("Entity set 'EatsOnContext.PartDays'  is null.");
          }
            _context.PartDays.Add(partDay);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PartDayExists(partDay.NamePart))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPartDay", new { id = partDay.NamePart }, partDay);
        }

        // DELETE: api/PartDays/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartDay(string id)
        {
            if (_context.PartDays == null)
            {
                return NotFound();
            }
            var partDay = await _context.PartDays.FindAsync(id);
            if (partDay == null)
            {
                return NotFound();
            }

            _context.PartDays.Remove(partDay);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PartDayExists(string id)
        {
            return (_context.PartDays?.Any(e => e.NamePart == id)).GetValueOrDefault();
        }
    }
}
