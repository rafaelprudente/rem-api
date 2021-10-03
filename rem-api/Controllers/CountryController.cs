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
            var worldRegion = await _context.WorldRegions.Where(a => a.Id == country.WorldRegion.Id).FirstOrDefaultAsync();
            if (worldRegion == null) return NotFound(country.WorldRegion.Id);
            country.WorldRegion = worldRegion;

            foreach (CurrencyCode cc in country.CurrencyCodes.ToList())
            {
                var currencyCode = await _context.CurrencyCodes.Where(a => a.Id == cc.Id).FirstOrDefaultAsync();
                if (currencyCode == null) return NotFound();

                country.CurrencyCodes.Add(currencyCode);
                await _context.SaveChanges();
            }

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
        public async Task<IActionResult> GetById(int id)
        {
            var country = await _context.Countries.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (country == null) return NotFound();
            return Ok(country);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var country = await _context.Countries.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (country == null) return NotFound();
            _context.Countries.Remove(country);
            await _context.SaveChanges();
            return Ok(country.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Country countryUpdate)
        {
            var country = _context.Countries.Where(a => a.Id == id).FirstOrDefault();
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
