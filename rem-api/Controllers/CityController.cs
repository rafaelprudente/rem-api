using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rem_api.Models;
using System.Linq;
using System.Threading.Tasks;

namespace rem_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IApplicationDbContext _context;

    public CityController(IApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create(City city)
    {
        _context.Cities.Add(city);
        await _context.SaveChanges();
        return Ok(city.Id);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var cities = await _context.Cities.ToListAsync();
        if (cities == null) return NotFound();
        return Ok(cities);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var city = await _context.Cities.Where(a => id.Equals(a.Id)).FirstOrDefaultAsync();
        if (city == null) return NotFound();
        return Ok(city);
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> GetByName(string name)
    {
        var city = await _context.Cities.Where(a => name.Equals(a.Name)).FirstOrDefaultAsync();
        if (city == null) return NotFound();
        return Ok(city);
    }



    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var city = await _context.Cities.Where(a => id.Equals(a.Id)).FirstOrDefaultAsync();
        if (city == null) return NotFound();
        _context.Cities.Remove(city);
        await _context.SaveChanges();
        return Ok(city.Id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, City cityUpdate)
    {
        var city = _context.Cities.Where(a => id.Equals(a.Id)).FirstOrDefault();
        if (city == null) return NotFound();
        else
        {
                city.Name = cityUpdate.Name;
                city.State = cityUpdate.State;

            await _context.SaveChanges();
            return Ok(city.Id);
        }
    }
}
}
