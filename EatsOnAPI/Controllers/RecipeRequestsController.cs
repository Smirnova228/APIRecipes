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
    public class RecipeRequestsController : ControllerBase
    {
        private readonly EatsOnContext _context;

        public RecipeRequestsController(EatsOnContext context)
        {
            _context = context;
        }

        // GET: api/RecipeRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeRequest>>> GetRecipeRequests()
        {
          if (_context.RecipeRequests == null)
          {
              return NotFound();
          }
            return await _context.RecipeRequests.ToListAsync();
        }

        // GET: api/RecipeRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeRequest>> GetRecipeRequest(int id)
        {
          if (_context.RecipeRequests == null)
          {
              return NotFound();
          }
            var recipeRequest = await _context.RecipeRequests.FindAsync(id);

            if (recipeRequest == null)
            {
                return NotFound();
            }

            return recipeRequest;
        }

        // PUT: api/RecipeRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipeRequest(int id, RecipeRequest recipeRequest)
        {
            if (id != recipeRequest.IdRecipeRequest)
            {
                return BadRequest();
            }

            _context.Entry(recipeRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeRequestExists(id))
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

        // POST: api/RecipeRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RecipeRequest>> PostRecipeRequest(RecipeRequest recipeRequest)
        {
          if (_context.RecipeRequests == null)
          {
              return Problem("Entity set 'EatsOnContext.RecipeRequests'  is null.");
          }
            _context.RecipeRequests.Add(recipeRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecipeRequest", new { id = recipeRequest.IdRecipeRequest }, recipeRequest);
        }

        // DELETE: api/RecipeRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipeRequest(int id)
        {
            if (_context.RecipeRequests == null)
            {
                return NotFound();
            }
            var recipeRequest = await _context.RecipeRequests.FindAsync(id);
            if (recipeRequest == null)
            {
                return NotFound();
            }

            _context.RecipeRequests.Remove(recipeRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecipeRequestExists(int id)
        {
            return (_context.RecipeRequests?.Any(e => e.IdRecipeRequest == id)).GetValueOrDefault();
        }
    }
}
