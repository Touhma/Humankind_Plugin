namespace Humankind_Mod.PatchTest.EraStarRequirements
{
    using Amplitude;
    using Amplitude.Framework;
    using Amplitude.Framework.Game;
    using Amplitude.Mercury.Data.Scenario;
    using Amplitude.Mercury.Data.Simulation;
    using HarmonyLib;
    using GameManager = Amplitude.Mercury.Game.GameManager;
    using LogLevel = BepInEx.Logging.LogLevel;

    [HarmonyPatch(typeof(GameManager))]
    public class PatchOnGameManager
    {
        [HarmonyPostfix]
        [HarmonyPatch("UpdateEraDefinition")]
        public static void UpdateEraDefinition(ref EraDefinition __result)
        {
            PatchForEraStarsRequirements.logger.Log(LogLevel.Warning, "UpdateEraDefinition");
            PatchForEraStarsRequirements.logger.Log(LogLevel.Warning, __result.EraStarsCountEvolutionRequirement.RawValue);
            PatchForEraStarsRequirements.logger.Log(LogLevel.Warning, __result.EraIndex);
        }

        [HarmonyPostfix]
        [HarmonyPatch("LoadScenarioDatabase")]
        public static void LoadScenarioDatabase(GameScenarioDefinition scenarioDefinition)
        {
            PatchForEraStarsRequirements.logger.Log(LogLevel.Warning, "LoadScenarioDatabase");
            EraDefinition[] eras = Databases.GetDatabase<EraDefinition>().GetValues();
            foreach (EraDefinition eraDefinition in eras)
            {
                PatchForEraStarsRequirements.logger.Log(LogLevel.Warning, "Log Era Def data :" + eraDefinition.EraIndex + eraDefinition.EraStarsCountEvolutionRequirement.RawValue);
            }
        }
        
        [HarmonyPostfix]
        [HarmonyPatch("OnGameChange")]
        public static void OnGameChange(ref GameChangeEventArgs e, ref GameManager __instance)
        {
            PatchForEraStarsRequirements.logger.Log(LogLevel.Warning, "OnGameChange : "+ e.Action);
            if (e.Action != GameChangeAction.Starting)
            {
                return;
            }
            PatchForEraStarsRequirements.logger.Log(LogLevel.Warning, "OnGameChange :  GameChangeAction.Starting");
           
        }
    }
}
