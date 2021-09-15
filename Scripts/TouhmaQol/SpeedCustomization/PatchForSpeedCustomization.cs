namespace Humankind_Mod.PatchTest
{
    using System;
    using System.IO;
    using BepInEx;
    using BepInEx.Logging;
    using FullSerializer;
    using HarmonyLib;
    using Models;

    [BepInPlugin("humankind.touhma.qol-speedCustomization", "Humankind Speed Customization QOL Plug-In", "1.0.0.0")]
    public class PatchForSpeedCustomization : BaseUnityPlugin
    
    {
        public static ManualLogSource logger;    
        public static readonly string DATA_DIR = Path.Combine(Paths.ConfigPath, "Humankind Speed Customization");
        
        public static readonly string FILE_SPEED_CUSTOMIZATION = Path.Combine(DATA_DIR, "GameSpeedCustomization.json");
        
        internal void Awake() {
           
            var harmony = new Harmony("humankind.touhma.qol-speedCustomization");

            //Adding the Logger
            logger = new ManualLogSource("qol-speedCustomization");
            BepInEx.Logging.Logger.Sources.Add(logger);
            logger.Log(LogLevel.Warning, "CreateAndPatchAll");
            Harmony.CreateAndPatchAll(typeof(PatchOnGameSpeedDefinition));
            Harmony.CreateAndPatchAll(typeof(PatchOnGameSpeedController));
            
            if (!Directory.Exists(DATA_DIR)) { Directory.CreateDirectory(DATA_DIR); }

            fsSerializer serializer = new fsSerializer();
            
            var gameSpeedConfig = Path.Combine(DATA_DIR, FILE_SPEED_CUSTOMIZATION);

            ConfigFileManagement(serializer,gameSpeedConfig,SpeedValues.gameSpeedValues);
        }

        public void ConfigFileManagement(fsSerializer serializer, string name, Object reference)
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