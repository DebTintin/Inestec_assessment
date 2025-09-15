namespace investec_reqnroll_playwright.RestSharpAPI;

using Console = System.Console;
using Task = System.Threading.Tasks.Task;
using RestSharp;
using NUnit.Framework;
using Reqnroll;
using System.Text.Json;
    

    [Binding]
    public class SwapiSteps
    {
        private JsonElement? _foundRecord;
        private RestResponse? _response;
        private APIPeople _apiPeople = new APIPeople();

        [When(@"I search for (.*) in the Star Wars API people endpoint")]
        public async Task WhenISearchForInTheStarWarsApiPeopleEndpoint(string name)
        {
            var result = await _apiPeople.GetPeopleAsync(name);
            // Store the found record as a JsonElement for later assertions
            if (!result.StartsWith("Person with name"))
            {
                _foundRecord = JsonDocument.Parse(result).RootElement;
            }
            else
            {
                _foundRecord = null;
            }
            Console.WriteLine(result);
        }

        [Then(@"the skin color should contain both (.*) and (.*)")]
        public void ThenTheSkinColorShouldContainBothWhiteAndBlue(string Color1, string Color2)
        {
            Assert.IsNotNull(_foundRecord, "No record found to assert skin color.");
            var skinColor = _foundRecord.Value.GetProperty("skin_color").GetString();
            Assert.IsNotNull(skinColor, "Skin color property not found.");
            var lowerSkinColor = skinColor.ToLower();
            Assert.IsTrue(lowerSkinColor.Contains(Color1), $"Expected skin color to contain 'white', but got: {skinColor}");
            Assert.IsTrue(lowerSkinColor.Contains(Color2), $"Expected skin color to contain 'blue', but got: {skinColor}");
            if (lowerSkinColor.Contains("white") && lowerSkinColor.Contains("blue"))
            {
                Console.WriteLine("Success: R2-D2's skin color is white and blue.");
            }
        }
    }
