using HarmonyLib;
using Kingmaker.Localization;
using DarkenedScales.Helpers;

namespace DarkenedScales.HarmonyPatches
{
    internal class LocalizationManagerPatcher
    {
        [HarmonyPatch(typeof(LocalizationManager), "OnLocaleChanged")]
        internal class LocalizationManager_OnLocaleChanged_DS
        {
            [HarmonyPostfix]
            private static void OnLocaleChanged()
            {
                BlueprintLoader.ApplyLocalization();
            }
        }
    }
}