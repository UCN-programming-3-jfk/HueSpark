using HueSpark.Console.HueClientStarters;

namespace HueSpark.Console;
internal class Program
{
    public static async Task Main(string[] args)
    {
        HttpClientHueClient client = new("http://192.168.1.100/api/nOUSgAbLjknrHt-5eQmbRauCm3BuFoeJXaXQsdMt/");
        await client.SetLightStateAsync(1, new { on = true, xy = new[] { 0.8, 0.14 } });

        var lightState = await client.GetLightStateAsync(1);
        System.Console.WriteLine($"Light is on: {lightState.on}");

        //for (int i = 0; i < 20; i++)
        //{
        //    await client.ToggleLight(1);
        //    await Task.Delay(1000);
        //}
        var lightId = 3;
        await client.SetLightOnOffAsync(lightId, true);
        //await client.SetBulbColor(lightId, 0.3, 0.7);
        await client.SetBulbColor(lightId, HttpClientHueClient.Color.Green);

    }
}