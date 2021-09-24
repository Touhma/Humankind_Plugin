namespace Humankind_Mod.Scripts.TouhmaQol.EndGameCustomization
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Amplitude.Framework;
    using FullSerializer;
    using HarmonyLib;
    using PatchTest;
    using Path = System.IO.Path;
    [HarmonyPatch(typeof(Databases))]
    public class PatchOnDataBase
    {
        static Dictionary<string, bool> dbloaded = new Dictionary<string, bool>();
        
        [HarmonyPostfix]
        [HarmonyPatch( nameof(Databases.GetDatabase), new Type[] {typeof(System.Type )})]
        public static void GetDatabase(Dictionary<Type, object> ___databases, object __result, System.Type elementType)
        {
            try
            {
                foreach (KeyValuePair<Type, object> keyValuePair in ___databases)
                {
                    if(dbloaded.ContainsKey(keyValuePair.Key.Name)) continue;
                    ConfigFileManagement(PatchForEndGameCustomization.serializer, keyValuePair.Key.Name, keyValuePair);
                    dbloaded.Add(keyValuePair.Key.Name, true);
                }
            } catch (Exception e)
            {
                PatchForEndGameCustomization.logger.LogWarning(e);
            }
        }

        private static void ConfigFileManagement(fsSerializer serializer, string name, Object reference)
        {
            name += ".json";
            if (!File.Exists(name))
            {
                serializer.TrySerialize(reference, out fsData data).AssertSuccessWithoutWarnings();
                string json = fsJsonPrinter.PrettyJson(data);
                File.WriteAllText(Path.Combine(PatchForEndGameCustomization.FILE_DB_CUSTOMIZATION, name) , json);
                PatchForEndGameCustomization.logger.LogWarning(name + "Config Created");
            }
        }
    }
}
