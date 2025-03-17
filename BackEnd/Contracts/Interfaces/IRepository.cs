namespace Contracts.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IList<T> Get(Func<T, bool> where);
    }
}
