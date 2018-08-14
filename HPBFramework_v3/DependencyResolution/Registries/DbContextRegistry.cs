using EntityFramework.DbContextScope;
using EntityFramework.DbContextScope.Interfaces;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace HPBFramework.DependencyResolution.Registries
{
    public class DbContextRegistry : Registry
    {
        public DbContextRegistry()
        {
            For<IAmbientDbContextLocator>().Use<AmbientDbContextLocator>();
            For<IDbContextScopeFactory>().Use(new DbContextScopeFactory()).Singleton();
        }
    }
}