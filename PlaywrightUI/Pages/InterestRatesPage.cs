using Microsoft.Playwright;

namespace investec_reqnroll_playwright.Pages
{
    public class InterestRatesPage
    {
        private readonly IPage _page;
        private readonly BasePage _basePage;

        public InterestRatesPage(IPage page)
        {
            _page = page;
            _basePage = new BasePage(page);
        }
        
        public async Task SignUpToReceiveFocusInsights(string firstName, string surname, string email, string year)
        {
            await _basePage.ClickByText("Sign Up");
            await _basePage.SendTextAsync("//input[@name='name']", firstName);
            await _basePage.SendTextAsync("//input[@name='surname']", surname);
            await _basePage.SendTextAsync("//input[@name='email']", email);
            await _basePage.ClickAsync("//*[@id=\"service\"]");
            await _basePage.ClickAsync("//select[@id='service']");
            await _basePage.SendTextAsync("//input[@name='year_of_birth']", year);
            await _basePage.ClickByText("Submit");

        }

        public async Task SignUpSuccessful()
        {
            await _basePage.AssertElementToBeVisibleAsync("//h3[@class='thank-you__heading']");
        }
    }
}

