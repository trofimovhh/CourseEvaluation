using CourseEvaluation.Data;
using CourseEvaluation.Pages;
using NUnit.Framework;

namespace CourseEvaluation.Tests;

public class CartTests : WebDriverInit
{
	[Test]
	[Description("Test confirms possibility to add one product item to cart and then delete product item from cart.")]
	public void AddItemToCartAndDeleteIt()
	{
		LoginPage loginPage = new LoginPage(driver);
		HomePage homePage = new HomePage(driver);
		CartPage cart = new CartPage(driver);

		loginPage.Login(UserData.userNameLogin, UserData.userPassword);
		homePage.ClickAddCartSauceLabsBackpackButton();
		homePage.ClickCartButton();
		cart.RemoveOneItemFromCart();

		Assert.AreEqual(0, cart.ListOfItems());
	}

	[Test]
	[Description(
		"Test confirms possibility to add all product items to cart and then delete all product items from cart.")]
	public void AddAllItemsToCartAndDeleteIt()
	{
		LoginPage loginPage = new LoginPage(driver);
		HomePage homePage = new HomePage(driver);
		CartPage cart = new CartPage(driver);

		loginPage.Login(UserData.userNameLogin, UserData.userPassword);
		homePage.AddAllItemsOfProductsToCart();
		homePage.ClickCartButton();
		cart.RemoveAllItemsFromCart();

		Assert.AreEqual(0, cart.ListOfItems());
	}

	[Test]
	[Description(
		"Test confirms possibility to add a product item to the cart and then click CONTINUE SHOPPING button.")]
	public void AddItemToCartAndContinueShopping()
	{
		LoginPage loginPage = new LoginPage(driver);
		HomePage homePage = new HomePage(driver);
		CartPage cart = new CartPage(driver);

		loginPage.Login(UserData.userNameLogin, UserData.userPassword);
		homePage.ClickAddCartSauceLabsBackpackButton();
		homePage.ClickCartButton();
		cart.ClickContinueShoppingButton();

		Assert.AreEqual(6, homePage.GetItemsSuiteInt());
	}
}