using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace rem_api.Models
{
    public interface IApplicationDbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<BusinessUnit> BusinessUnits { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CurrencyCode> CurrencyCodes { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<WorldRegion> WorldRegions { get; set; }

        Task<int> SaveChanges();
    }
}