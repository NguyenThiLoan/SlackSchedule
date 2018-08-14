using HPBFramework.Logger;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace HPBFramework.DependencyResolution.Registries
{
    public class LoggingServiceRegistry : Registry
    {
        public LoggingServiceRegistry()
        {
            For<ILoggingService>().Use(LoggingService.GetLoggingService());
        }
    }
}