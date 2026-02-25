using System.Text.Json.Serialization;

namespace BlazorNBADashboard.Models;

public class Game
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("date")]
    public string Date { get; set; } = string.Empty;

    [JsonPropertyName("season")]
    public int Season { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    [JsonPropertyName("period")]
    public int Period { get; set; }

    [JsonPropertyName("time")]
    public string Time { get; set; } = string.Empty;

    [JsonPropertyName("home_team_score")]
    public int HomeTeamScore { get; set; }

    [JsonPropertyName("visitor_team_score")]
    public int VisitorTeamScore { get; set; }

    [JsonPropertyName("home_team")]
    public Team HomeTeam { get; set; } = new();

    [JsonPropertyName("visitor_team")]
    public Team VisitorTeam { get; set; } = new();

    [JsonPropertyName("home_q1")]
    public int? HomeQ1 { get; set; }

    [JsonPropertyName("home_q2")]
    public int? HomeQ2 { get; set; }

    [JsonPropertyName("home_q3")]
    public int? HomeQ3 { get; set; }

    [JsonPropertyName("home_q4")]
    public int? HomeQ4 { get; set; }

    [JsonPropertyName("visitor_q1")]
    public int? VisitorQ1 { get; set; }

    [JsonPropertyName("visitor_q2")]
    public int? VisitorQ2 { get; set; }

    [JsonPropertyName("visitor_q3")]
    public int? VisitorQ3 { get; set; }

    [JsonPropertyName("visitor_q4")]
    public int? VisitorQ4 { get; set; }
}