using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Corex.Model.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Corex.Sample.Core.Infrastructure
{
    public class DependencyInstaller : IWindsorInstaller
    {
        public const string _mask = "Corex.Sample.*";
        public static string _assemblyDirectoryName { get; } = string.Empty;
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            AssemblyFilter assemblyFilter = new AssemblyFilter(_assemblyDirectoryName, mask: _mask);
            container.Register(
                 Classes.FromAssemblyInDirectory(assemblyFilter)
                     .BasedOn<ISingletonDependecy>()
                     .WithServiceSelect(ServiceSelector).LifestyleSingleton()
                    );
            container.Register(Classes.FromAssemblyInDirectory(assemblyFilter).BasedOn<IScopedDependency>()
                     .WithServiceSelect(ServiceSelector).LifestyleScoped()
                     );
            container.Register(Classes.FromAssemblyInDirectory(assemblyFilter).BasedOn<ITransactionDependecy>()
                     .WithServiceSelect(ServiceSelector).Configure(p => p.LifestyleScoped()));
            container.Register(Classes.FromAssemblyInDirectory(assemblyFilter).BasedOn<ITransientDependecy>()
            .WithServiceSelect(ServiceSelector).Configure(p => p.LifestyleTransient()));
        }
        private static IEnumerable<Type> ServiceSelector(Type type, Type[] baseTypes)
        {
            var result = type.GetInterfaces().ToList();

            result.Add(type);
            return result;
        }
    }
}
