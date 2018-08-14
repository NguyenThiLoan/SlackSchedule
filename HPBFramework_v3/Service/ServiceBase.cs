using EntityFramework.DbContextScope.Interfaces;

namespace HPBFramework
{
    public class ServiceBase
    {
        public readonly IDbContextScopeFactory _dbContextScopeFactory;

        public ServiceBase(IDbContextScopeFactory dbContextScopeFactory)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
        }
    }
}