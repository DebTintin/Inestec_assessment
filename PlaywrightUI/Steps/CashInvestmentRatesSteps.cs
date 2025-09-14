using Microsoft.Playwright;
using investec_reqnroll_playwright.Pages;
using Reqnroll;

namespace investec_reqnroll_playwright.Steps
{
    [Binding]
    public sealed class CashInvestmentRatesSteps
    {
        private readonly BasePage _basePage;
        private readonly LoginPage _loginPage;
        private readonly InterestRatesPage _interestRatesPage;

        public CashInvestmentRatesSteps(Hooks.Hooks driver)
        {
            _basePage = new BasePage(driver._page);
            _loginPage = new LoginPage(driver._page);
            _interestRatesPage = new InterestRatesPage(driver._page);
        }

        [Given("I navigate to (.*)")]
        public async Task GivenNavigateToAsync(string url)
        {
            await _basePage.GoTo(url);
        }

        [Given("I accept the cookies")]
        public async Task GivenIAcceptTheCookies()
        {
            await _loginPage.AcceptCookies();
        }

        [When("I use the search functionality to look for (.*)")]
        public async Task WhenIUseTheSearchFunctionalityToLookFor(string searchText)
        {
            await _loginPage.Search(searchText);
        }

        [When("I navigate to (.*)")]
        public async Task WhenINavigateTo(string p0)
        {
            await _loginPage.NavigateToUnderstandingCiRatesPage();
        }

        [When("I sign up to receive focus insights with (.*) (.*) (.*) (.*)")]
        public async Task WhenISignUpToReceiveFocusInsightsWith(string firstName, string surname, string email, string year)
        {
            await _interestRatesPage.SignUpToReceiveFocusInsights(firstName, surname, email, year);
        }

        [Then("Assert the sign-up process is successful")]
        public async Task ThenAssertTheSignUpProcessIsSuccessful()
        {
            await _interestRatesPage.SignUpSuccessful();
        }
    }
}