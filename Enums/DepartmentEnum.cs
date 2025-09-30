using System.Text.Json.Serialization;

namespace webAPI_dotnet.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DepartmentEnum
    {
        HR,
        Financial,
        Purchasing,
        CustomerService,
        Maintenance
    }
}
