using Microsoft.AspNetCore.Mvc.Testing;
using MyTest.Api;
using MyTest.Api.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

public class TestDepartement
{

    // Scénario 1

    // Récupérer les départements d’une région existante

    [Fact]
    public async Task TestDepartement()
    {
        await using var _factory = new WebApplicationFactory<Program>();
        var client = _factory.CreateClient();

        var response = await client.GetAsync("Departement/Nord-Pas-De-Calais");
        string stringResponse = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var departements = JsonSerializer.Deserialize<List<DepartementModel>>(stringResponse, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true 
        });

        Assert.NotNull(departements);
        Assert.NotEmpty(departements);
        Assert.Equal("Nord-Pas-De-Calais", departements[0].Name);
    }

    // Scénario 2

    // Récupérer les départements d’une pays mais le département est inexistant

    [Fact]
     public async Task TestDepartementInexistant()
    {
        await using var _factory = new WebApplicationFactory<Program>();
        var client = _factory.CreateClient();

        var response = await client.GetAsync("Departement/DepartementInexistant");

        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }
}
