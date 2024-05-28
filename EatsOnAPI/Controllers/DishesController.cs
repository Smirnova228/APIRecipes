using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EatsOnAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Net.Http;
using System.Net.Http.Json;

namespace EatsOnAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly EatsOnContext _context;

        public DishesController(EatsOnContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }

        // GET: api/Dishes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dish>>> GetDishes()
        {
            if (_context.Dishes == null)
            {
                return NotFound();
            }
            return await _context.Dishes.ToListAsync();
        }

        // GET: api/Dishes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dish>> GetDish(int id)
        {
            if (_context.Dishes == null)
            {
                return NotFound();
            }
            var dish = await _context.Dishes.FindAsync(id);

            if (dish == null)
            {
                return NotFound();
            }

            return dish;
        }

        // PUT: api/Dishes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDish(int id, Dish dish)
        {
            if (id != dish.ArticleDish)
            {
                return BadRequest();
            }

            _context.Entry(dish).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DishExists(id))
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

        // POST: api/Dishes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dish>> PostDish(Dish dish)
        {
            if (_context.Dishes == null)
            {
                return Problem("Entity set 'EatsOnContext.Dishes'  is null.");
            }
            _context.Dishes.Add(dish);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDish", new { id = dish.ArticleDish }, dish);
        }

        // DELETE: api/Dishes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDish(int id)
        {
            if (_context.Dishes == null)
            {
                return NotFound();
            }
            var dish = await _context.Dishes.FindAsync(id);
            if (dish == null)
            {
                return NotFound();
            }

            _context.Dishes.Remove(dish);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DishExists(int id)
        {
            return (_context.Dishes?.Any(e => e.ArticleDish == id)).GetValueOrDefault();
        }

        private readonly HttpClient _httpClient;


        [HttpPost("getRecipe")]
        public async Task<IActionResult> GetRecipe([FromBody] RecipeRequ request)
        {
            var response = await _httpClient.PostAsJsonAsync("http://95.165.90.137:10000/recipe/", request);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return Ok(result);
            }
            else
            {
                return StatusCode((int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }


    public class RecipeRequ
    {
        public string Preferences { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string TimeOfDay { get; set; }
    }
}
