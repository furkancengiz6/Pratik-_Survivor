using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pratik__Survivor.Context;
using Pratik__Survivor.Entities;

namespace Pratik__Survivor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitorController : ControllerBase
    {

        private readonly SurvivorDbContext _context;
        //Doğrudan bağımlı olmak yerine SurvivorDbContext'in bir öğrneğini constructor aracılığıyla aldık.dependency injection böylelikle veritabanına olan bağılılığı azaltmış olduk.
        public CompetitorController(SurvivorDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompetitorEntity>>> GetCompetitors()
        {
            return await _context.Competitors.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompetitorEntity>> GetCompetitor(int id)
        {
            var competitor = await _context.Competitors.FindAsync(id);
            if (competitor == null) return NotFound();

            return competitor;
        }

        [HttpGet("categories/{categoryId}")]
        public async Task<ActionResult<IEnumerable<CompetitorEntity>>> GetCompetitorsByCategory(int categoryId)
        {
            return await _context.Competitors.Where(x => x.CategoryId == categoryId).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<CompetitorEntity>> PostCompetitor(CompetitorEntity competitor)
        {
            _context.Competitors.Add(competitor);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCompetitor", new { id = competitor.Id }, competitor);


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompetitor(int id, CompetitorEntity competitor)
        {
            if (id != competitor.Id) return BadRequest();

            _context.Entry(competitor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompetitorExists(id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetitor(int id)
        {
            var competitor = await _context.Competitors.FindAsync(id);
            if (competitor == null)
                return NotFound();
            _context.Competitors.Remove(competitor);
            await _context.SaveChangesAsync();
            return NoContent();
        }




        private bool CompetitorExists(int id)
        {
            return _context.Competitors.Any(e => e.Id == id);
        }
    }
}