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
		report.Log(Status.Info, "User logs into the system");
		loginPage.Login(UserData.userNameLogin, UserData.userPassword);
		report.Log(Status.Info, "User adds a backpack to the cart");
		inventoryPage.ClickAddCartSauceLabsBackpackButton();

		//Act
		report.Log(Status.Info, "User navigates to the cart page");
		inventoryPage.ClickCartButton();
		// Assert
		report.Log(Status.Info, $"The number of items in the cart is {cart.ListOfItems()}");
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
		report.Log(Status.Info, "User logs into the system");
		loginPage.Login(UserData.userNameLogin, UserData.userPassword);
		report.Log(Status.Info, "User adds a backpack to the cart");
		inventoryPage.ClickAddCartSauceLabsBackpackButton();
		report.Log(Status.Info, "User navigates to the cart page");
		inventoryPage.ClickCartButton();

		//Act
		report.Log(Status.Info, "User removes one item from the cart");
		cart.RemoveOneItemFromCart();

		// Assert
		report.Log(Status.Info, $"The number of items in the cart is {cart.ListOfItems()}");
		Assert.That(cart.ListOfItems(), Is.EqualTo(0));
	}


	[Test(Description = "Test confirms possibility to add all product items to cart and then remove one item.")]
	public void AddAllItemsToCartThenRemoveOneItem()
	{
		// Arrange
		var loginPage = new LoginPage(driver);
		var inventoryPage = new InventoryPage(driver);
		var cart = new CartPage(driver);
		report.Log(Status.Info, "User logs into the system");
		loginPage.Login(UserData.userNameLogin, UserData.userPassword);
		report.Log(Status.Info, "User adds all items to the cart");
		inventoryPage.AddAllItemsOfProductsToCart();
		report.Log(Status.Info, "User navigates to the cart page");
		inventoryPage.ClickCartButton();
		report.Log(Status.Info, $"The number of items in the cart is {cart.ListOfItems()}");

		//Act
		report.Log(Status.Info, "User removes one item from the cart");
		cart.RemoveOneItemFromCart();

		// Assert
		Assert.That(cart.ListOfItems(), Is.EqualTo(5));
		report.Log(Status.Info, $"The number of items in the cart is {cart.ListOfItems()}");
	}

	[Test(Description =
		"Test confirms possibility to add a product item to the cart and then click CONTINUE SHOPPING button.")]
	public void AddItemToCartAndContinueShopping()
	{
		// Arrange
		var loginPage = new LoginPage(driver);
		var inventoryPage = new InventoryPage(driver);
		var cart = new CartPage(driver);
		report.Log(Status.Info, "User logs into the system");
		loginPage.Login(UserData.userNameLogin, UserData.userPassword);
		report.Log(Status.Info, "User adds a backpack to the cart");
		inventoryPage.ClickAddCartSauceLabsBackpackButton();
		report.Log(Status.Info, "User navigates to the cart page");
		inventoryPage.ClickCartButton();

		//Act
		report.Log(Status.Info, "User clicks on the \"Continue Shopping\" button");
		cart.ClickContinueShoppingButton();

		// Assert
		report.Log(Status.Info,
			$"User navigates to the inventory page; there are {inventoryPage.GetItemsSuiteInt()} items on the page.");
		Assert.That(inventoryPage.GetItemsSuiteInt(), Is.EqualTo(6));
	}
}