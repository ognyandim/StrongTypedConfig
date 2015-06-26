namespace AppWithStrongTypedConfig.Configuration
{
    public interface IEnvironmentSettings
    {
        string EnvironmentSetting1 { get; set; }
        int EnvironmentSetting2 { get; set; }

        long EnvironmentSettingWhichChanges { get; set; }
    }
}