using System.Text;

namespace HueSpark.Console.HueClientStarters;
internal class RestSharpHueClient
{
    private HttpClient _httpClient;

    public RestSharpHueClient(string bridgeUrl)
    {
        _httpClient = new()
        {
            BaseAddress = new Uri(bridgeUrl)
        };
    }

    public string GetLights()
    {
        //        var response = _httpClient.g("lights").Result;
        // return response.Content.ReadAsStringAsync().Result;

        //var webRequest = new HttpRequestMessage(HttpMethod.Get )
        //{
        //    Content = new StringContent("{ 'some': 'value' }", Encoding.UTF8, "application/json")
        //};

        //var response = _httpClient.Send(webRequest);

        //using var reader = new StreamReader(response.Content.ReadAsStream());

        //return reader.ReadToEnd();
        return "";

    }
}
