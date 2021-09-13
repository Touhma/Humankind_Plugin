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

    [HarmonyPatch(typeof(GameScenarioDefinition))]
    public class PatchOnGameScenarioDefinition
    {
        [HarmonyPostfix]
        [HarmonyPatch("Initialize")]
        public static void Initialize(ref GameScenarioDefinition __instance)
        {
            PatchForEraStarsRequirements.logger.Log(LogLevel.Warning, "GameScenarioDefinition - Initialize");
            foreach (EndGameCondition endGameCondition in __instance.EndConditions)
            {
                PatchForEraStarsRequirements.logger.Log(LogLevel.Warning, endGameCondition);
            }
            foreach (StaticString eraStarName in __instance.EraStarSettings.EraStarNames)
            {
                PatchForEraStarsRequirements.logger.Log(LogLevel.Warning, eraStarName);
            }
        
            

        }

       
    }
}
