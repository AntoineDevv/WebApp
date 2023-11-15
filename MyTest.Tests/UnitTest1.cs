namespace MyTest.Tests;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using MyTest.Api.Controllers;

public class UnitTest1
{
    [Fact]
    public async Task Test1()
    {
        await using var _factory = new WebApplicationFactory<Program>();
        var client = _factory.CreateClient();

        var response = await client.GetAsync("WheaterForecast");
        string stringResponse = await response.Content.ReadAsStringAsync();

        response.EnsureSuccessStatusCode();
    }
}