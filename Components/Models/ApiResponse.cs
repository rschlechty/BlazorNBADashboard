using System.Text.Json.Serialization;

namespace BlazorNBADashboard.Models;

public class ApiResponse<T>
{
    [JsonPropertyName("data")]
    public List<T> Data { get; set; } = new();
}