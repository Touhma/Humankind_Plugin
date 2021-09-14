namespace Humankind_Mod.Scripts.Commons.Models
{
    using System.Collections.Generic;
    using Scripts.TouhmaQol.PollutionThreshold.Models;
    public static class VanillaPollutionVariables
    {
        public static Dictionary<float,WorldSize> worldSizeFactor = new Dictionary<float,WorldSize>()
        {
            { 0.4f, WorldSize.VerySmall},
            { 0.6f, WorldSize.Small},
            { 1.0f, WorldSize.Normal}, 
            { 1.8f, WorldSize.Big},
            { 2.5f, WorldSize.VeryBig}
        };
        
        public static Dictionary<int, GameSpeed> gameSpeedThresholds = new Dictionary<int, GameSpeed>()
        {
            { 5000 ,GameSpeed.Blitz},
            { 10000,GameSpeed.Fast },
            { 20000,GameSpeed.Normal},
            { 30000,GameSpeed.Slow },
            { 40000,GameSpeed.Endless}
        };
    }
}
