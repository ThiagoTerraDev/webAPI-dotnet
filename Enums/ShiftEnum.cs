using System.Text.Json.Serialization;

namespace webAPI_dotnet.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ShiftEnum
    {
        Morning,
        Afternoon,
        Night
    }
}
