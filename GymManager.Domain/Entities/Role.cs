using GymManager.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace GymManager.Domain.Entities
{
    public class Role
        : IdentityRole<Guid>, IAuditableEntity
    {
        public DateTime Creado { get; set; } = DateTime.Now;
        public string CreadoPor { get; set; } = string.Empty;
        public DateTime Modificado { get; set; } = DateTime.Now;
        public string ModificadoPor { get; set; } = string.Empty;
        public bool Vigente { get; set; } = true;
        public DateTime VigenteDesde { get; set; } = DateTime.Now;
        public DateTime VigenteHasta { get; set; } = new DateTime(2999, 12, 31, 23, 59, 59).AddMilliseconds(999999);

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    }
}
