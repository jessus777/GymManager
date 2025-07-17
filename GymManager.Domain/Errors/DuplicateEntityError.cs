using GymManager.Domain.Resources;

namespace GymManager.Domain.Errors;

public sealed class DuplicateEntityError 
    : DomainError
{
    public DuplicateEntityError(object identifier)
    {
        Identifier = identifier;
        Message = Strings.ElementoDuplicado;
        Detail = string.Format(Strings.YaExisteElementoX, identifier);
    }

    public object Identifier { get; }
}