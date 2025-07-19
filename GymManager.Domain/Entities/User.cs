using GymManager.Domain.Enums;
using GymManager.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace GymManager.Domain.Entities
{
    public class User
        : IdentityUser<Guid>, IAuditableEntity
    {
        public DateTime Creado { get; set; } = DateTime.Now;
        public string CreadoPor { get; set; } = string.Empty;
        public DateTime Modificado { get; set; } = DateTime.Now;
        public string ModificadoPor { get; set; } = string.Empty;
        public bool Vigente { get; set; } = true;
        public DateTime VigenteDesde { get; set; } = DateTime.Now;
        public DateTime VigenteHasta { get; set; } = new DateTime(2999, 12, 31, 23, 59, 59).AddMilliseconds(999999);

        // Información Personal
        public string FirstName { get; set; } = default!;        // Nombre(s)
        public string MiddleName { get; set; } = string.Empty;       // Segundo nombre (opcional)
        public string LastName { get; set; } = default!;         // Apellido paterno
        public string SecondLastName { get; set; } = string.Empty;   // Apellido materno

        public DateTime? BirthDate { get; set; }                     // Fecha de nacimiento
        public Gender Gender { get; set; } = Gender.NotSpecified;           // Género
        public string Nationality { get; set; } = string.Empty;      // Nacionalidad

        // Contacto adicional
        public string PhoneNumberAlt { get; set; } = string.Empty;   // Teléfono alternativo
        public string EmergencyContactName { get; set; } = string.Empty; // Nombre de contacto de emergencia
        public string EmergencyContactPhone { get; set; } = string.Empty; // Teléfono de emergencia

        // Dirección
        public string Street { get; set; } = string.Empty;           // Calle
        public string ExteriorNumber { get; set; } = string.Empty;   // Número exterior
        public string InteriorNumber { get; set; } = string.Empty;   // Número interior
        public string Neighborhood { get; set; } = string.Empty;     // Colonia o barrio
        public string Municipality { get; set; } = string.Empty;     // Municipio o delegación
        public string State { get; set; } = string.Empty;            // Estado o provincia
        public string PostalCode { get; set; } = string.Empty;       // Código postal
        public string Country { get; set; } = "México";              // País
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    }
}
