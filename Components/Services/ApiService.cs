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

    private readonly Dictionary<string, List<GameData>> _cache = new();

    public async Task<List<GameData>> GetGamesByDateAsync(DateOnly date)
    {
        var key = date.ToString("yyyy-MM-dd");
        //added cache to ease api call load on days already rendered
        if (_cache.ContainsKey(key))
        {
            return _cache[key];
        }

        var response = await _httpClient.GetAsync($"/nba/v1/games?dates[]={key}");

        if (!response.IsSuccessStatusCode)
        {
            return new List<GameData>();
        }

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<ApiResponse<GameData>>(json);
        var games = result?.Data ?? new List<GameData>();

        _cache[key] = games;

        return games;
    }

    private readonly Dictionary<int, GameData?> _gameCache = new();

    public async Task<GameData?> GetGameByIdAsync(int id)
    {
        if (_gameCache.ContainsKey(id))
        {
            return _gameCache[id];
        }

        var response = await _httpClient.GetAsync($"/nba/v1/games/{id}");

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<SingleApiResponse<GameData>>(json);
        var game = result?.Data;

        _gameCache[id] = game;

        return game;
    }
}
public class SingleApiResponse<T>
{
    [JsonPropertyName("data")]
    public T? Data { get; set; }
}