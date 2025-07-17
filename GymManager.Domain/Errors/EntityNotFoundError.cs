using GymManager.Domain.Resources;

namespace GymManager.Domain.Errors;

public sealed class EntityNotFoundError
    : DomainError
{
    public EntityNotFoundError(object identifier)
    {
        Identifier = identifier;
        Message = Strings.ElementoNoEncontrado;
        Detail = string.Format(Strings.NoSeEncontroElementoConId, identifier);
    }

    public object Identifier { get; }
}