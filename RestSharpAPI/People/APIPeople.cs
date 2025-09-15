using System.Net;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

public class APIPeople
{
    private RestClient _client;

    public APIPeople()
    {
        var options = new RestClientOptions("https://swapi.dev/api/")
        {
            RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
        };
        _client = new RestClient(options);
    }

    // Async method to get people from SWAPI
    public async Task<string> GetPeopleAsync(string nameToSearch)
    {
        var request = new RestRequest("people/", Method.Get);

        var response = await _client.ExecuteAsync(request);
        var json = JObject.Parse(response.Content);
        var results = json["results"];
        if (results != null)
        {
            foreach (var person in results)
            {
                if (string.Equals((string)person["name"], nameToSearch, StringComparison.OrdinalIgnoreCase))
                {
                    return person.ToString(Newtonsoft.Json.Formatting.Indented);
                }
            }
        }
        return $"Person with name '{nameToSearch}' not found.";
    }

    [Test]
    public async Task GetPeopleByName()
    {
        var result = await GetPeopleAsync("R2-D2");
        Console.WriteLine(result);  
    }
}