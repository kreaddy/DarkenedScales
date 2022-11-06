using DarkenedScales.Helpers;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.Enums;
using static Kingmaker.UnitLogic.Alignments.AlignmentMaskType;

namespace DarkenedScales
{
    public static class PostPatches
    {
        public static void ApplyAlignmentChange()
        {
            var cue = BPLookup.GetBP<BlueprintCue>("DahakVowCue");

            cue.OnShow.Actions = cue.OnShow.Actions
                .Push(new ChangePlayerAlignment() { CanUnlockAlignment = false, TargetAlignment = Alignment.ChaoticEvil },
                new LockAlignment() { TargetAlignment = Alignment.ChaoticEvil, AlignmentMask = TrueNeutral | ChaoticEvil | ChaoticNeutral | NeutralEvil });
        }
    }
}