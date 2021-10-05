using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rem_api.Models;
using System.Linq;
using System.Threading.Tasks;

namespace rem_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IApplicationDbContext _context;

    public StateController(IApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create(State state)
    {
        _context.States.Add(state);
        await _context.SaveChanges();
        return Ok(state.Id);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var states = await _context.States.ToListAsync();
        if (states == null) return NotFound();
        return Ok(states);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var state = await _context.States.Where(a => id.Equals(a.Id)).FirstOrDefaultAsync();
        if (state == null) return NotFound();
        return Ok(state);
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> GetByName(string name)
    {
        var state = await _context.States.Where(a => name.Equals(a.Name)).FirstOrDefaultAsync();
        if (state == null) return NotFound();
        return Ok(state);
    }

    [HttpGet("{id}/Cities")]
    public async Task<IActionResult> GetCities(long id)
    {
        var state = await _context.States.Where(a => id.Equals(a.Id)).FirstOrDefaultAsync();
        if (state == null) return NotFound();
        return Ok(state.Cities);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var state = await _context.States.Where(a => id.Equals(a.Id)).FirstOrDefaultAsync();
        if (state == null) return NotFound();
        _context.States.Remove(state);
        await _context.SaveChanges();
        return Ok(state.Id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, State stateUpdate)
    {
        var state = _context.States.Where(a => id.Equals(a.Id)).FirstOrDefault();
        if (state == null) return NotFound();
        else
        {
                state.Name = stateUpdate.Name;
                state.Country = stateUpdate.Country;

            await _context.SaveChanges();
            return Ok(state.Id);
        }
    }
}
}
