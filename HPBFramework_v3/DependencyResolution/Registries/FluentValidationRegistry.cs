using FluentValidation;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace HPBFramework.DependencyResolution.Registries
{
    public class FluentValidationRegistry : Registry
    {
        public FluentValidationRegistry()
        {
            var dfNamespace = Common.GetValueFromConfig("DefaultNamespace");
            Scan(x =>
            {
                x.Assembly(dfNamespace);
                //x.AssembliesAndExecutablesFromApplicationBaseDirectory(a => a.FullName.Contains(dfNamespace));
                x.WithDefaultConventions();
                x.ConnectImplementationsToTypesClosing(typeof (AbstractValidator<>));
            });
        }
    }
}