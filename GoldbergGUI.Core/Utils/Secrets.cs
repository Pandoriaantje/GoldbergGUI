using System;
using System.IO;

namespace GoldbergGUI.Core.Utils
{
    public class Secrets : ISecrets
    {
        public string SteamWebApiKey()
        {
            string executableDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string keyFilePath = Path.Combine(executableDirectory, "key.ini");

            // Check if the key file exists
            if (!File.Exists(keyFilePath))
            {
                throw new FileNotFoundException("Key file not found.", keyFilePath);
            }

            // Read the key from the file
            string apiKey = File.ReadAllText(keyFilePath).Trim();

            return apiKey;
        }
    }
}
