using NUnit.Framework;
using Microsoft.Playwright;
using System.Threading.Tasks;
using  Allure.NUnit;    

namespace Tests.Logout
{
    [AllureNUnit]
    //Added command for setup and teardown.
    public class Logout : BaseTestCommand
    {
        [Test]
        [Description("Login to the application and logout from it")]
        public async Task LoginAndLogoutAsync()
        {
            //Step 1: Login with valid credentials and verify that the user is logged in successfully.
            var loginPage = new Pages.LoginPageCommand(page);
            await loginPage.LoginAsync("visual_user", "secret_sauce");

            //Step 2: Logout from the application and verify that the user is logged out successfully.
            var logoutPage = new Pages.LogoutPageCommand(page);
            await logoutPage.LogoutAsync();
        }
    }
    
}