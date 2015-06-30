using System;
using System.Collections;
using System.Configuration;
using AppWithStrongTypedConfig.Configuration;
using AppWithStrongTypedConfig.ModuleOne;
using AppWithStrongTypedConfig.ModuleOne.Interfaces;
using Castle.Components.DictionaryAdapter;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace AppWithStrongTypedConfig.CompositionRoot
{
    public class ContainerRegistrar
    {
        internal static WindsorContainer Container { get; set; }

        public static void SetupContainer()
        {
            var container = new WindsorContainer();
            container.AddFacility<TypedFactoryFacility>();

            container.Register(
                Component.For<IConsoleSettings>().UsingFactoryMethod(GetGlobalUserConsoleSettings),
                Component.For<IEnvironmentSettings>()
                    .UsingFactoryMethod(GetLiveEnvironmentSettings)
                    .LifestyleTransient(),
                Component.For<IProgramServiceConfigDependent>()
                    .ImplementedBy<ProgramServiceConfigDependent>()
                    .LifestyleTransient(),
                Component.For<IApplicationConfiguration>()
                    .UsingFactoryMethod(
                        () =>
                            new DictionaryAdapterFactory().GetAdapter<IApplicationConfiguration>(
                                ConfigurationManager.AppSettings))
                    .LifestyleTransient()
                );
            Container = container;
        }

        private static IConsoleSettings GetGlobalUserConsoleSettings(IKernel k, CreationContext c)
        {
            return GlobalUserConsoleSettings.ConsoleSettings;
        }

        private static IEnvironmentSettings GetLiveEnvironmentSettings(IKernel k, CreationContext c)
        {
            var envSet1 = Environment.CurrentDirectory;
            var envSet2 = Environment.OSVersion.Version.Major;

            var envSet3 = DateTime.UtcNow.Ticks;
            var envSet = new DictionaryAdapterFactory().GetAdapter<IEnvironmentSettings>(
                new Hashtable
                {
                    {"EnvironmentSetting1", envSet1},
                    {"EnvironmentSetting2", envSet2},
                    {"EnvironmentSettingWhichChanges", envSet3}
                }
                );

            return envSet;
        }
    }
}