using GymManager.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Persistence.Database
{
    public class ApplicationDbContext
        : IdentityDbContext<User, Role, Guid, IdentityUserClaim<Guid>, UserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) 
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configuraciones adicionales si las necesitas
            // Ejemplo: builder.Entity<User>().Property(u => u.NombreCompleto).IsRequired();
            // Configurar UserRole
            builder.Entity<UserRole>(b =>
            {
                b.HasKey(ur => new { ur.UserId, ur.RoleId });
                b.HasOne(ur => ur.User)
                 .WithMany(u => u.UserRoles)
                 .HasForeignKey(ur => ur.UserId);
                b.HasOne(ur => ur.Role)
                 .WithMany(r => r.UserRoles)
                 .HasForeignKey(ur => ur.RoleId);
            });

            // Configurar RolePermission
            builder.Entity<RolePermission>(b =>
            {
                b.HasKey(rp => new { rp.RoleId, rp.PermissionId });
                b.HasOne(rp => rp.Role)
                 .WithMany(r => r.RolePermissions)
                 .HasForeignKey(rp => rp.RoleId);
                b.HasOne(rp => rp.Permission)
                 .WithMany(p => p.RolePermissions)
                 .HasForeignKey(rp => rp.PermissionId);
            });
        }
    }
}
