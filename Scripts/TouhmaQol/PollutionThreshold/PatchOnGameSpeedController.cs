namespace Humankind_Mod.Scripts.TouhmaQol.PollutionThreshold
{

    using Amplitude.Mercury.Data.Simulation;
    using Amplitude.Mercury.Simulation;
    using BepInEx.Logging;
    using HarmonyLib;
    using PatchTest;

    [HarmonyPatch(typeof(GameSpeedController))]
    public class PatchOnGameSpeedController
    {
        [HarmonyPostfix]
        [HarmonyPatch("InitializeOnStart")]
        public static void InitializeOnStart(GameSpeedController __instance, ref GameSpeedDefinition ___CurrentGameSpeedDefinition)
        {
            GetGameSpeedOptions(___CurrentGameSpeedDefinition);

        }

        [HarmonyPostfix]
        [HarmonyPatch("InitializeOnLoad")]
        public static void InitializeOnLoad(GameSpeedController __instance, ref GameSpeedDefinition ___CurrentGameSpeedDefinition)
        {
            GetGameSpeedOptions(___CurrentGameSpeedDefinition);
        }

        private static void GetGameSpeedOptions(GameSpeedDefinition speedDefinition)
        {
            PatchForPollutions.logger.Log(LogLevel.Warning, "GameSpeedController DefaultGameSpeedMultiplier " + speedDefinition.DefaultGameSpeedMultiplier);
        }
    }
}
