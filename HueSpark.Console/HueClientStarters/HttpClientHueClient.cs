using HueSpark.Console.Model;
using System.Net.Http.Json;
using System.Text.Json;

namespace HueSpark.Console.HueClientStarters;
public class HttpClientHueClient
{
    private HttpClient _client;

    public HttpClientHueClient(string baseUrl)
    {
        _client = new() { BaseAddress = new Uri(baseUrl) };
    }

    public async Task SetLightOnOffAsync(int lightId, bool lightOn)
    {
       var content = JsonContent.Create(new { on = lightOn});
       var result = await _client.PutAsync("lights/1/state", content);
       System.Console.WriteLine(await result.Content.ReadAsStringAsync());
    }
    public async Task SetLightStateAsync(int lightId, dynamic state)
    {
        var content = JsonContent.Create(state);
        var result = await _client.PutAsync("lights/1/state", content);
        System.Console.WriteLine(await result.Content.ReadAsStringAsync());
    }

    public async Task<LightState> GetLightStateAsync(int lightId)
    {
        try
        {
            var response = await _client.GetStringAsync("lights/1/");
            using JsonDocument doc = JsonDocument.Parse(response);
            JsonElement stateElement = doc.RootElement.GetProperty("state");

            return JsonSerializer.Deserialize<LightState>(stateElement.GetRawText());
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"An error occurred: {ex.Message}");
            return null;
        }
    }

}
