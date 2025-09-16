using Microsoft.AspNetCore.Mvc.Testing;

namespace MinimalAPIDemo.Test;

[TestClass]
public class ApiTests
{
    [TestMethod]
    public async Task DefaultRoute_ReturnsHelloWorld()
    {
        var webApplicationFactory = new WebApplicationFactory<Program>();
        var httpClient = webApplicationFactory.CreateDefaultClient();

        var response = await httpClient.GetAsync("");
        var responseString = await response.Content.ReadAsStringAsync();

        Assert.AreEqual("Hello World!", responseString);
    }
}
