using AventStack.ExtentReports;
using CourseEvaluation.Data;
using CourseEvaluation.Pages;
using NUnit.Framework;

namespace CourseEvaluation.Tests;

public class CartTests : TestBase
{
	[Test(Description = "Test confirms possibility to add one product item to cart")]
	public void AddItemToCart()
	{
		// Arrange
		var loginPage = new LoginPage(driver);
		var inventoryPage = new InventoryPage(driver);
		var cart = new CartPage(driver);
		loginPage.Login(UserData.userNameLogin, UserData.userPassword);

		//Act
		inventoryPage.ClickAddCartSauceLabsBackpackButton();
		inventoryPage.ClickCartButton();
		report.Log(Status.Info, "LOL");

		// Assert
		Assert.That(cart.ListOfItems(), Is.EqualTo(1));
	}

	[Test(Description =
		"Test confirms possibility to delete the product item from the cart")]
	public void DeleteItemFromCart()
	{
		// Arrange
		var loginPage = new LoginPage(driver);
		var inventoryPage = new InventoryPage(driver);
		var cart = new CartPage(driver);
		loginPage.Login(UserData.userNameLogin, UserData.userPassword);
		inventoryPage.ClickAddCartSauceLabsBackpackButton();
		inventoryPage.ClickCartButton();

		//Act
		cart.RemoveOneItemFromCart();

		// Assert
		Assert.That(cart.ListOfItems(), Is.EqualTo(0));
	}


	[Test(Description = "Test confirms possibility to add all product items to cart and then remove one item.")]
	public void AddAllItemsToCartAndThenDeleteOneItem()
	{
		// Arrange
		var loginPage = new LoginPage(driver);
		var inventoryPage = new InventoryPage(driver);
		var cart = new CartPage(driver);
		loginPage.Login(UserData.userNameLogin, UserData.userPassword);
		inventoryPage.AddAllItemsOfProductsToCart();
		inventoryPage.ClickCartButton();

		//Act
		cart.RemoveOneItemFromCart();

		// Assert
		Assert.That(cart.ListOfItems(), Is.EqualTo(5));
	}

	[Test(Description =
		"Test confirms possibility to add a product item to the cart and then click CONTINUE SHOPPING button.")]
	public void AddItemToCartAndContinueShopping()
	{
		// Arrange
		var loginPage = new LoginPage(driver);
		var inventoryPage = new InventoryPage(driver);
		var cart = new CartPage(driver);
		loginPage.Login(UserData.userNameLogin, UserData.userPassword);
		inventoryPage.ClickAddCartSauceLabsBackpackButton();
		inventoryPage.ClickCartButton();

		//Act
		cart.ClickContinueShoppingButton();

		// Assert
		Assert.That(inventoryPage.GetItemsSuiteInt(), Is.EqualTo(6));
	}
}