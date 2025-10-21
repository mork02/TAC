using ActiveTwitch.src.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveTwitch.src.utils
{
    public sealed class ConfigManager
    {
        private static readonly string _dataDir = Path.Combine(AppContext.BaseDirectory, "data");
        private static string _filePath = Path.Combine(_dataDir, "config.json");
        private static string _defaultPath = Path.Combine(_dataDir, "config.default.json");

        private ConfigManager() { }
    
        public static Config? Load()
        {
            try
            {
                Directory.CreateDirectory(_dataDir);

                var data = JsonManager.LoadFromFile<Config>(_filePath);
                if (data != null) { return data; }


                data = JsonManager.LoadFromFile<Config>(_defaultPath);
                if (data !=null) 
                {
                    Debugger.Debug("[ConfigManager] Fallback auf Default-Config.");
                    return data; 
                }

                Debugger.Debug("[ConfigManager] Keine gültige Config gefunden. Verwende Defaults.");
                return new Config();
            }
            catch (Exception ex)
            {
                Debugger.Debug($"[ConfigManager::load]Error: {ex.Message}");
                return new Config();
            }
        }
    }
}
