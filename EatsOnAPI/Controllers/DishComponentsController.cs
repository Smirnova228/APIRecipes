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
    public class DishComponentsController : ControllerBase
    {
        private readonly EatsOnContext _context;

        public DishComponentsController(EatsOnContext context)
        {
            _context = context;
        }

        // GET: api/DishComponents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DishComponent>>> GetDishComponents()
        {
          if (_context.DishComponents == null)
          {
              return NotFound();
          }
            return await _context.DishComponents.ToListAsync();
        }

        // GET: api/DishComponents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DishComponent>> GetDishComponent(int id)
        {
          if (_context.DishComponents == null)
          {
              return NotFound();
          }
            var dishComponent = await _context.DishComponents.FindAsync(id);

            if (dishComponent == null)
            {
                return NotFound();
            }

            return dishComponent;
        }

        // PUT: api/DishComponents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDishComponent(int id, DishComponent dishComponent)
        {
            if (id != dishComponent.Number)
            {
                return BadRequest();
            }

            _context.Entry(dishComponent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DishComponentExists(id))
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

        // POST: api/DishComponents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DishComponent>> PostDishComponent(DishComponent dishComponent)
        {
          if (_context.DishComponents == null)
          {
              return Problem("Entity set 'EatsOnContext.DishComponents'  is null.");
          }
            _context.DishComponents.Add(dishComponent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDishComponent", new { id = dishComponent.Number }, dishComponent);
        }

        // DELETE: api/DishComponents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDishComponent(int id)
        {
            if (_context.DishComponents == null)
            {
                return NotFound();
            }
            var dishComponent = await _context.DishComponents.FindAsync(id);
            if (dishComponent == null)
            {
                return NotFound();
            }

            _context.DishComponents.Remove(dishComponent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DishComponentExists(int id)
        {
            return (_context.DishComponents?.Any(e => e.Number == id)).GetValueOrDefault();
        }
    }
}
