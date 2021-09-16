namespace Humankind_Mod.Scripts.TouhmaQol.PollutionThreshold.Models
{
    using System.Collections.Generic;
    public static class PollutionWorldSizeFactor
    {
        public static Dictionary<WorldSize, float> worldSizeFactor = new Dictionary<WorldSize, float>()
        {
            {WorldSize.VerySmall, 0.4f},
            {WorldSize.Small, 0.6f},
            {WorldSize.Normal, 1f},
            {WorldSize.Big, 1.8f},
            {WorldSize.VeryBig, 2.5f}
        };
    }
}
