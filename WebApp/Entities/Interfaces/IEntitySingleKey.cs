namespace Entities.Interfaces
{
    public interface IEntitySingleKey<T> : IEntity
    {
        public T Id { get; set; }
    }
}