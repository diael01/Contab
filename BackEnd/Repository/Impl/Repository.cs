using Contracts.Interfaces;
using Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Impl
{

    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _entity;

        protected Repository(ContabContext dbContext)
        {
            _entity = dbContext.Set<T>();
        }

        public IList<T> Get(Func<T, bool> where)
        {
            return _entity.Where(where).ToList();
        }
    }
}
