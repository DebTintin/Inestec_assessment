using Microsoft.Playwright;

namespace investec_reqnroll_playwright.Pages
{
    public class LoginPage
    {
        private readonly IPage _page;
        private readonly BasePage _basePage;

        public LoginPage(IPage page)
        {
            _page = page;
            _basePage = new BasePage(page);
        }

        public async Task AcceptCookies()
        {
            await _basePage.ClickByText("Accept All Cookies");
        }

        public async Task Search(string searchText)
        {
            await _basePage.ClickAsync("#search-toggler__search");
            await _basePage.SendTextAsync("#searchBarInput", searchText);
            await _basePage.ClickAsync("#searchBarButton");
        }

        public async Task NavigateToUnderstandingCiRatesPage()
        {
            await _basePage.ClickAsync("//*[@id=\"focusResultsWrapper\"]/div[2]/div/div[2]/div/div/div/a/h4");
        }
    }
}
