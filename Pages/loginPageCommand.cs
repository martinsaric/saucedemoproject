using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Pages
{
    public class LoginPageCommand
    {
        private readonly IPage page;
        public LoginPageCommand(IPage page)
        {
            this.page = page;
        }

        public async Task LoginAsync(string username, string password)
        {
            await page.GotoAsync("https://www.saucedemo.com/");
            await page.FillAsync("[data-test=\"username\"]", username);
            await page.FillAsync("[data-test=\"password\"]", password);
            await page.ClickAsync("[data-test=\"login-button\"]");

            Assert.That(page.Url, Is.EqualTo("https://www.saucedemo.com/inventory.html"));
        }
    }
}