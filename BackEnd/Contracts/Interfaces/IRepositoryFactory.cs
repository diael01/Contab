namespace Contracts.Interfaces
{
    public interface IRepositoryFactory
    {
        T GetRepository<T>() where T : class;
    }
}
