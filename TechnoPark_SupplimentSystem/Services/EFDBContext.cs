using Microsoft.EntityFrameworkCore;
using TechnoPark_SupplimentSystem.Models.Entities;

namespace TechnoPark_SupplimentSystem.Services
{
    public class EFDBContext : DbContext
    {
        public EFDBContext(DbContextOptions options) : base(options) { }
        public DbSet<UserEntities> User { get; set; }
        public DbSet<CategoryEntities> Category { get; set; }
        public DbSet<GlobalSupplierEntities> GlobalSupplier { get; set; }
        public DbSet<LocalSupplierEntities> LocalSupplier { get; set; }
        public DbSet<CurrencyExchangeRateEntities> CurrencyExchangeRate { get; set; }
        public DbSet<SalesEntities> Sales { get; set; }
        public DbSet<CommissionEntities> Commission { get; set; }
    }
}
