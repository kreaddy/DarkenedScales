using HarmonyLib;
using Kingmaker.Blueprints.JsonSystem;
using DarkenedScales.Helpers;

namespace DarkenedScales.HarmonyPatches
{
    internal static class BlueprintsCachePatcher
    {
        [HarmonyPatch(typeof(BlueprintsCache), "Init")]
        [HarmonyPriority(Priority.LowerThanNormal)]
        internal class BlueprintsCache_Init_DS
        {
            [HarmonyPostfix]
            private static void DS_Init()
            {
                Settings.Initialize();
                BlueprintLoader.LoadBlueprints();

                if (Settings.IsEnabled("ds.alignment")) PostPatches.ApplyAlignmentChange();
            }
        }
    }
}