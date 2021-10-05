using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rem_api.Models;
using System.Linq;
using System.Threading.Tasks;

namespace rem_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyCodeController : ControllerBase
    {
        private readonly IApplicationDbContext _context;

    public CurrencyCodeController(IApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CurrencyCode currencyCode)
    {
        _context.CurrencyCodes.Add(currencyCode);
        await _context.SaveChanges();
        return Ok(currencyCode.Id);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var currencyCodes = await _context.CurrencyCodes.ToListAsync();
        if (currencyCodes == null) return NotFound();
        return Ok(currencyCodes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var currencyCode = await _context.CurrencyCodes.Where(a => id.Equals(a.Id)).FirstOrDefaultAsync();
        if (currencyCode == null) return NotFound();
        return Ok(currencyCode);
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> GetByName(string name)
    {
        var currencyCode = await _context.CurrencyCodes.Where(a => name.Equals(a.Name)).FirstOrDefaultAsync();
        if (currencyCode == null) return NotFound();
        return Ok(currencyCode);
    }

    [HttpGet("{id}/CountryCurrencyCodes")]
    public async Task<IActionResult> GetCountryCurrencyCodes(long id)
    {
        var currencyCode = await _context.CurrencyCodes.Where(a => id.Equals(a.Id)).FirstOrDefaultAsync();
        if (currencyCode == null) return NotFound();
        return Ok(currencyCode.CountryCurrencyCodes);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var currencyCode = await _context.CurrencyCodes.Where(a => id.Equals(a.Id)).FirstOrDefaultAsync();
        if (currencyCode == null) return NotFound();
        _context.CurrencyCodes.Remove(currencyCode);
        await _context.SaveChanges();
        return Ok(currencyCode.Id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, CurrencyCode currencyCodeUpdate)
    {
        var currencyCode = _context.CurrencyCodes.Where(a => id.Equals(a.Id)).FirstOrDefault();
        if (currencyCode == null) return NotFound();
        else
        {
                currencyCode.Name = currencyCodeUpdate.Name;
                currencyCode.CharacterCode = currencyCodeUpdate.CharacterCode;
                currencyCode.NumericCode = currencyCodeUpdate.NumericCode;
                currencyCode.DecimalPlaces = currencyCodeUpdate.DecimalPlaces;

            await _context.SaveChanges();
            return Ok(currencyCode.Id);
        }
    }
}
}
