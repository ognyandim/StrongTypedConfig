using System;
using AppWithStrongTypedConfig.Configuration;
using AppWithStrongTypedConfig.ModuleOne.Interfaces;

namespace AppWithStrongTypedConfig.ModuleOne
{
    public class ProgramServiceConfigDependent : IProgramServiceConfigDependent
    {
        private readonly IApplicationConfiguration _applicationConfiguration;
        private readonly IConsoleSettings _consoleSettings;
        private readonly IEnvironmentSettings _envSettings;

        public ProgramServiceConfigDependent(
            IConsoleSettings consoleSettings,
            IEnvironmentSettings envSettings,
            IApplicationConfiguration applicationConfiguration)
        {
            _consoleSettings = consoleSettings;
            _envSettings = envSettings;
            _applicationConfiguration = applicationConfiguration;
        }

        public void ConfigDependentAction()
        {
            Console.WriteLine("Doing stuff.");
            Console.WriteLine("Console setting 1 :" + _consoleSettings.ConsoleSetting1);
            Console.WriteLine("Console setting 2 :" + _consoleSettings.ConsoleSetting2);

            Console.WriteLine("Environment setting 2 :" + _envSettings.EnvironmentSetting1);
            Console.WriteLine("Environment setting 2 :" + _envSettings.EnvironmentSetting2);
            Console.WriteLine("Environment setting which changes with time :" +
                              _envSettings.EnvironmentSettingWhichChanges);

            Console.WriteLine("Application setting 1 :" + _applicationConfiguration.EnableNewsletterSignup);
        }
    }
}