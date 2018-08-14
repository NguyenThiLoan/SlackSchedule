using StructureMap;
using StructureMap.Configuration.DSL;

namespace HPBFramework.DependencyResolution.Registries
{
    public class RepositoryRegistry : Registry
    {
        public RepositoryRegistry()
        {
            var dfNamespace = Common.GetValueFromConfig("DefaultNamespace");
            Scan(x =>
            {
                x.Assembly(dfNamespace);
                //x.AssembliesAndExecutablesFromApplicationBaseDirectory(a => a.FullName.Contains(dfNamespace));
                x.WithDefaultConventions();
                x.IncludeNamespace(dfNamespace + ".Models.Repository.IRepository");
                x.IncludeNamespace(dfNamespace + ".Models.Repository");
                x.SingleImplementationsOfInterface();
            });
        }
    }
}