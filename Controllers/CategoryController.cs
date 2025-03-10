using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pratik__Survivor.Context;
using Pratik__Survivor.Entities;

namespace Pratik__Survivor.Controllers
{
    
    namespace SurvivorAPI.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class CategoryController : ControllerBase
        {
            private readonly SurvivorDbContext _context;

            public CategoryController(SurvivorDbContext context)
            {
                _context = context;
            }

            // GET: api/Category
            [HttpGet]
            public async Task<ActionResult<IEnumerable<CategoryEntity>>> GetCategories()
            {
                return await _context.Categories.ToListAsync();
            }

            // GET: api/Category/5
            [HttpGet("{id}")]
            public async Task<ActionResult<CategoryEntity>> GetCategory(int id)
            {
                var category = await _context.Categories.FindAsync(id);

                if (category == null)
                {
                    return NotFound();
                }

                return category;
            }

            // POST: api/Category
            [HttpPost]
            public async Task<ActionResult<CategoryEntity>> PostCategory(CategoryEntity category)
            {
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCategory", new { id = category.Id }, category);
            }

            // PUT: api/Category/5
            [HttpPut("{id}")]
            public async Task<IActionResult> PutCategory(int id, CategoryEntity category)
            {
                if (id != category.Id)
                {
                    return BadRequest();
                }

                _context.Entry(category).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(id))
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

            // DELETE: api/Category/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteCategory(int id)
            {
                var category = await _context.Categories.FindAsync(id);
                if (category == null)
                {
                    return NotFound();
                }

                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool CategoryExists(int id)
            {
                return _context.Categories.Any(e => e.Id == id);
            }
        }
    }
}
