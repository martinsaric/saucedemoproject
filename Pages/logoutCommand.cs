using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Pages
{
    public class LogoutPageCommand
    {
        private readonly IPage page;
        public LogoutPageCommand(IPage page)
        {
            this.page = page;
        }

        public async Task LogoutAsync()
        {
            await page.ClickAsync("[id=\"react-burger-menu-btn\"]");
            await page.WaitForSelectorAsync("[id=\"logout_sidebar_link\"]", new PageWaitForSelectorOptions { State = WaitForSelectorState.Visible });
            await page.ClickAsync("[id=\"logout_sidebar_link\"]");

            await page.WaitForURLAsync("https://www.saucedemo.com/");
            Assert.That(page.Url, Is.EqualTo("https://www.saucedemo.com/"));
        }
    }
}