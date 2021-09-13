namespace Humankind_Mod.PatchTest.EraStarRequirements
{
    using System.IO;
    using BepInEx;
    using BepInEx.Logging;
    using FullSerializer;
    using HarmonyLib;
    using Models;

    [BepInPlugin("humankind.touhma.qol-eraStars", "Humankind EraStars QOL Plug-In", "1.0.0.0")]
    public class PatchForEraStarsRequirements: BaseUnityPlugin
    {
        public new static ManualLogSource logger;    
        public static readonly string DATA_DIR = Path.Combine(Paths.ConfigPath, "Humankind EraStars");
        public static readonly string FILE_NAME = Path.Combine(Paths.ConfigPath, "EraStarsRequiredByEra.json");
        
        
        internal void Awake() {
           
            var harmony = new Harmony("humankind.touhma.qol-eraStars");

            //Adding the Logger
            logger = new ManualLogSource("qol-eraStars");
            BepInEx.Logging.Logger.Sources.Add(logger);
            logger.Log(LogLevel.Info, "qol-eraStars Loading Plugin");
            
            Harmony.CreateAndPatchAll(typeof(PatchOnEraDefinition));
            
            logger.Log(LogLevel.Info, "qol-eraStars Loading Done");
            
            var filename = Path.Combine(DATA_DIR, FILE_NAME);
            
            if (!Directory.Exists(DATA_DIR))
            {
                Directory.CreateDirectory(DATA_DIR);
            }
            
            fsSerializer serializer = new fsSerializer();
            
            if (!File.Exists(filename))
            {
                serializer.TrySerialize(EraStarsRequired.starsRequired, out fsData data).AssertSuccessWithoutWarnings();
                string json = fsJsonPrinter.PrettyJson(data);
                File.WriteAllText(filename , json);
                logger.Log(LogLevel.Warning, "EraStarsRequired.starsRequired Config Created");
            }
            else
            {
                logger.Log(LogLevel.Info, "EraStarsRequired.starsRequired Config Read");
                var testConfig = File.ReadAllText(filename);
                fsData data2 = fsJsonParser.Parse(testConfig);
                serializer.TryDeserialize(data2, ref EraStarsRequired.starsRequired).AssertSuccessWithoutWarnings();
                logger.Log(LogLevel.Info, "EraStarsRequired.starsRequired Config Read");
            }
        }
        
    }
}