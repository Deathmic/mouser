using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Mouser
{
    internal class JsonSettingsRepository : ISettingsRepository
    {
        private const string SETTINGS_FILE_NAME = "settings.json";
        private readonly string _settingsFilePath;

        public JsonSettingsRepository()
        {
            _settingsFilePath = Path.Combine(Application.UserAppDataPath, SETTINGS_FILE_NAME);
        }

        public void Save(MouserSettings settings)
        {
            var sJson = JsonConvert.SerializeObject(settings);
            using (var writer = new StreamWriter(_settingsFilePath))
            {
                writer.Write(sJson);
            }
        }

        public MouserSettings Load()
        {
            MouserSettings settings = null;

            try
            {
                string sJson;

                using (var reader = new StreamReader(_settingsFilePath))
                {
                    sJson = reader.ReadToEnd();
                }

                settings = JsonConvert.DeserializeObject<MouserSettings>(sJson);
            }
            catch (FileNotFoundException)
            {
            }

            return settings ?? new MouserSettings();
        }
    }
}