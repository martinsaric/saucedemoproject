using NUnit.Framework;
using Microsoft.Playwright;
using System.Threading.Tasks;
using Allure.NUnit;

namespace Tests.Cart
{   
    [AllureNUnit]
    //Added command for setup and teardown
    public class addMultipleItemsToCart : BaseTestCommand
    {

        [Test]
        [Description("Verify that the user can add multiple items to cart successfully and validate it")]

        public async Task AddMultipleItemsToCartAndValidate()
        {
            //Step 1: Login with valid credentials and verify that the user is logged in successfully.
            var loginPage = new Pages.LoginPageCommand(page);
            await loginPage.LoginAsync("visual_user", "secret_sauce");

            //Step 2: Locate the item in the inventory page and verify it's name.
            var backPackItem = page.Locator("[data-test=\"inventory-item-description\"]").Filter(new LocatorFilterOptions
            {
                HasTextString = "Sauce Labs Backpack"
            });

            //Step 3: Locate another item ffrom the inventory and verify it's name.
            var jacketItem = page.Locator("[data-test=\"inventory-item-description\"]").Filter(new LocatorFilterOptions
            {
                HasTextString = "Sauce Labs Fleece Jacket"
            });

            //Step 4: Locate the cart counter and verify it's value.
            var cartItems = page.Locator("[data-test=\"cart-item\"]");
            Assert.That(await cartItems.CountAsync(), Is.EqualTo(0));

            //Step 5: Add the items to the cart.
            await page.ClickAsync("[data-test=\"add-to-cart-sauce-labs-backpack\"]");
            await page.ClickAsync("[data-test=\"add-to-cart-sauce-labs-fleece-jacket\"]");

            //Step 6: Verify that the cart counter is updated to 2.
            var cartItemsCounter = page.Locator("[data-test=\"shopping-cart-badge\"]");
            Assert.That(await cartItemsCounter.InnerTextAsync(), Is.EqualTo("2"));
        }
    }

}