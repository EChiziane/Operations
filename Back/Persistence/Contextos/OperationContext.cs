using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contextos
{
    public class OperationContext : DbContext

    {
        public OperationContext(DbContextOptions<OperationContext> options) : base(options)
        {
        }

        public DbSet<IdentityCard> IdentityCards { get; set; }

        public DbSet<Operation> Operations { get; set; }

        public DbSet<OperationType> OperationTypes { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialType> MaterialTypes { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<CarLoad> CarLoads { get; set; }
    }
}