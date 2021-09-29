﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rem_api.Models;
using System.Linq;
using System.Threading.Tasks;

namespace rem_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessUnitController : ControllerBase
    {
        private IApplicationDbContext _context;

        public BusinessUnitController(IApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(BusinessUnit businessUnit)
        {
            _context.BusinessUnits.Add(businessUnit);
            await _context.SaveChanges();
            return Ok(businessUnit.Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var businessUnits = await _context.BusinessUnits.ToListAsync();
            if (businessUnits == null) return NotFound();
            return Ok(businessUnits);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var businessUnit = await _context.BusinessUnits.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (businessUnit == null) return NotFound();
            return Ok(businessUnit);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var businessUnit = await _context.BusinessUnits.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (businessUnit == null) return NotFound();
            _context.BusinessUnits.Remove(businessUnit);
            await _context.SaveChanges();
            return Ok(businessUnit.Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BusinessUnit businessUnitUpdate)
        {
            var businessUnit = _context.BusinessUnits.Where(a => a.Id == id).FirstOrDefault();
            if (businessUnit == null) return NotFound();
            else
            {
                businessUnit.Name = businessUnitUpdate.Name;
                await _context.SaveChanges();
                return Ok(businessUnit.Id);
            }
        }
    }
}
