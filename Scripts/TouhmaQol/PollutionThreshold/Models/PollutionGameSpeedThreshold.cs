namespace Humankind_Mod.Scripts.TouhmaQol.PollutionThreshold.Models
{
    using System.Collections.Generic;
    public static class PollutionGameSpeedThreshold
    {
        public static Dictionary<GameSpeed, int> gameSpeedThresholds = new Dictionary<GameSpeed, int>()
        {
            {GameSpeed.Blitz, 5000},
            {GameSpeed.Fast, 10000},
            {GameSpeed.Normal, 20000},
            {GameSpeed.Slow, 30000},
            {GameSpeed.Endless, 40000}
        };
    }
}
