using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rem_api.Models;
using System.Linq;
using System.Threading.Tasks;

namespace rem_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorldRegionController : ControllerBase
    {
        private readonly IApplicationDbContext _context;

    public WorldRegionController(IApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create(WorldRegion worldRegion)
    {
        _context.WorldRegions.Add(worldRegion);
        await _context.SaveChanges();
        return Ok(worldRegion.Id);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var worldRegions = await _context.WorldRegions.ToListAsync();
        if (worldRegions == null) return NotFound();
        return Ok(worldRegions);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var worldRegion = await _context.WorldRegions.Where(a => id.Equals(a.Id)).FirstOrDefaultAsync();
        if (worldRegion == null) return NotFound();
        return Ok(worldRegion);
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> GetByName(string name)
    {
        var worldRegion = await _context.WorldRegions.Where(a => name.Equals(a.Name)).FirstOrDefaultAsync();
        if (worldRegion == null) return NotFound();
        return Ok(worldRegion);
    }

    [HttpGet("{id}/Countries")]
    public async Task<IActionResult> GetCountries(long id)
    {
        var worldRegion = await _context.WorldRegions.Where(a => id.Equals(a.Id)).FirstOrDefaultAsync();
        if (worldRegion == null) return NotFound();
        return Ok(worldRegion.Countries);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var worldRegion = await _context.WorldRegions.Where(a => id.Equals(a.Id)).FirstOrDefaultAsync();
        if (worldRegion == null) return NotFound();
        _context.WorldRegions.Remove(worldRegion);
        await _context.SaveChanges();
        return Ok(worldRegion.Id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, WorldRegion worldRegionUpdate)
    {
        var worldRegion = _context.WorldRegions.Where(a => id.Equals(a.Id)).FirstOrDefault();
        if (worldRegion == null) return NotFound();
        else
        {
                worldRegion.Name = worldRegionUpdate.Name;

            await _context.SaveChanges();
            return Ok(worldRegion.Id);
        }
    }
}
}
