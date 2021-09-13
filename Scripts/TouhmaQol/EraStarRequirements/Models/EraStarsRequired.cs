namespace Humankind_Mod.PatchTest.EraStarRequirements.Models
{
    using System.Collections.Generic;
    using static EraIndexModel;
    public static class EraStarsRequired
    {
        public static Dictionary<EraIndexModel, int> starsRequired = new Dictionary<EraIndexModel, int>()
        {
            {Neolithic, 1},
            {Ancient, 7},
            {Classical, 7},
            {Medieval, 7},
            {Modern, 7},
            {Industrial, 7},
            {Contemporary , 0}
        };
    }
}
