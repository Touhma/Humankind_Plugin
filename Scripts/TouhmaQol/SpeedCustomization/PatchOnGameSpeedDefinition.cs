namespace Humankind_Mod.PatchTest
{
    using Amplitude.Mercury.Data.Simulation;
    using HarmonyLib;
    using Models;
    using LogLevel = BepInEx.Logging.LogLevel;
    using Patch = PatchForSpeedCustomization;
    [HarmonyPatch(typeof(GameSpeedDefinition))]
    public class PatchOnGameSpeedDefinition
    {
        [HarmonyPostfix]
        [HarmonyPatch("Initialize")]
        public static void Initialize(ref GameSpeedDefinition __instance)
        {
            //Patch.logger.Log(LogLevel.Warning, "Vanilla DefaultGameSpeedMultiplier : " + __instance.DefaultGameSpeedMultiplier);

            __instance.DefaultGameSpeedMultiplier /= __instance.DefaultGameSpeedMultiplier;
            __instance.DefaultGameSpeedMultiplier *= SpeedValues.gameSpeedValues[VanillaSpeedValues.gameSpeedValues[(float) __instance.DefaultGameSpeedMultiplier * 1]].gameSpeedMultiplier;
            
            __instance.ProductionCostMultiplier /= __instance.ProductionCostMultiplier;
            __instance.ProductionCostMultiplier *= SpeedValues.gameSpeedValues[VanillaSpeedValues.gameSpeedValues[(float) __instance.DefaultGameSpeedMultiplier * 1]].productionCostMultiplier;

            __instance.MoneyInstantCostMultiplier /= __instance.MoneyInstantCostMultiplier;
            __instance.MoneyInstantCostMultiplier *= SpeedValues.gameSpeedValues[VanillaSpeedValues.gameSpeedValues[(float) __instance.DefaultGameSpeedMultiplier * 1]].moneyInstantCostMultiplier;

            __instance.InfluenceInstantCostMultiplier /= __instance.InfluenceInstantCostMultiplier;
            __instance.InfluenceInstantCostMultiplier *= SpeedValues.gameSpeedValues[VanillaSpeedValues.gameSpeedValues[(float) __instance.DefaultGameSpeedMultiplier * 1]].influenceInstantCostMultiplier;

            __instance.PopulationInstantCostMultiplier /= __instance.PopulationInstantCostMultiplier;
            __instance.PopulationInstantCostMultiplier *= SpeedValues.gameSpeedValues[VanillaSpeedValues.gameSpeedValues[(float) __instance.DefaultGameSpeedMultiplier * 1]].populationInstantCostMultiplier;

            __instance.TechnologyCostMultiplier /= __instance.TechnologyCostMultiplier;
            __instance.TechnologyCostMultiplier *= SpeedValues.gameSpeedValues[VanillaSpeedValues.gameSpeedValues[(float) __instance.DefaultGameSpeedMultiplier * 1]].technologyCostMultiplier;
        }
    }
}
