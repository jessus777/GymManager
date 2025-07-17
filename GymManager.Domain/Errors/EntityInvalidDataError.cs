using GymManager.Domain.Resources;

namespace GymManager.Domain.Errors
{
    public sealed class EntityInvalidDataError 
        : DomainError
    {
        public EntityInvalidDataError(object identifier, List<string> errors)
        {
            Identifier = identifier;
            Message = Strings.ElementoConflicto;
            Detail = Strings.ErrorValidacionDatos;
            CausedBy(errors);
        }

        public object Identifier { get; }
        public List<string> Errors { get; } = [];
    }
}