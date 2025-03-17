using Contracts.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Repository.Impl
{

    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IServiceProvider _provider;

        public RepositoryFactory(IServiceProvider serviceProvider)
        {
            _provider = serviceProvider;
        }

        public T GetRepository<T>() where T : class
        {
            return _provider.GetRequiredService<T>(); // ERROR: No service for type 'UserRepository' has been registered
        }
    }
}
