namespace Humankind_Mod.PatchTest.EraStarRequirements
{
    using Amplitude.Mercury.Data.Simulation;
    using HarmonyLib;

    [HarmonyPatch(typeof(PollutionDefinition))]
    public class PatchOnPollutionDefinition
    {
        [HarmonyPostfix]
        [HarmonyPatch("Initialize")]
        public static void Initialize(ref PollutionDefinition __instance)
        {
           
        }
    }
    
}
