namespace Humankind_Mod.PatchTest
{
    using Amplitude;
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
            Patch.logger.Log(LogLevel.Warning, "Vanilla ProductionCostMultiplier : " + __instance.ProductionCostMultiplier);
            __instance.ProductionCostMultiplier = ReplaceValue(SpeedValues.gameSpeedValues[VanillaSpeedValues.gameSpeedValues[(float) __instance.DefaultGameSpeedMultiplier * 1]].productionCostMultiplier);
            Patch.logger.Log(LogLevel.Warning, "Reworked ProductionCostMultiplier : " + __instance.ProductionCostMultiplier);

            Patch.logger.Log(LogLevel.Warning, "Vanilla MoneyInstantCostMultiplier : " + __instance.MoneyInstantCostMultiplier);
            __instance.MoneyInstantCostMultiplier = ReplaceValue(SpeedValues.gameSpeedValues[VanillaSpeedValues.gameSpeedValues[(float) __instance.DefaultGameSpeedMultiplier * 1]].moneyInstantCostMultiplier);
            Patch.logger.Log(LogLevel.Warning, "Reworked MoneyInstantCostMultiplier : " + __instance.MoneyInstantCostMultiplier);

            Patch.logger.Log(LogLevel.Warning, "Vanilla InfluenceInstantCostMultiplier : " + __instance.InfluenceInstantCostMultiplier);
            __instance.InfluenceInstantCostMultiplier = ReplaceValue(SpeedValues.gameSpeedValues[VanillaSpeedValues.gameSpeedValues[(float) __instance.DefaultGameSpeedMultiplier * 1]].influenceInstantCostMultiplier);
            Patch.logger.Log(LogLevel.Warning, "Reworked InfluenceInstantCostMultiplier : " + __instance.InfluenceInstantCostMultiplier);

            Patch.logger.Log(LogLevel.Warning, "Vanilla PopulationInstantCostMultiplier : " + __instance.PopulationInstantCostMultiplier);
            __instance.PopulationInstantCostMultiplier = ReplaceValue(SpeedValues.gameSpeedValues[VanillaSpeedValues.gameSpeedValues[(float) __instance.DefaultGameSpeedMultiplier * 1]].populationInstantCostMultiplier);
            Patch.logger.Log(LogLevel.Warning, "Reworked PopulationInstantCostMultiplier : " + __instance.PopulationInstantCostMultiplier);

            Patch.logger.Log(LogLevel.Warning, "Vanilla TechnologyCostMultiplier : " + __instance.TechnologyCostMultiplier);
            __instance.TechnologyCostMultiplier= ReplaceValue(SpeedValues.gameSpeedValues[VanillaSpeedValues.gameSpeedValues[(float) __instance.DefaultGameSpeedMultiplier * 1]].technologyCostMultiplier);
            Patch.logger.Log(LogLevel.Warning, "Reworked TechnologyCostMultiplier : " + __instance.TechnologyCostMultiplier);
        }

        private static FixedPoint ReplaceValue(float ratio)
        {
            FixedPoint result = 1;
            result *= ratio;
            return result;
        }
    }
}
