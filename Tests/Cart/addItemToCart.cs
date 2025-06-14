using NUnit.Framework;
using Microsoft.Playwright;
using System.Threading.Tasks;
using Allure.NUnit;

namespace Tests.Cart
{
    [AllureNUnit]
    //Added command for setup and teardown.
    public class AddItemToCart : BaseTestCommand
    {

        [Test]
        [Description("Verify that the user can add item to cart successfully and validate it")]

        public async Task AddItemToCartAndValidate()
        {
            //Step 1: Login with valid credentials and verify that the user is logged in successfully.
            var loginPage = new Pages.LoginPageCommand(page);
            await loginPage.LoginAsync("visual_user", "secret_sauce");

            //Step 2: Locate the item in the inventory page and verify it's name.
            var backPackItem = page.Locator("[data-test=\"inventory-item-description\"]").Filter(new LocatorFilterOptions
            {
                HasTextString = "Sauce Labs Backpack"
            });
            Assert.That(await backPackItem.IsVisibleAsync(), Is.True);

            //Step 3: Locate the cart counter and verify it's value.
            var cartIcon = page.Locator("[data-test=\"shopping-cart-badge\"]");
            Assert.That(await cartIcon.CountAsync(), Is.EqualTo(0));

            //Step 4: Add the item to the cart.
            await page.ClickAsync("[data-test=\"add-to-cart-sauce-labs-backpack\"]");

            //Step 5: Verify that the cart counter is updated to 1.
            var cartIconCounter = page.Locator("[data-test=\"shopping-cart-badge\"]");
            Assert.That(await cartIconCounter.InnerTextAsync(), Is.EqualTo("1"));
        }
    }
}