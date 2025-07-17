namespace GymManager.Domain.Interfaces;
public interface IOperationContextProvider
{
    void SetContext(OperationContext operationContext);
    OperationContext GetContext();
}
