namespace Humankind_Mod.PatchTest.Models
{
    using System.Collections.Generic;
    using Scripts.TouhmaQol.PollutionThreshold.Models;
    public static class SpeedValues
    {
        public static Dictionary<GameSpeed, GameSpeedDefinitionValues> gameSpeedValues = new Dictionary<GameSpeed, GameSpeedDefinitionValues>()
        {
            {
                GameSpeed.Blitz, new GameSpeedDefinitionValues()
                {
                    gameSpeedMultiplier = 0.25f
                    , productionCostMultiplier = 0.25f
                    , moneyInstantCostMultiplier = 0.25f
                    , influenceInstantCostMultiplier = 0.25f
                    , populationInstantCostMultiplier = 0.25f
                    , technologyCostMultiplier = 0.25f
                }
            }
            ,
            {
                GameSpeed.Fast, new GameSpeedDefinitionValues()
                {
                    gameSpeedMultiplier = 0.5f
                    , productionCostMultiplier = 0.5f
                    , moneyInstantCostMultiplier = 0.5f
                    , influenceInstantCostMultiplier = 0.5f
                    , populationInstantCostMultiplier = 0.5f
                    , technologyCostMultiplier = 0.5f
                }
            }
            ,
            {
                GameSpeed.Normal, new GameSpeedDefinitionValues()
                {
                    gameSpeedMultiplier = 1f
                    , productionCostMultiplier = 1f
                    , moneyInstantCostMultiplier = 1f
                    , influenceInstantCostMultiplier = 1f
                    , populationInstantCostMultiplier = 1f
                    , technologyCostMultiplier = 1f
                }
            }
            ,
            {
                GameSpeed.Slow, new GameSpeedDefinitionValues()
                {
                    gameSpeedMultiplier = 1.5f
                    , productionCostMultiplier = 1.5f
                    , moneyInstantCostMultiplier = 1.5f
                    , influenceInstantCostMultiplier = 1.5f
                    , populationInstantCostMultiplier = 1.5f
                    , technologyCostMultiplier = 1.5f
                }
            }
            ,
            {
                GameSpeed.Endless, new GameSpeedDefinitionValues()
                {
                    gameSpeedMultiplier = 2f
                    , productionCostMultiplier = 2f
                    , moneyInstantCostMultiplier = 2f
                    , influenceInstantCostMultiplier = 2f
                    , populationInstantCostMultiplier = 2f
                    , technologyCostMultiplier = 2f
                }
            }
        };
    }


}
