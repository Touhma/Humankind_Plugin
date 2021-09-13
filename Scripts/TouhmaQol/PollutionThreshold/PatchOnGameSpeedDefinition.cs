namespace Humankind_Mod.PatchTest
{
    using Amplitude.Mercury.Data.Simulation;
    using BepInEx.Logging;
    using HarmonyLib;
    
    [HarmonyPatch(typeof(GameSpeedDefinition))]
    public class PatchOnGameSpeedDefinition
    {
        [HarmonyPostfix]
        [HarmonyPatch("Initialize")]
        public static void Initialize(ref GameSpeedDefinition __instance)
        {
            PatchForPollutions.logger.Log(LogLevel.Warning, "PatchOnGameSpeedDefinition - Initialize");
            PatchForPollutions.logger.Log(LogLevel.Warning,  __instance.DefaultGameSpeedMultiplier);
        }
    }
}
