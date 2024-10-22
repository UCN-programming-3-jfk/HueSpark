using HueSpark.Console.Model;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace HueSpark.Console.HueClientStarters;
public class HttpClientHueClient
{
    public enum Color {Red, Yellow, Green }
    private Dictionary<Color, double[]> _colorLookUp = new() 
    {
        {Color.Green, new double[]{0.3, 0.7} }
    };

    private HttpClient _client;

    public HttpClientHueClient(string baseUrl)
    {
        _client = new() { BaseAddress = new Uri(baseUrl) };
    }

    // task 1 - C# function to turn a light on/off based on light number and boolean
    public async Task SetLightOnOffAsync(int lightId, bool lightOn)
    {
       var content = JsonContent.Create(new { on = lightOn});
       var result = await _client.PutAsync($"lights/{lightId}/state", content);
       System.Console.WriteLine(await result.Content.ReadAsStringAsync());
    }

    //public async Task ToggleLight(int id) 
    //{
    //    var state = await GetLightStateAsync(id);
    //    state.on = !state.on;
    //    await SetLightStateAsync(id, state);
    //}


    public async Task ToggleLight(int id)
    {
        //hent lysets state
        var lightState = await GetLightStateAsync(id);

        //invertér state.on
        lightState.on = !lightState.on;

        //put lysets state
        await SetLightStateAsync(id, lightState);
    }

    public async Task SetBulbColor(int id, double x, double y)
    {
        await SetLightStateAsync(id, new { xy = new[] {x,y} });
    }
    public async Task SetBulbColor(int id, Color color)
    {
        await SetLightStateAsync(id, new { xy = _colorLookUp[color] });
    }



    public async Task SetLightStateAsync(int lightId, dynamic state)
    {
        var content = JsonContent.Create(state);
        var result = await _client.PutAsync($"lights/{lightId}/state", content);
        System.Console.WriteLine(await result.Content.ReadAsStringAsync());
    }   

    public async Task<LightState> GetLightStateAsync(int lightId)
    {
            var response = await _client.GetStringAsync($"lights/{lightId}/");
            using JsonDocument doc = JsonDocument.Parse(response);
            JsonElement stateElement = doc.RootElement.GetProperty("state");

            return JsonSerializer.Deserialize<LightState>(stateElement.GetRawText());
    }

}
