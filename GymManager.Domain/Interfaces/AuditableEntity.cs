namespace GymManager.Domain.Interfaces
{
    public abstract class AuditableEntity<T> : IEntity<T>
    {
        protected AuditableEntity() : this(
        DateTime.Now,
        string.Empty,
        DateTime.Now,
        string.Empty,
        true,
        DateTime.Now,
        new DateTime(2999, 12, 31, 23, 59, 59).AddMilliseconds(999999)
        )
        {
        }

        protected AuditableEntity(DateTime creado, string creadoPor, DateTime modificado, string modificadoPor, bool vigente, DateTime vigenteDesde, DateTime vigenteHasta)
        {
            Creado = creado;
            CreadoPor = creadoPor;
            Modificado = modificado;
            ModificadoPor = modificadoPor;
            Vigente = vigente;
            VigenteDesde = vigenteDesde;
            VigenteHasta = vigenteHasta;
        }
        /// <summary>
        /// Fecha y hora de creación de la entidad
        /// </summary>
        public DateTime Creado { get; protected set; }

        /// <summary>
        /// ID de la cuenta de usuario que creó esta entidad
        /// </summary>
        public string CreadoPor { get; protected set; }

        /// <summary>
        /// Fecha y hora de última modificación de la entidad
        /// </summary>
        public DateTime Modificado { get; protected set; }

        /// <summary>
        /// ID de la cuenta de usuario que modificó por última vez esta entidad
        /// </summary>
        public string ModificadoPor { get; protected set; }

        /// <summary>
        /// Indica si esta entidad se encuentra vigente
        /// </summary>
        public bool Vigente { get; protected set; }

        /// <summary>
        /// Fecha y hora en que esta entidad empieza a ser operativa en el sistema
        /// </summary>
        public DateTime VigenteDesde { get; protected set; }

        /// <summary>
        /// Fecha y hora en que esta entidad dejó de ser operativa en el sistema
        /// </summary>
        public DateTime VigenteHasta { get; protected set; }

        public T Id { get; protected set; }
    }
}
