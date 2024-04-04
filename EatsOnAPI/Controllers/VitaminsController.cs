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
    public class VitaminsController : ControllerBase
    {
        private readonly EatsOnContext _context;
        private readonly ILogger<DayPlansController> _logger;

        public VitaminsController(EatsOnContext context, ILogger<DayPlansController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Vitamins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vitamin>>> GetVitamins()
        {
            _logger.LogInformation("Получены данные о витаминах");
          if (_context.Vitamins == null)
          {
              return NotFound();
          }
            return await _context.Vitamins.ToListAsync();
        }

        // GET: api/Vitamins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vitamin>> GetVitamin(string id)
        {
          if (_context.Vitamins == null)
          {
              return NotFound();
          }
            var vitamin = await _context.Vitamins.FindAsync(id);

            if (vitamin == null)
            {
                return NotFound();
            }

            return vitamin;
        }

        // PUT: api/Vitamins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVitamin(string id, Vitamin vitamin)
        {
            if (id != vitamin.NameVitamin)
            {
                return BadRequest();
            }

            _context.Entry(vitamin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VitaminExists(id))
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

        // POST: api/Vitamins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vitamin>> PostVitamin(Vitamin vitamin)
        {
          if (_context.Vitamins == null)
          {
              return Problem("Entity set 'EatsOnContext.Vitamins'  is null.");
          }
            _context.Vitamins.Add(vitamin);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VitaminExists(vitamin.NameVitamin))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVitamin", new { id = vitamin.NameVitamin }, vitamin);
        }

        // DELETE: api/Vitamins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVitamin(string id)
        {
            if (_context.Vitamins == null)
            {
                return NotFound();
            }
            var vitamin = await _context.Vitamins.FindAsync(id);
            if (vitamin == null)
            {
                return NotFound();
            }

            _context.Vitamins.Remove(vitamin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VitaminExists(string id)
        {
            return (_context.Vitamins?.Any(e => e.NameVitamin == id)).GetValueOrDefault();
        }
    }
}
