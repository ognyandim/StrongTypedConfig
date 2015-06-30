using System;
using System.Collections;
using AppWithStrongTypedConfig.CompositionRoot;
using AppWithStrongTypedConfig.Configuration;
using AppWithStrongTypedConfig.ModuleOne.Interfaces;
using Castle.Components.DictionaryAdapter;

namespace AppWithStrongTypedConfig
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ContainerRegistrar.SetupContainer();
            GetUserSettings();

            var programComponent = ContainerRegistrar.Container.Resolve<IProgramServiceConfigDependent>();

            programComponent.ConfigDependentAction();

            programComponent = ContainerRegistrar.Container.Resolve<IProgramServiceConfigDependent>();

            programComponent.ConfigDependentAction();

            Console.ReadLine();
        }

        private static void GetUserSettings()
        {
            Console.WriteLine("Enter setting 1");
            Console.WriteLine();

            var setting1 = Console.ReadLine();

            Console.WriteLine("Enter int setting 2");
            Console.WriteLine();

            string setting2String = Console.ReadLine();
            int setting2 = Convert.ToInt32(setting2String);

            GlobalUserConsoleSettings.ConsoleSettings = new DictionaryAdapterFactory().GetAdapter<IConsoleSettings>(
                new Hashtable
                {
                    {"ConsoleSetting1", setting1},
                    {"ConsoleSetting2", setting2}
                }
                );
        }
    }
}