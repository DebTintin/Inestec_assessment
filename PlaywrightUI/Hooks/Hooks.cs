using Microsoft.Playwright;
using Reqnroll;

namespace investec_reqnroll_playwright.Hooks;

[Binding]
public class Hooks
{
    public IPlaywright? _playwright;
    public IBrowser? _browser;
    public IBrowserContext? _browserContext;
    public IPage? _page;

    [BeforeScenario]
    public async Task Setup()
    {

    }
    [BeforeStep]
    public async Task InitiateBrowserIfNeeded()
    {
        var stepText = ScenarioStepContext.Current.StepInfo.Text;
        if (stepText.Contains("I navigate to"))
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false, Channel = "chrome", Timeout = 60000});
            _browserContext = await _browser.NewContextAsync();
            _page = await _browser.NewPageAsync();
        }
    }

    [AfterScenario]
    public async Task TearDown()
    {
        if (_browser != null)
            await _browser.CloseAsync();
        _playwright?.Dispose();
    }
}