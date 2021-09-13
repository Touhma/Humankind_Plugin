namespace Humankind_Mod.PatchTest
{
    using Amplitude;
    using Amplitude.Framework.Simulation;
    using Amplitude.Mercury.Data.Simulation;
    using Amplitude.Mercury.Game;
    using Amplitude.Mercury.Simulation;
    using HarmonyLib;
    using Scripts.TouhmaQol.PollutionThreshold.Models;
    using LogLevel = BepInEx.Logging.LogLevel;

    [HarmonyPatch(typeof(PollutionManager))]
    public class PatchOnPollutionManager
    {
        [HarmonyPostfix]
        [HarmonyPatch("InitializeOnLoad")]
        public static void InitializeOnLoad(ref PollutionManager __instance, ref WorldAtmosphere ___WorldAtmosphere, ref PollutionDefinition ___PollutionDefinition)
        {
            GetPollutionOptions(___WorldAtmosphere, ___PollutionDefinition);
        }

        [HarmonyPostfix]
        [HarmonyPatch("InitializeOnStart")]
        public static void InitializeOnStart(ref PollutionManager __instance, ref WorldAtmosphere ___WorldAtmosphere, ref PollutionDefinition ___PollutionDefinition)
        {
            GetPollutionOptions(___WorldAtmosphere, ___PollutionDefinition);
        }

        [HarmonyPrefix]
        [HarmonyPatch("GetEndGamePollutionThreshold")]
        public static bool GetEndGamePollutionThreshold(ref PollutionManager __instance, ref WorldAtmosphere ___WorldAtmosphere, ref PollutionDefinition ___PollutionDefinition, ref FixedPoint __result)
        {
            PatchForPollutions.logger.Log(LogLevel.Warning, "Vanilla Value : " + ___PollutionDefinition.EndGamePollutionThreshold);

            if (___PollutionDefinition.EndGamePollutionThreshold * 1 == 5000)
            {
                __result = GetPollutionThresholdValueReworked(GameSpeed.Blitz);
            }
            else if (___PollutionDefinition.EndGamePollutionThreshold * 1 == 10000)
            {
                __result = GetPollutionThresholdValueReworked(GameSpeed.Fast);
            }
            else if (___PollutionDefinition.EndGamePollutionThreshold * 1 == 20000)
            {
                __result = GetPollutionThresholdValueReworked(GameSpeed.Normal);
            }
            else if (___PollutionDefinition.EndGamePollutionThreshold * 1 == 30000)
            {
                __result = GetPollutionThresholdValueReworked(GameSpeed.Slow);
            }
            else if (___PollutionDefinition.EndGamePollutionThreshold * 1 == 40000)
            {
                __result = GetPollutionThresholdValueReworked(GameSpeed.Endless);
            }

           // PatchForPollutions.logger.Log(LogLevel.Warning, "Vanilla GetPollutionWorldFactorReworked : " + ___WorldAtmosphere.WorldSizeFactor.Value);

            if (___WorldAtmosphere.WorldSizeFactor.Value.ToString() == "0.40")
            {
                __result *= GetPollutionWorldFactorReworked(WorldSize.VerySmall);
            }
            else if (___WorldAtmosphere.WorldSizeFactor.Value.ToString() == "0.60")
            {
                __result *= GetPollutionWorldFactorReworked(WorldSize.Small);
            }
            else if (___WorldAtmosphere.WorldSizeFactor.Value.ToString() == "1.00")
            {
                __result *= GetPollutionWorldFactorReworked(WorldSize.Normal);
            }
            else if (___WorldAtmosphere.WorldSizeFactor.Value.ToString() == "1.80")
            {
                __result *= GetPollutionWorldFactorReworked(WorldSize.Big);
            }
            else if (___WorldAtmosphere.WorldSizeFactor.Value.ToString() == "2.50")
            {
                __result *= GetPollutionWorldFactorReworked(WorldSize.VeryBig);
            }

            PatchForPollutions.logger.Log(LogLevel.Warning, "Rework Value : " + __result);
            return false;
        }

        private static int GetPollutionThresholdValueReworked(GameSpeed speed)
        {
            int __result = PollutionGameSpeedThreshold.gameSpeedThresholds[speed];
            // PatchForPollutions.logger.Log(LogLevel.Warning, "GetPollutionThresholdValueReworked : " + __result);
            return __result;
        }

        private static float GetPollutionWorldFactorReworked(WorldSize size)
        {
            float __result = PollutionWorldSizeFactor.worldSizeFactor[size];
            // PatchForPollutions.logger.Log(LogLevel.Warning, "GetPollutionWorldFactorReworked : " + __result);
            return __result;
        }

        private static void GetPollutionOptions(WorldAtmosphere worldAtmosphere, PollutionDefinition pollutionDefinition)
        {
            PatchForPollutions.logger.Log(LogLevel.Warning, "Pollution PollutionNet " + worldAtmosphere.PollutionNet.Value);
            PatchForPollutions.logger.Log(LogLevel.Warning, "Pollution WorldSizeFactor " + worldAtmosphere.WorldSizeFactor.Value);
            PatchForPollutions.logger.Log(LogLevel.Warning, "Pollution pollutionDefinition " + pollutionDefinition.EndGamePollutionThreshold);
            PatchForPollutions.logger.Log(LogLevel.Warning, "Pollution pollutionDefinition EndGamePollutionThreshold" + pollutionDefinition.EndGamePollutionThreshold * worldAtmosphere.WorldSizeFactor.Value);
        }
    }
}
