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
    public class DayPlansController : ControllerBase
    {
        private readonly EatsOnContext _context;
        private readonly ILogger<DayPlansController> _logger;

        public DayPlansController(EatsOnContext context, ILogger<DayPlansController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/DayPlans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DayPlan>>> GetDayPlans()
        {
            _logger.LogCritical("Критический тестовый лог");
            if (_context.DayPlans == null)
          {
              return NotFound();
          }
            return await _context.DayPlans.ToListAsync();
        }

        // GET: api/DayPlans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DayPlan>> GetDayPlan(int id)
        {
          if (_context.DayPlans == null)
          {
              return NotFound();
          }
            var dayPlan = await _context.DayPlans.FindAsync(id);

            if (dayPlan == null)
            {
                return NotFound();
            }

            return dayPlan;
        }

        // PUT: api/DayPlans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDayPlan(int id, DayPlan dayPlan)
        {
            if (id != dayPlan.NumberPlan)
            {
                return BadRequest();
            }

            _context.Entry(dayPlan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DayPlanExists(id))
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

        // POST: api/DayPlans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DayPlan>> PostDayPlan(DayPlan dayPlan)
        {
          if (_context.DayPlans == null)
          {
              return Problem("Entity set 'EatsOnContext.DayPlans'  is null.");
          }
            _context.DayPlans.Add(dayPlan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDayPlan", new { id = dayPlan.NumberPlan }, dayPlan);
        }

        // DELETE: api/DayPlans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDayPlan(int id)
        {
            if (_context.DayPlans == null)
            {
                return NotFound();
            }
            var dayPlan = await _context.DayPlans.FindAsync(id);
            if (dayPlan == null)
            {
                return NotFound();
            }

            _context.DayPlans.Remove(dayPlan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DayPlanExists(int id)
        {
            return (_context.DayPlans?.Any(e => e.NumberPlan == id)).GetValueOrDefault();
        }
    }
}
