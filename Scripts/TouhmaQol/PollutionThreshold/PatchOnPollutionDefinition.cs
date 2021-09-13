namespace Humankind_Mod.PatchTest.EraStarRequirements
{
    using System.Numerics;
    using Amplitude;
    using Amplitude.Mercury;
    using Amplitude.Mercury.Data.Simulation;
    using Amplitude.Mercury.Simulation;
    using HarmonyLib;
    using Models;
    using Scripts.TouhmaQol.PollutionThreshold.Models;
    using LogLevel = BepInEx.Logging.LogLevel;

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
