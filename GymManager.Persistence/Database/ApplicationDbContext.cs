using GymManager.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Persistence.Database
{
    public class ApplicationDbContext
        : IdentityDbContext<User, Role, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configuraciones adicionales si las necesitas
            // Ejemplo: builder.Entity<User>().Property(u => u.NombreCompleto).IsRequired();
        }
    }
}
