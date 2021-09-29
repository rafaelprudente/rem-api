using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace rem_api.Models
{
    public interface IApplicationDbContext
    {
        DbSet<BusinessUnit> BusinessUnits { get; set; }

        Task<int> SaveChanges();
    }
}