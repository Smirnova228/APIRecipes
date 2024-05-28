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
    public class RequestIngredientsController : ControllerBase
    {
        private readonly EatsOnContext _context;

        public RequestIngredientsController(EatsOnContext context)
        {
            _context = context;
        }

        // GET: api/RequestIngredients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestIngredient>>> GetRequestIngredient()
        {
          if (_context.RequestIngredient == null)
          {
              return NotFound();
          }
            return await _context.RequestIngredient.ToListAsync();
        }

        // GET: api/RequestIngredients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestIngredient>> GetRequestIngredient(int id)
        {
          if (_context.RequestIngredient == null)
          {
              return NotFound();
          }
            var requestIngredient = await _context.RequestIngredient.FindAsync(id);

            if (requestIngredient == null)
            {
                return NotFound();
            }

            return requestIngredient;
        }

        // PUT: api/RequestIngredients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequestIngredient(int id, RequestIngredient requestIngredient)
        {
            if (id != requestIngredient.IDRequestIngredient)
            {
                return BadRequest();
            }

            _context.Entry(requestIngredient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestIngredientExists(id))
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

        // POST: api/RequestIngredients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RequestIngredient>> PostRequestIngredient(RequestIngredient requestIngredient)
        {
          if (_context.RequestIngredient == null)
          {
              return Problem("Entity set 'EatsOnContext.RequestIngredient'  is null.");
          }
            _context.RequestIngredient.Add(requestIngredient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequestIngredient", new { id = requestIngredient.IDRequestIngredient }, requestIngredient);
        }

        // DELETE: api/RequestIngredients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequestIngredient(int id)
        {
            if (_context.RequestIngredient == null)
            {
                return NotFound();
            }
            var requestIngredient = await _context.RequestIngredient.FindAsync(id);
            if (requestIngredient == null)
            {
                return NotFound();
            }

            _context.RequestIngredient.Remove(requestIngredient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequestIngredientExists(int id)
        {
            return (_context.RequestIngredient?.Any(e => e.IDRequestIngredient == id)).GetValueOrDefault();
        }
    }
}
