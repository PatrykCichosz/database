using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MmaApi.Data;
using MmaApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MmaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FightersController : ControllerBase
    {
        private readonly MmaDbContext _context;

        public FightersController(MmaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fighter>>> GetAllFighters()
        {
            return await _context.Fighters.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Fighter>> GetFighterById(int id)
        {
            var fighter = await _context.Fighters.FindAsync(id);
            if (fighter == null) return NotFound(new { message = $"Fighter with ID {id} not found." });
            return Ok(fighter);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFighter([FromBody] Fighter fighter)
        {
            if (string.IsNullOrWhiteSpace(fighter.Name)) return BadRequest(new { message = "Fighter name is required." });
            _context.Fighters.Add(fighter);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Fighter created successfully.", fighter });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFighter(int id, [FromBody] Fighter updatedFighter)
        {
            var fighter = await _context.Fighters.FindAsync(id);
            if (fighter == null) return NotFound(new { message = $"Fighter with ID {id} not found." });

            fighter.Name = updatedFighter.Name;
            fighter.WeightClass = updatedFighter.WeightClass;
            fighter.Nationality = updatedFighter.Nationality;
            fighter.Wins = updatedFighter.Wins;
            fighter.Losses = updatedFighter.Losses;
            fighter.Draws = updatedFighter.Draws;
            fighter.FighterImage = updatedFighter.FighterImage;

            await _context.SaveChangesAsync();
            return Ok(new { message = "Fighter updated successfully.", fighter });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFighter(int id)
        {
            var fighter = await _context.Fighters.FindAsync(id);
            if (fighter == null) return NotFound(new { message = $"Fighter with ID {id} not found." });
            _context.Fighters.Remove(fighter);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Fighter deleted successfully." });
        }
    }
}
