namespace Humankind_Mod.PatchTest
{

    using System;
    using System.IO;
    using BepInEx;
    using BepInEx.Logging;
    using EraStarRequirements;
    using FullSerializer;
    using HarmonyLib;
    using Scripts.TouhmaQol.PollutionThreshold.Models;

    [BepInPlugin("humankind.touhma.qol-pollutionThreshold", "Humankind Pollution QOL Plug-In", "1.0.0.0")]
    public class PatchForPollutions : BaseUnityPlugin
    
    {
        public static ManualLogSource logger;    
        public static readonly string DATA_DIR = Path.Combine(Paths.ConfigPath, "Humankind Pollution");
        
        public static readonly string FILE_SPEED_BUDGET_NAME = Path.Combine(DATA_DIR, "GameSpeedPollutionBudget.json");
        public static readonly string FILE_WORLD_FACTOR_NAME = Path.Combine(DATA_DIR, "WorldSizePollutionFactors.json");
        
        internal void Awake() {
           
            var harmony = new Harmony("humankind.touhma.qol-pollutionThreshold");

            //Adding the Logger
            logger = new ManualLogSource("qol-pollutionThreshold");
            BepInEx.Logging.Logger.Sources.Add(logger);
            logger.Log(LogLevel.Warning, "CreateAndPatchAll");
            Harmony.CreateAndPatchAll(typeof(PatchOnPollutionManager));
            //Harmony.CreateAndPatchAll(typeof(PatchOnPollutionDefinition));
            
            if (!Directory.Exists(DATA_DIR)) { Directory.CreateDirectory(DATA_DIR); }

            fsSerializer serializer = new fsSerializer();
            
            var gameSpeedPollutionBudget = Path.Combine(DATA_DIR, FILE_SPEED_BUDGET_NAME);
            var worldSizePollutionFactors = Path.Combine(DATA_DIR, FILE_WORLD_FACTOR_NAME);

            ConfigFileManagement(serializer,gameSpeedPollutionBudget,PollutionGameSpeedThreshold.gameSpeedThresholds);
            ConfigFileManagement(serializer,worldSizePollutionFactors,PollutionWorldSizeFactor.worldSizeFactor);
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