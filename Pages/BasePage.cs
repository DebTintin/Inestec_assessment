using Microsoft.Playwright;
using investec_reqnroll_playwright.Hooks;
using Reqnroll;

namespace investec_reqnroll_playwright.Pages
{
    public class BasePage(Hooks.Hooks hooks)
    {
        private readonly IPage _page = hooks.Page;
        public async Task GoTo (string url)
        {
            await _page.GotoAsync(url);
        }
    }
}