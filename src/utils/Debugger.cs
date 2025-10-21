using System;
using System.IO;

namespace ActiveTwitch.src.utils
{
    public static class Debugger
    {
        private static readonly string _logDir = Path.Combine(AppContext.BaseDirectory, "logs");
        private static readonly string _filePath = Path.Combine(_logDir, $"log-{DateTime.UtcNow:yyyy-MM-dd}.txt");

        public static void Debug(string message)
        {
            try
            {
                Directory.CreateDirectory(_logDir);

                string logLine = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
                File.AppendAllText(_filePath, logLine + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Logger Error] {ex.Message}");
            }
        }
    }
}
