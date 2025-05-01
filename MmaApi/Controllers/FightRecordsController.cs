using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MmaApi.Data;
using MmaApi.Models;

namespace MmaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FightRecordsController : ControllerBase
    {
        private readonly MmaDbContext _context;

        public FightRecordsController(MmaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FightRecord>>> GetAll()
        {
            var records = await _context.FightRecords
                .Include(fr => fr.Fighter)
                .Include(fr => fr.Opponent)
                .ToListAsync();

            return Ok(records);
        }

        [HttpGet("byfighter/{fighterId}")]
        public async Task<ActionResult<IEnumerable<FightRecord>>> GetByFighter(int fighterId)
        {
            var records = await _context.FightRecords
                .Include(fr => fr.Fighter)
                .Include(fr => fr.Opponent)
                .Where(fr => fr.FighterId == fighterId)
                .ToListAsync();

            return Ok(records);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FightRecord record)
        {
            _context.FightRecords.Add(record);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Fight record added successfully", record });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _context.FightRecords.FindAsync(id);
            if (record == null)
                return NotFound(new { message = "Record not found." });

            _context.FightRecords.Remove(record);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Fight record deleted." });
        }
    }
}
