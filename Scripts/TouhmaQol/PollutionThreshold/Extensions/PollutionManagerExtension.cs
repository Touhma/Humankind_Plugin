namespace Humankind_Mod.PatchTest.Extensions
{
    using Amplitude.Mercury.Simulation;
    using BepInEx.Logging;
    using UnityEngine;
    public  static class  PollutionManagerExtension
    {
        public static void AddFactoredRadius(this PollutionManager pollutionManager) {
            Debug.Log("Testing Extension with publicizer");
            PatchForPollutions.logger.Log(LogLevel.Warning, "Testing Extension with publicizer");
        }
    }
}
