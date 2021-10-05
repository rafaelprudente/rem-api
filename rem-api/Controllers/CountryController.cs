using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rem_api.Models;
using System.Linq;
using System.Threading.Tasks;

namespace rem_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IApplicationDbContext _context;

        public CountryController(IApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Country country)
        {
            var worldRegion = await _context.WorldRegions.Where(a => country.WorldRegion.Id.Equals(a.Id)).FirstOrDefaultAsync();
            if (worldRegion == null) return NotFound();

            country.WorldRegion = worldRegion;

            _context.Countries.Add(country);
            await _context.SaveChanges();
            return Ok(country.Id);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var countries = await _context.Countries.ToListAsync();
            if (countries == null) return NotFound();
            return Ok(countries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var country = await _context.Countries.Where(a => id.Equals(a.Id)).FirstOrDefaultAsync();
            if (country == null) return NotFound();
            return Ok(country);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var country = await _context.Countries.Where(a => name.Equals(a.Name)).FirstOrDefaultAsync();
            if (country == null) return NotFound();
            return Ok(country);
        }

        [HttpGet("{id}/States")]
        public async Task<IActionResult> GetStates(long id)
        {
            var country = await _context.Countries.Where(a => id.Equals(a.Id)).FirstOrDefaultAsync();
            if (country == null) return NotFound();
            return Ok(country.States);
        }

        [HttpGet("{id}/CountryCurrencyCodes")]
        public async Task<IActionResult> GetCountryCurrencyCodes(long id)
        {
            var country = await _context.Countries.Where(a => id.Equals(a.Id)).FirstOrDefaultAsync();
            if (country == null) return NotFound();
            return Ok(country.CountryCurrencyCodes);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var country = await _context.Countries.Where(a => id.Equals(a.Id)).FirstOrDefaultAsync();
            if (country == null) return NotFound();
            _context.Countries.Remove(country);
            await _context.SaveChanges();
            return Ok(country.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, Country countryUpdate)
        {
            var country = _context.Countries.Where(a => id.Equals(a.Id)).FirstOrDefault();
            if (country == null) return NotFound();
            else
            {
                country.Name = countryUpdate.Name;
                country.NetToGrossRatio = countryUpdate.NetToGrossRatio;
                country.WorldRegion = countryUpdate.WorldRegion;

                await _context.SaveChanges();
                return Ok(country.Id);
            }
        }
    }
}
