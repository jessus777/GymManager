using GymManager.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Domain.Entities
{
    public class UserRole
        : IdentityUserRole<Guid>, IAuditableEntity
    {
        public DateTime Creado { get; set; } = DateTime.Now;
        public string CreadoPor { get; set; } = string.Empty;
        public DateTime Modificado { get; set; } = DateTime.Now;
        public string ModificadoPor { get; set; } = string.Empty;
        public bool Vigente { get; set; } = true;
        public DateTime VigenteDesde { get; set; } = DateTime.Now;
        public DateTime VigenteHasta { get; set; } = new DateTime(2999, 12, 31, 23, 59, 59).AddMilliseconds(999999);
        public User User { get; set; } = default!;
        public Role Role { get; set; } = default!;
    }
}
