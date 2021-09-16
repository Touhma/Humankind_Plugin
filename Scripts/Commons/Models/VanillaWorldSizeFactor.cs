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
        
        public static Dictionary<int, GameSpeed> gameSpeedPollutionThresholds = new Dictionary<int, GameSpeed>()
        {
            { 12500 ,GameSpeed.Blitz},
            { 25000,GameSpeed.Fast },
            { 50000,GameSpeed.Normal},
            { 75000,GameSpeed.Slow },
            { 100000,GameSpeed.Endless}
        };
        
        public static Dictionary<GameSpeed, int> pollutionThresholdsByGameSpeed = new Dictionary<GameSpeed, int>()
        {
            { GameSpeed.Blitz    ,12500 },
            { GameSpeed.Fast     ,25000},
            { GameSpeed.Normal   ,50000},
            { GameSpeed.Slow     ,75000},
            { GameSpeed.Endless  ,100000}
        };
    }
}
