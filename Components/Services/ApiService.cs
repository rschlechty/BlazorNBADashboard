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

    public async Task<List<Game>> GetGamesByDateAsync(DateOnly date)
    {
        var response = await _httpClient.GetAsync($"/nba/v1/games?dates[]={date:yyyy-MM-dd}");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<ApiResponse<Game>>(json);

        return result?.Data ?? new List<Game>();
    }

    public async Task<Game?> GetGameByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"/nba/v1/games/{id}");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<SingleApiResponse<Game>>(json);

        return result?.Data;
    }
}
public class SingleApiResponse<T>
{
    [JsonPropertyName("data")]
    public T? Data { get; set; }
}