using System;
using System.Collections;
using AppWithStrongTypedConfig.CompositionRoot;
using AppWithStrongTypedConfig.Configuration;
using Castle.Components.DictionaryAdapter;

namespace AppWithStrongTypedConfig
{
    class Program
    {
        static void Main(string[] args)
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

            string setting1 = Console.ReadLine();

            Console.WriteLine("Enter setting 2");
            Console.WriteLine();

            string setting2 = Console.ReadLine();

            GlobalUserConsoleSettings.ConsoleSettings = new DictionaryAdapterFactory().GetAdapter<IConsoleSettings>(
                new Hashtable() { 
                { "ConsoleSetting1", setting1 }, 
                { "ConsoleSetting2", setting2 } }
                );
        }
    }
}
