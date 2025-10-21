using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ActiveTwitch.src.utils
{
    public static class JsonManager
    {
        public static T? LoadFromFile<T>(string filePath) where T : class
        {
            try
            {
                if (File.Exists(filePath))
                {
                    var json = File.ReadAllText(filePath, Encoding.UTF8);
                    var obj = System.Text.Json.JsonSerializer.Deserialize<T>(json);
                    return obj;
                }
            }
            catch (Exception ex)
            {
                Debugger.Debug($"[JsonManager::LoadFromFile]Error: {ex.Message}");
            }
            return null;
        }
        
        public static bool SaveToFile<T>(string filePath, T obj) where T : class
        {
            try
            {
                var json = System.Text.Json.JsonSerializer.Serialize(obj, new System.Text.Json.JsonSerializerOptions
                {
                    WriteIndented = true
                });
                File.WriteAllText(filePath, json, Encoding.UTF8);
                return true;
            }
            catch (Exception ex)
            {
                Debugger.Debug($"[JsonManager::SaveToFile]Error: {ex.Message}");
                return false;
            }
        }
    }
}
