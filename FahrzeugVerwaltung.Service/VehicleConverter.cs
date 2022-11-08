using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FahrzeugVerwaltung.Shared
{
    public class VehicleConverter : JsonConverter
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(Vehicle) == typeToConvert;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);

            var type = jo["VehicleType"].Value<int>();
            switch (type)
            {
                case (int)VehicleType.PKW:
                    return jo.ToObject<PKW>(serializer);
                case (int)VehicleType.LKW:
                    return jo.ToObject<LKW>(serializer);
                default:
                    throw new JsonSerializationException("unknown VehicleType");
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
