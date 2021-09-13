namespace Humankind_Mod.PatchTest.EraStarRequirements
{
    using Amplitude.Mercury.Data.Simulation;
    using HarmonyLib;
    using Models;

    [HarmonyPatch(typeof(EraDefinition))]
    public class PatchOnEraDefinition
    {
        [HarmonyPostfix]
        [HarmonyPatch("Initialize")]
        public static void Initialize(ref EraDefinition __instance)
        {
            __instance.EraStarsCountEvolutionRequirement = EraStarsRequired.starsRequired[(EraIndexModel)__instance.EraIndex];
        }
    }
}
