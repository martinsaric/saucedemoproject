using NUnit.Framework;
using Microsoft.Playwright;
using System.Threading.Tasks;
using Allure.NUnit;

namespace Tests.Login
{
    [AllureNUnit]
    //Added command for setup and teardown.

    public class loginInvalidCredentials : BaseTestCommand
    {

        [Test]
        [Description("Login with empty username and valid password")]
        public async Task loginWithEmptyUsername()
        {
            //Step 1: Visit the valid URL.
            await page.GotoAsync("https://www.saucedemo.com/");

            //Step 2: Leave the username field empty and enter a valid password.
            await page.FillAsync("[data-test=\"username\"]", "");
            await page.FillAsync("[data-test=\"password\"]", "secret_sauce");

            //Step 3: Click the login button.
            await page.ClickAsync("[data-test=\"login-button\"]");

            //Step 4: Verify that the correct error message is displayed.   
            var actualText = await page.InnerTextAsync("[data-test=\"error\"]");
            Assert.That(actualText, Is.EqualTo("Epic sadface: Username is required"));
        }

        [Test]
        [Description("Login with invalid username and valid password")]

        public async Task loginWithInvalidUsername()
        {
            //Step 1: Visit the valid URL.
            await page.GotoAsync("https://www.saucedemo.com/");

            //Step 2: Enter an invalid username and a valid password.
            await page.FillAsync("[data-test=\"username\"]", "Martin_Saric");
            await page.FillAsync("[data-test=\"password\"]", "secret_sauce");

            //Step 3: Click the login button.
            await page.ClickAsync("[data-test=\"login-button\"]");

            //Step 4: Verify that the correct error message is displayed.
            var actualText = await page.InnerTextAsync("[data-test=\"error\"]");
            Assert.That(actualText, Is.EqualTo("Epic sadface: Username and password do not match any user in this service"));
        }
    }
}