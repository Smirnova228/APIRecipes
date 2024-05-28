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
    public class MealTimesController : ControllerBase
    {
        private readonly EatsOnContext _context;

        public MealTimesController(EatsOnContext context)
        {
            _context = context;
        }

        // GET: api/MealTimes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MealTimes>>> GetMealTimes()
        {
          if (_context.MealTimes == null)
          {
              return NotFound();
          }
            return await _context.MealTimes.ToListAsync();
        }

        // GET: api/MealTimes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MealTimes>> GetMealTimes(string id)
        {
          if (_context.MealTimes == null)
          {
              return NotFound();
          }
            var mealTimes = await _context.MealTimes.FindAsync(id);

            if (mealTimes == null)
            {
                return NotFound();
            }

            return mealTimes;
        }

        // PUT: api/MealTimes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMealTimes(string id, MealTimes mealTimes)
        {
            if (id != mealTimes.MealTimeName)
            {
                return BadRequest();
            }

            _context.Entry(mealTimes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealTimesExists(id))
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

        // POST: api/MealTimes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MealTimes>> PostMealTimes(MealTimes mealTimes)
        {
          if (_context.MealTimes == null)
          {
              return Problem("Entity set 'EatsOnContext.MealTimes'  is null.");
          }
            _context.MealTimes.Add(mealTimes);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MealTimesExists(mealTimes.MealTimeName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMealTimes", new { id = mealTimes.MealTimeName }, mealTimes);
        }

        // DELETE: api/MealTimes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMealTimes(string id)
        {
            if (_context.MealTimes == null)
            {
                return NotFound();
            }
            var mealTimes = await _context.MealTimes.FindAsync(id);
            if (mealTimes == null)
            {
                return NotFound();
            }

            _context.MealTimes.Remove(mealTimes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MealTimesExists(string id)
        {
            return (_context.MealTimes?.Any(e => e.MealTimeName == id)).GetValueOrDefault();
        }
    }
}
