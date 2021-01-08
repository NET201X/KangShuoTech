namespace MainForm.Properties
{
    using System;
    using System.CodeDom.Compiler;
    using System.Configuration;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0"), CompilerGenerated]
    internal sealed class Settings : ApplicationSettingsBase
    {
        private static Settings defaultInstance = ((Settings) SettingsBase.Synchronized(new Settings()));

        public static Settings Default
        {
            get
            {
                return defaultInstance;
            }
        }

        [DefaultSettingValue(@"data source=F:\MainForm\全民健康档案\MainFormMaster\MainForm\bin\Debug\SQlite\MainFormDB.db"), SpecialSetting(SpecialSetting.ConnectionString), ApplicationScopedSetting, DebuggerNonUserCode]
        public string MainFormDBConnectionString
        {
            get
            {
                return (string) this["MainFormDBConnectionString"];
            }
        }
    }
}

