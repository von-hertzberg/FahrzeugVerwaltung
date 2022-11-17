using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FahrzeugVerwaltung.UI
{
    /// <summary>
    /// Class used to store configuration of the app.
    /// </summary>
    internal class Config
    {
        /// <summary>
        /// Construct an empty configuration.
        /// </summary>
        public Config()
        {
            VehicleListPath = "";
            Username = "";
            Password = "";
        }

        /// <summary>
        /// Try to load the config from the given file path.
        /// When the file at filePath does not exist or the json is not
        /// valid a default config is created.
        /// </summary>
        /// <param name="filePath">The path of te json file to load the config from.</param>
        /// <returns>The loaded config or a default one.</returns>
        public static Config Load(string filePath)
        {
            if (!File.Exists(filePath))
            {
                WriteEmptyConfig(filePath);
                return new Config();
            }

            var fileContent = File.ReadAllText(filePath);
            try
            {
                return JsonSerializer.Deserialize<Config>(fileContent);
            }
            catch (System.Exception)
            {
                WriteEmptyConfig(filePath);
                return new Config();
            }
        }

        /// <summary>
        /// Saves the config in json to the file pointed to by the given path.
        /// </summary>
        /// <param name="filePath">The path to the file to which the config will be written.</param>
        public void Save(string filePath)
        {
            using (var file = File.CreateText(filePath))
            {
                var json = JsonSerializer.Serialize(this);
                file.Write(json);
            }
        }

        /// <summary>
        /// Writes an empty config in json to the given file.
        /// </summary>
        /// <param name="filePath">The path to the file to which the config will be written.</param>
        private static void WriteEmptyConfig(string filePath)
        {
            new Config().Save(filePath);
        }

        /// <summary>
        /// The path where the vehicle list will be stored in json.
        /// </summary>
        [JsonPropertyName("vehiclesFilePath")]
        public string VehicleListPath { get; set; }

        /// <summary>
        /// The saved username of a user.
        /// </summary>
        [JsonPropertyName("user")]
        public string Username { get; set; }

        /// <summary>
        /// The saved password of a user.
        /// </summary>
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
