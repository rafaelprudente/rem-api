using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rem_api.Models;
using System.Collections.Generic;
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

            List<CountryCurrencyCode> countryCurrencyCodesList = new List<CountryCurrencyCode>();
            foreach (CountryCurrencyCode ccc in country.CountryCurrencyCodes.ToList())
            {
                var currencyCode = await _context.CurrencyCodes.Where(a => a.Id == ccc.CurrencyCodeId).FirstOrDefaultAsync();
                if (currencyCode == null) return NotFound(ccc.CurrencyCodeId);

                countryCurrencyCodesList.Add(new CountryCurrencyCode { CurrencyCodeId = currencyCode.Id, CurrencyCode = currencyCode });
            }

            country.WorldRegion = worldRegion;
            var dbCountry = _context.Countries.Add(country);
            await _context.SaveChanges();

            foreach (CountryCurrencyCode ccc in countryCurrencyCodesList)
            {
                ccc.CountryId = dbCountry.Entity.Id;
                ccc.Country = dbCountry.Entity;
            }
            dbCountry.Entity.CountryCurrencyCodes = countryCurrencyCodesList;

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
