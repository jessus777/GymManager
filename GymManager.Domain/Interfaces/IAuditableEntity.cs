using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Domain.Interfaces
{
    public interface IAuditableEntity
    {
        DateTime Creado { get; set; }
        string CreadoPor { get; set; }
        DateTime Modificado { get; set; }
        string ModificadoPor { get; set; }
        bool Vigente { get; set; }
        DateTime VigenteDesde { get; set; }
        DateTime VigenteHasta { get; set; }
    }
}
