namespace Humankind_Mod.PatchTest
{
    using System;
    using System.IO;
    using BepInEx;
    using BepInEx.Logging;
    using EraStarRequirements;
    using FullSerializer;
    using HarmonyLib;
    using Scripts.TouhmaQol.EndGameCustomization;

    [BepInPlugin("humankind.touhma.qol-endGameCustomization", "Humankind EndGame Customization QOL Plug-In", "1.0.0.0")]
    public class PatchForEndGameCustomization : BaseUnityPlugin
    
    {
        public static ManualLogSource logger;    
        public static readonly string DATA_DIR = Path.Combine(Paths.ConfigPath, "Humankind EndGame Customization");
        
        public static readonly string FILE_ENDGAME_CUSTOMIZATION = Path.Combine(DATA_DIR, "EndGameCustomization");
        public static readonly string FILE_DB_CUSTOMIZATION = Path.Combine(DATA_DIR, "DBCustomization");
        public static fsSerializer serializer = new fsSerializer();
        
        internal void Awake() {
           
            var harmony = new Harmony("humankind.touhma.qol-endGameCustomization");

            //Adding the Logger
            logger = new ManualLogSource("qol-endGameCustomization");
            BepInEx.Logging.Logger.Sources.Add(logger);
            logger.Log(LogLevel.Warning, "CreateAndPatchAll");
             
            if (!Directory.Exists(DATA_DIR)) { Directory.CreateDirectory(DATA_DIR); }
            if (!Directory.Exists(FILE_ENDGAME_CUSTOMIZATION)) { Directory.CreateDirectory(FILE_ENDGAME_CUSTOMIZATION); }
            if (!Directory.Exists(FILE_DB_CUSTOMIZATION)) { Directory.CreateDirectory(FILE_DB_CUSTOMIZATION); }
            //Harmony.CreateAndPatchAll(typeof(PatchOnDataBase));
            Harmony.CreateAndPatchAll(typeof(PatchOnDataController));
           
        }

        public static void ConfigFileManagement(fsSerializer serializer, string name, Object reference)
        {
            if (!File.Exists(name))
            {
                serializer.TrySerialize(reference, out fsData data).AssertSuccessWithoutWarnings();
                string json = fsJsonPrinter.PrettyJson(data);
                File.WriteAllText(name , json);
                logger.Log(LogLevel.Warning, name + "Config Created");
            }
            else
            {
                logger.Log(LogLevel.Info, name + "Exist");
                var testConfig = File.ReadAllText(name);
                fsData data2 = fsJsonParser.Parse(testConfig);
                serializer.TryDeserialize(data2, ref reference).AssertSuccessWithoutWarnings();
                logger.Log(LogLevel.Info, name + "Config Read");
            }
        }
    }
}