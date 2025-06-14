using NUnit.Framework;
using Microsoft.Playwright;
using System.Threading.Tasks;
using Allure.NUnit;

namespace Tests.Login
{   
    [AllureNUnit]
    //Added command for setup and teardown.
    public class LoginValidCredentials : BaseTestCommand
    {

        [Test]
        [Description("Login to the application with valid credentials")]
        public async Task LoginWithValidCredentials()
        {
            //Step 1: Login with valid credentials and verify that the user is logged in successfully.
            var loginPage = new Pages.LoginPageCommand(page);
            await loginPage.LoginAsync("visual_user", "secret_sauce");
        }
    }
}