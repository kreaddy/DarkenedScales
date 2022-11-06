using Kingmaker.Localization;
using ModMenu.Settings;
using System.Collections.Generic;
using Menu = ModMenu.ModMenu;

namespace DarkenedScales.Helpers
{
    internal static class Settings
    {
        private static readonly string RootKey = "ds.settings";

        private static Dictionary<string, LocalizedString> strings = new();

        internal static bool IsEnabled(string key)
        {
            return Menu.GetSettingValue<bool>(GetKey(key));
        }

        internal static void Initialize()
        {
            var settings = SettingsBuilder.New(RootKey, GetString("DS_S_Title"))
                .AddToggle(Toggle.New(GetKey("ds.alignment"), defaultValue: true, GetString("DS_S_Alignment"))
                .WithLongDescription(GetString("DS_S_Alignment_Desc")));

            Menu.AddSettings(settings);
        }

        private static LocalizedString GetString(string key)
        {
            if (!strings.ContainsKey(key)) strings.Add(key, new LocalizedString() { m_Key = key });
            return strings[key];
        }

        private static string GetKey(string partialKey)
        {
            return $"{RootKey}.{partialKey}";
        }
    }
}