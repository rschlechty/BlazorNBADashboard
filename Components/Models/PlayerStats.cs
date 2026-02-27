using System.Text.Json.Serialization;

namespace BlazorNBADashboard.Models;

public class PlayerStats
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("min")]
    public string? Min { get; set; }

    [JsonPropertyName("pts")]
    public int? Pts { get; set; }

    [JsonPropertyName("reb")]
    public int? Reb { get; set; }

    [JsonPropertyName("ast")]
    public int? Ast { get; set; }

    [JsonPropertyName("stl")]
    public int? Stl { get; set; }

    [JsonPropertyName("blk")]
    public int? Blk { get; set; }

    [JsonPropertyName("turnover")]
    public int? Turnover { get; set; }

    [JsonPropertyName("fgm")]
    public int? Fgm { get; set; }

    [JsonPropertyName("fga")]
    public int? Fga { get; set; }

    [JsonPropertyName("fg3m")]
    public int? Fg3m { get; set; }

    [JsonPropertyName("fg3a")]
    public int? Fg3a { get; set; }

    [JsonPropertyName("ftm")]
    public int? Ftm { get; set; }

    [JsonPropertyName("fta")]
    public int? Fta { get; set; }

    [JsonPropertyName("player")]
    public PlayerInfo Player { get; set; } = new();

    [JsonPropertyName("team")]
    public TeamData Team { get; set; } = new();
}

public class PlayerInfo
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; } = string.Empty;

    [JsonPropertyName("last_name")]
    public string LastName { get; set; } = string.Empty;

    [JsonPropertyName("position")]
    public string Position { get; set; } = string.Empty;
}