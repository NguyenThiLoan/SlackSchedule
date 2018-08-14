using AutoMapper;
using StructureMap;
using StructureMap.Configuration.DSL;
using System.Web.Hosting;

namespace HPBFramework.DependencyResolution.Registries
{
    public class AutoMapperRegistry : Registry
    {
        public AutoMapperRegistry()
        {
            var dfNamespace = Common.GetValueFromConfig("DefaultNamespace");
            Scan(x =>
            {
                x.Assembly(dfNamespace);
                //x.AssembliesFromPath(HostingEnvironment.MapPath("~/bin/" + dfNamespace+ ".dll"));
                x.WithDefaultConventions();
                x.IncludeNamespace(dfNamespace + ".Models.Dto.MappingProfiles");
                x.AddAllTypesOf<Profile>();
            });
        }
    }
}