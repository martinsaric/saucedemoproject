using NUnit.Framework;
using Microsoft.Playwright;
using System.Threading.Tasks;
using Allure.NUnit;

namespace Tests.Cart
{   
    [AllureNUnit]
    //Added command for setup and teardown
    public class removeItemFromCart : BaseTestCommand
    {

        [Test]
        [Description("Verify that the user can remove item from cart successfully and validate it")]

        public async Task RemoveItemFromCartAndValidate()
        {
            //Step 1: Login with valid credentials and verify that the user is logged in successfully.
            var loginPage = new Pages.LoginPageCommand(page);
            await loginPage.LoginAsync("visual_user", "secret_sauce");

            //Step 2: Locate the item in the inventory page and verify it's name.
            var backPackItem = page.Locator("[data-test=\"inventory-item-description\"]").Filter(new LocatorFilterOptions
            {
                HasTextString = "Sauce Labs Backpack"
            });

            //Step 3: Assert that the item is visible.
            Assert.That(await backPackItem.IsVisibleAsync(), Is.True);

            //Step 4: Locate the cart counter and verify it's value.
            var cartIcon = page.Locator("[data-test=\"shopping-cart-badge\"]");
            Assert.That(await cartIcon.CountAsync(), Is.EqualTo(0));

            //Step 5: Add the item to the cart.
            await page.ClickAsync("[data-test=\"add-to-cart-sauce-labs-backpack\"]");

            //Step 6: Verify that the cart counter is updated to 1.
            var cartIconCounter = page.Locator("[data-test=\"shopping-cart-badge\"]");
            Assert.That(await cartIconCounter.InnerTextAsync(), Is.EqualTo("1"));

            //Step 7: Click on the "Remove" button to remove the item from the cart.
            await page.ClickAsync("[data-test=\"remove-sauce-labs-backpack\"]");

            //Step 8: Verify that the cart counter is reduced to 0.
            var cartIconAfterRemoval = page.Locator("[data-test=\"shopping-cart-badge\"]");
            Assert.That(await cartIconAfterRemoval.CountAsync(), Is.EqualTo(0));
        }
    }
} 