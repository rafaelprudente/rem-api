using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rem_api.Models;
using System.Linq;
using System.Threading.Tasks;

namespace rem_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IApplicationDbContext _context;

    public CompanyController(IApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Company company)
    {
        _context.Companies.Add(company);
        await _context.SaveChanges();
        return Ok(company.Id);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var companies = await _context.Companies.ToListAsync();
        if (companies == null) return NotFound();
        return Ok(companies);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var company = await _context.Companies.Where(a => id.Equals(a.Id)).FirstOrDefaultAsync();
        if (company == null) return NotFound();
        return Ok(company);
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> GetByName(string name)
    {
        var company = await _context.Companies.Where(a => name.Equals(a.Name)).FirstOrDefaultAsync();
        if (company == null) return NotFound();
        return Ok(company);
    }

    [HttpGet("{id}/BusinessUnits")]
    public async Task<IActionResult> GetBusinessUnits(long id)
    {
        var company = await _context.Companies.Where(a => id.Equals(a.Id)).FirstOrDefaultAsync();
        if (company == null) return NotFound();
        return Ok(company.BusinessUnits);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var company = await _context.Companies.Where(a => id.Equals(a.Id)).FirstOrDefaultAsync();
        if (company == null) return NotFound();
        _context.Companies.Remove(company);
        await _context.SaveChanges();
        return Ok(company.Id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, Company companyUpdate)
    {
        var company = _context.Companies.Where(a => id.Equals(a.Id)).FirstOrDefault();
        if (company == null) return NotFound();
        else
        {
                company.Name = companyUpdate.Name;

            await _context.SaveChanges();
            return Ok(company.Id);
        }
    }
}
}
