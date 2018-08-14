using StructureMap;
using StructureMap.Configuration.DSL;
using System.Web.Hosting;

namespace HPBFramework.DependencyResolution.Registries
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {
            var dfNamespace = Common.GetValueFromConfig("DefaultNamespace");
            Scan(x =>
            {
                x.Assembly(dfNamespace);
                x.WithDefaultConventions();
                x.IncludeNamespace(dfNamespace + ".Services.IServices");
                x.IncludeNamespace(dfNamespace + ".Services");
                x.SingleImplementationsOfInterface();
            });
        }
    }
}