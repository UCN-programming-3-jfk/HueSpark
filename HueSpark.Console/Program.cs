using HueSpark.Console.HueClientStarters;

namespace HueSpark.Console;
internal class Program
{
    public static async Task Main(string[] args)
    {
        HttpClientHueClient client = new("http://192.168.1.100/api/nOUSgAbLjknrHt-5eQmbRauCm3BuFoeJXaXQsdMt/");
        await client.SetLightStateAsync(1, new{on=true, xy = new[] {0.8, 0.14 } });

        var lightState = await client.GetLightStateAsync(1);
        System.Console.WriteLine($"Light is on: {lightState.on}");
    }
}