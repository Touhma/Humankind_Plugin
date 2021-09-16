namespace Humankind_Mod.Scripts.TouhmaQol.PollutionThreshold.Models
{
    using System.Collections.Generic;
    using Commons.Models;
    public static class PollutionGameSpeedThreshold
    {
        public static Dictionary<GameSpeed, int> gameSpeedThresholds = new Dictionary<GameSpeed, int>()
        {
            {GameSpeed.Blitz, VanillaPollutionVariables.pollutionThresholdsByGameSpeed[GameSpeed.Blitz]},
            {GameSpeed.Fast, VanillaPollutionVariables.pollutionThresholdsByGameSpeed[GameSpeed.Fast]},
            {GameSpeed.Normal, VanillaPollutionVariables.pollutionThresholdsByGameSpeed[GameSpeed.Normal]},
            {GameSpeed.Slow, VanillaPollutionVariables.pollutionThresholdsByGameSpeed[GameSpeed.Slow]},
            {GameSpeed.Endless, VanillaPollutionVariables.pollutionThresholdsByGameSpeed[GameSpeed.Endless]}
        };
    }
}
