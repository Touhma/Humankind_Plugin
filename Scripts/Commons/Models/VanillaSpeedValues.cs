namespace Humankind_Mod.PatchTest.Models
{
    using System.Collections.Generic;
    using Scripts.TouhmaQol.PollutionThreshold.Models;
    public static class VanillaSpeedValues
    {
        public static Dictionary<float,GameSpeed> gameSpeedValues = new Dictionary<float,GameSpeed>()
        {
            {0.25f, GameSpeed.Blitz  },
            { 0.5f, GameSpeed.Fast   },
            { 1.0f, GameSpeed.Normal }, 
            { 1.5f, GameSpeed.Slow   },
            { 2.0f, GameSpeed.Endless}
        };
    }
}