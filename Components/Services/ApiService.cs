namespace BlazorNBADashboard.Services;

using BlazorNBADashboard.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

public class NbaApiService
{
    private readonly HttpClient _httpClient;

    public NbaApiService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(configuration["BallDontLieApi:BaseUrl"]!);
        _httpClient.DefaultRequestHeaders.Add("Authorization", configuration["BallDontLieApi:ApiKey"]);
    }

    public async Task<List<GameData>> GetGamesByDateAsync(DateOnly date)
    {
        var response = await _httpClient.GetAsync($"/nba/v1/games?dates[]={date:yyyy-MM-dd}");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<ApiResponse<GameData>>(json);

        return result?.Data ?? new List<GameData>();
    }

    public async Task<GameData?> GetGameByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"/nba/v1/games/{id}");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<SingleApiResponse<GameData>>(json);

        return result?.Data;
    }
}
public class SingleApiResponse<T>
{
    [JsonPropertyName("data")]
    public T? Data { get; set; }
}