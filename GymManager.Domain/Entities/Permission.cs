using GymManager.Domain.Interfaces;

namespace GymManager.Domain.Entities
{
    public class Permission
        : AuditableEntity<Guid>
    {
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}
