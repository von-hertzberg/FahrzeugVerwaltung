using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FahrzeugVerwaltung.UI
{
    internal class Config
    {
        private static void WriteEmptyConfig(string filePath)
        {
            new Config().Save(filePath);
        }
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

        public void Save(string filePath)
        {
            using (var file = File.CreateText(filePath))
            {
                var json = JsonSerializer.Serialize(this);
                file.Write(json);
            }
        }

        public Config()
        {
            VehicleListPath = "";
            Username = "";
            Password = "";
        }

        [JsonPropertyName("vehiclesFilePath")]
        public string VehicleListPath { get; set; }
        [JsonPropertyName("user")]
        public string Username { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
