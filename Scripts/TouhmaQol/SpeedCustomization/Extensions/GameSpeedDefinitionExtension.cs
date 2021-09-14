
namespace Humankind_Mod.PatchTest.Extensions
{
    using Amplitude;
    using Amplitude.Mercury.Data.Simulation;
    
    public static class GameSpeedDefinitionExtension
    {
        public static FixedPoint DefaultGameSpeedMultiplierGetter(this GameSpeedDefinition gameSpeedDefinition)
        {
            return gameSpeedDefinition.DefaultGameSpeedMultiplier;
        }
        public static FixedPoint DefaultGameSpeedMultiplierSetter(this GameSpeedDefinition gameSpeedDefinition)
        {
            return gameSpeedDefinition.DefaultGameSpeedMultiplier *= 2;
        }
    }
}

