using System.Text.Json.Serialization;

namespace UnitConverter.Models;

public class LogEntry
{
    [JsonPropertyName("@t")]
    public DateTimeOffset Timestamp { get; set; }

    [JsonPropertyName("@m")]
    public string? Message { get; set; }

    [JsonPropertyName("@l")]
    public string? Level { get; set; }

    [JsonPropertyName("@x")]
    public string? Exception { get; set; }

    [JsonPropertyName("input")]
    public dynamic? Input { get; set; }
    [JsonPropertyName("conversionType")]
    public string? ConversionType { get; set; }
    [JsonPropertyName("output")]
    public decimal? Result { get; set; }
}
