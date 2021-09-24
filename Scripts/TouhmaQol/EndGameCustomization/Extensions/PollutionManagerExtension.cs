namespace Humankind_Mod.PatchTest.Extensions
{
    using Amplitude.Mercury.Data.Simulation;
    
    public  static class  EndGameDefinitionExtension
    {
        public static void Update(this EndGameDefinition endgame, EndGameCondition[] endGameConditions)
        {
            endgame.EndGameConditions = null;
            endgame.EndGameConditions = endGameConditions;
        }
    }
}
