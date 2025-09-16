using Microsoft.AspNetCore.Mvc.Testing;

namespace MinimalAPIDemo.Test;

[TestClass]
public class ApiTests
{
    private readonly HttpClient _httpClient;

    public ApiTests()
    {
        var webApplicationFactory = new WebApplicationFactory<Program>();
        _httpClient = webApplicationFactory.CreateDefaultClient();
    }

    [TestMethod]
    public async Task DefaultRoute_ReturnsHelloWorld()
    {
        var response = await _httpClient.GetAsync("");
        var responseString = await response.Content.ReadAsStringAsync();

        Assert.AreEqual("Hello World!", responseString);
    }


    [TestMethod]
    public async Task Sum_Returns16For10And6()
    {
        var response = await _httpClient.GetAsync("sum?n1=10&n2=6");
        var responseString = await response.Content.ReadAsStringAsync();
        var result = int.Parse(responseString);

        Assert.AreEqual(16, result);
    }
}
