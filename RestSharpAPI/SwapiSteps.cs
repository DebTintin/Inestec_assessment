using RestSharp;
using NUnit.Framework;
using Reqnroll;

namespace investec_reqnroll_playwright.RestSharpAPI
{
    [Binding]
    public class SwapiSteps
    {
        private RestResponse? _response;

        [When(@"I send a GET request to ""(.*)"" with browser headers")]
        public async Task WhenISendAGetRequestToWithBrowserHeaders(string url)
        {
            var options = new RestClientOptions()
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Upgrade-Insecure-Requests", "1");
            request.AddHeader("User-Agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/139.0.0.0 Safari/537.36");
            _response = await client.ExecuteAsync(request);
            Console.WriteLine(_response.Content);
        }

        [Then(@"the response status code should be (\d+)")]
        public void ThenTheResponseStatusCodeShouldBe(int statusCode)
        {
            Assert.IsNotNull(_response, "Response is null");
            Assert.AreEqual(statusCode, (int)_response.StatusCode);
        }

        [Then(@"the response should contain (.*)")]
        public void ThenTheResponseShouldContain(string expectedContent)
        {
            Assert.IsNotNull(_response, "Response is null");
            Assert.IsTrue(_response.Content != null && _response.Content.Contains(expectedContent), $"Response does not contain '{expectedContent}'");
        }

        [Then(@"display the response content")]
        public void ThenDisplayTheResponseContent()
        {
            if (_response == null)
            {
                Console.WriteLine("No response was received from the API (response is null).");
                Assert.Fail("No response was received from the API (response is null).");
            }
            else
            {
                Console.WriteLine($"Status Code: {_response.StatusCode}");
                if (!_response.IsSuccessful)
                {
                    Console.WriteLine($"Request failed: {_response.ErrorMessage}");
                }
                Console.WriteLine("API Response:\n" + _response.Content);
            }
        }
    }
}
