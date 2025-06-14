using NUnit.Framework;
using Microsoft.Playwright;
using System.Threading.Tasks;

public class BaseTestCommand
{
    protected IPage page;
    protected IPlaywright playwright;
    protected IBrowser browser;
    protected IBrowserContext context;

     [SetUp]

        public async Task Setup()
    {
        playwright = await Playwright.CreateAsync();
        browser = await playwright.Chromium.LaunchAsync((new BrowserTypeLaunchOptions
        {
            Headless = false

        }));
        context = await browser.NewContextAsync();
        page = await browser.NewPageAsync();
    }

    [TearDown]

    public async Task TearDown()
    {
        await page.CloseAsync();
        await context.CloseAsync();
        await browser.CloseAsync();
        playwright.Dispose();
    }
}