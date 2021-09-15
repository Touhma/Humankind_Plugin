namespace Humankind_Mod.PatchTest
{
    using Amplitude.Mercury.Data.Simulation;
    using Amplitude.Mercury.Simulation;
    using HarmonyLib;
    using LogLevel = BepInEx.Logging.LogLevel;
    using Patch = PatchForSpeedCustomization;
    
    [HarmonyPatch(typeof(GameSpeedController))]
    public class PatchOnGameSpeedController
    {
       
        [HarmonyPostfix]
        [HarmonyPatch("InitializeOnLoad")]
        public static void InitializeOnLoad(ref GameSpeedController __instance, ref GameSpeedDefinition ___CurrentGameSpeedDefinition)
        {
            GetGameSpeedOptions(__instance, ___CurrentGameSpeedDefinition);
        }

        private static void GetGameSpeedOptions(GameSpeedController __instance, GameSpeedDefinition ___CurrentGameSpeedDefinition)
        {
            Patch.logger.Log(LogLevel.Warning, "GetGameSpeedOptions DefaultGameSpeedMultiplier: " + ___CurrentGameSpeedDefinition.DefaultGameSpeedMultiplier);
            Patch.logger.Log(LogLevel.Warning, "GetGameSpeedOptions TechnologyCostMultiplier: " + ___CurrentGameSpeedDefinition.TechnologyCostMultiplier);
            Patch.logger.Log(LogLevel.Warning, "GetGameSpeedOptions ProductionCostMultiplier: " + ___CurrentGameSpeedDefinition.ProductionCostMultiplier);
            Patch.logger.Log(LogLevel.Warning, "GetGameSpeedOptions MoneyInstantCostMultiplier: " + ___CurrentGameSpeedDefinition.MoneyInstantCostMultiplier);
            Patch.logger.Log(LogLevel.Warning, "GetGameSpeedOptions InfluenceInstantCostMultiplier: " + ___CurrentGameSpeedDefinition.InfluenceInstantCostMultiplier);
        }
    }
    
    
    
}
