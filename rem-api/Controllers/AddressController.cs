using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rem_api.Models;
using System.Linq;
using System.Threading.Tasks;

namespace rem_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IApplicationDbContext _context;

    public AddressController(IApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Address address)
    {
        _context.Addresses.Add(address);
        await _context.SaveChanges();
        return Ok(address.Id);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var addresses = await _context.Addresses.ToListAsync();
        if (addresses == null) return NotFound();
        return Ok(addresses);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var address = await _context.Addresses.Where(a => id.Equals(a.Id)).FirstOrDefaultAsync();
        if (address == null) return NotFound();
        return Ok(address);
    }





    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var address = await _context.Addresses.Where(a => id.Equals(a.Id)).FirstOrDefaultAsync();
        if (address == null) return NotFound();
        _context.Addresses.Remove(address);
        await _context.SaveChanges();
        return Ok(address.Id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, Address addressUpdate)
    {
        var address = _context.Addresses.Where(a => id.Equals(a.Id)).FirstOrDefault();
        if (address == null) return NotFound();
        else
        {
                address.City = addressUpdate.City;
                address.PostalCode = addressUpdate.PostalCode;
                address.Number = addressUpdate.Number;
                address.Line1 = addressUpdate.Line1;
                address.Line2 = addressUpdate.Line2;
                address.Line3 = addressUpdate.Line3;

            await _context.SaveChanges();
            return Ok(address.Id);
        }
    }
}
}
