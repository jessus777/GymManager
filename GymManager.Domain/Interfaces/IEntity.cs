namespace GymManager.Domain.Interfaces
{
    public interface IEntity<T>
    {
        T Id { get; }
    }
}
