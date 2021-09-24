namespace Humankind_Mod.PatchTest.EraStarRequirements
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Amplitude;
    using Amplitude.Framework;
    using Amplitude.Mercury.Data;
    using Amplitude.Mercury.Data.GameOptions;
    using Amplitude.Mercury.Data.Simulation;
    using FullSerializer;
    using HarmonyLib;
    using UnityEngine;
    using System.IO;
    using Extensions;
    using Path = System.IO.Path;

    [HarmonyPatch(typeof(DataController))]
    public class PatchOnDataController
    {
        public static fsSerializer serializer = new fsSerializer();
        static Dictionary<string, EndGameDefinition> dbEndGameDefinitions = new Dictionary<string, EndGameDefinition>();
        
        [HarmonyPostfix]
        [HarmonyPatch("Initialize")]
        public static void Initialize()
        {
            try
            {
                PatchForEndGameCustomization.logger.LogWarning("TryGet DB EndGame ");
                IDatabase<EndGameDefinition> Db = Databases.GetDatabase<EndGameDefinition>();

                foreach (EndGameDefinition endGameDefinition in Db)
                {
                    PatchForEndGameCustomization.logger.LogWarning("endGameDefinition.Name" + endGameDefinition.Name);
                    //PatchForEndGameCustomization.serializer.TrySerialize(endGameDefinition, out fsData data).AssertSuccessWithoutWarnings();
                    if (endGameDefinition.EndGameConditions == null) { continue; }
                    dbEndGameDefinitions.Add(endGameDefinition.Name.ToString(), endGameDefinition);
                    PatchForEndGameCustomization.ConfigFileManagement(serializer, Path.Combine(PatchForEndGameCustomization.FILE_ENDGAME_CUSTOMIZATION, endGameDefinition.name + ".json"), endGameDefinition.EndGameConditions);
                    ConfigFileManagement(serializer,Path.Combine(PatchForEndGameCustomization.FILE_ENDGAME_CUSTOMIZATION, endGameDefinition.name + ".json"),dbEndGameDefinitions[endGameDefinition.name]);
                    endGameDefinition.Update(dbEndGameDefinitions[endGameDefinition.Name.ToString()].EndGameConditions);
                    PatchForEndGameCustomization.logger.LogWarning("endGameDefinition.EndGameConditions count --> " + endGameDefinition.EndGameConditions.Length) ;
    
                    foreach (EndGameCondition endGameCondition in endGameDefinition.EndGameConditions)
                    {
                        PatchForEndGameCustomization.logger.LogWarning(endGameCondition);
                    }

                }
                PatchForEndGameCustomization.logger.LogWarning("END NB of lines in the DB : " + Db.Count());
            
            }
            catch (Exception e)
            {
                PatchForEndGameCustomization.logger.LogWarning(e);
            }
            
            /*
            try
            {
                PatchForEraStarsRequirements.logger.LogWarning("TryGet DB GameOptionDefinition ");
                IDatabase<GameOptionDefinition> Db2 = Databases.GetDatabase<GameOptionDefinition>();
                PatchForEraStarsRequirements.logger.LogWarning("NB of lines in the DB : " + Db2.Count());
                foreach (GameOptionDefinition gameOptionDefinition in Db2.GetValues())
                {
                    PatchForEraStarsRequirements.logger.LogWarning("gameOptionDefinition.Name" + gameOptionDefinition.Name);
                    PatchForEraStarsRequirements.logger.LogWarning("gameOptionDefinition.RandomState" + gameOptionDefinition.RandomState);
                    PatchForEraStarsRequirements.logger.LogWarning("gameOptionDefinition.IsEditableInGame" + gameOptionDefinition.IsEditableInGame);

                    if (gameOptionDefinition.Name.Equals("GameOption_EndGameConditions"))
                    {
                        PatchForEraStarsRequirements.logger.LogWarning("gameOptionDefinition.Name" + gameOptionDefinition);
                    }
                }

                
            }
            catch (Exception e)
            {
                PatchForEraStarsRequirements.logger.LogWarning(e);
            }
*/

            PatchForEndGameCustomization.logger.LogWarning("Initialize");
        }
        
        public static void ConfigFileManagement(fsSerializer serializer, string name, object reference)
        {
            if (!File.Exists(name))
            {
                serializer.TrySerialize(reference, out fsData data).AssertSuccessWithoutWarnings();
                string json = fsJsonPrinter.PrettyJson(data);
                File.WriteAllText(name , json);
                PatchForEndGameCustomization.logger.LogWarning( name + "Config Created");
            }
            else
            {
                PatchForEndGameCustomization.logger.LogWarning( name + "Exist");
                var testConfig = File.ReadAllText(name);
                fsData data2 = fsJsonParser.Parse(testConfig);
                serializer.TryDeserialize(data2, ref reference).AssertSuccessWithoutWarnings();
                PatchForEndGameCustomization.logger.LogWarning( name + "Config Read");
            }
        }
    }
}
