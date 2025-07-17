using GymManager.Domain.Resources;

namespace GymManager.Domain.Errors;

public sealed class EntityConflictError 
    : DomainError
{
    public EntityConflictError(object identifier, string detail)
    {
        Identifier = identifier;
        Message = Strings.ElementoConflicto;
        Detail = detail;
    }

    public object Identifier { get; }
}