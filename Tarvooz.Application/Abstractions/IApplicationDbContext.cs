using Microsoft.EntityFrameworkCore;
using Tarvooz.Domain.Entities.Models;

namespace Tarvooz.Application.Abstractions
{
    public interface IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Verification> Verifications { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
