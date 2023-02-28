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
    }
}