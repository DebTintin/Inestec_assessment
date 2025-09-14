using Microsoft.Playwright;
using investec_reqnroll_playwright.Pages;
using Reqnroll;

namespace investec_reqnroll_playwright.Steps
{
    [Binding]
    public sealed class CashInvestmentRatesSteps(Hooks.Hooks hooks, BasePage testeryHomePage)
    {
        private readonly IPage _page = hooks.Page;
        private readonly BasePage _testeryHomePage = testeryHomePage;

        [Given("I navigate to (.*)")]
        public async Task GivenNavigateToAsync(string url)
        {
            await _testeryHomePage.GoTo(url);
        }
    }
}