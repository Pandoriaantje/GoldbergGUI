using System;
using System.IO;
using System.Windows.Forms;

namespace GoldbergGUI.Core.Utils
{
    public class Secrets : ISecrets
    {
        public string SteamWebApiKey()
        {
            string executableDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string keyFilePath = Path.Combine(executableDirectory, "key.txt");

            // Check if the key file exists
            if (!File.Exists(keyFilePath))
            {
                // Show message box informing the user
                MessageBox.Show("The key.ini file was not found. Make sure to place the key.ini containing your API key, alongside the executable. Generate your personal API key at https://steamcommunity.com/dev/apikey.", "API keyfile Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw new FileNotFoundException("Key file not found.", keyFilePath);
            }

            // Read the key from the file
            string apiKey = File.ReadAllText(keyFilePath).Trim();

            return apiKey;
        }
    }
}
