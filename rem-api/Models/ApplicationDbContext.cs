using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rem_api.Models
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<BusinessUnit> BusinessUnits { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CurrencyCode> CurrencyCodes { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<WorldRegion> WorldRegions { get; set; }
        public DbSet<CountryCurrencyCode> CountryCurrencyCodes { get; set; }

        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorldRegion>()
                .HasMany(c => c.Countries)
                .WithOne(e => e.WorldRegion);
            modelBuilder.Entity<CountryCurrencyCode>()
                .HasKey(bc => new { bc.CountryId, bc.CurrencyCodeId });
            modelBuilder.Entity<CountryCurrencyCode>()
                .HasOne(bc => bc.Country)
                .WithMany(b => b.CountryCurrencyCodes)
                .HasForeignKey(bc => bc.CountryId);
            modelBuilder.Entity<CountryCurrencyCode>()
                .HasOne(bc => bc.CurrencyCode)
                .WithMany(c => c.CountryCurrencyCodes)
                .HasForeignKey(bc => bc.CurrencyCodeId);
        }
    }
}
