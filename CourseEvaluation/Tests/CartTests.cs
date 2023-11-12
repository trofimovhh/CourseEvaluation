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
		report.Log(Status.Info, "User successfully logs into the system");

		//Act
		inventoryPage.ClickAddCartSauceLabsBackpackButton();
		report.Log(Status.Info, "User adds a backpack to the cart");
		inventoryPage.ClickCartButton();
		report.Log(Status.Info, "User navigates to the cart page");

		// Assert
		Assert.That(cart.ListOfItems(), Is.EqualTo(1));
		report.Log(Status.Info, "User added an item; the number of items in the cart is 1");
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
		report.Log(Status.Info, "User successfully logs into the system");
		inventoryPage.ClickAddCartSauceLabsBackpackButton();
		report.Log(Status.Info, "User adds a backpack to the cart");
		inventoryPage.ClickCartButton();
		report.Log(Status.Info, "User navigates to the cart page");

		//Act
		cart.RemoveOneItemFromCart();
		report.Log(Status.Info, "User removes one item from the cart");

		// Assert
		Assert.That(cart.ListOfItems(), Is.EqualTo(0));
		report.Log(Status.Info, "User removed an item from the cart; the number of items in the cart is now 0");
	}


	[Test(Description = "Test confirms possibility to add all product items to cart and then remove one item.")]
	public void AddAllItemsToCartAndThenRemoveOneItem()
	{
		// Arrange
		var loginPage = new LoginPage(driver);
		var inventoryPage = new InventoryPage(driver);
		var cart = new CartPage(driver);
		loginPage.Login(UserData.userNameLogin, UserData.userPassword);
		report.Log(Status.Info, "User successfully logs into the system");
		inventoryPage.AddAllItemsOfProductsToCart();
		report.Log(Status.Info, "User adds all items to the cart");
		inventoryPage.ClickCartButton();
		report.Log(Status.Info, "User navigates to the cart page");
		report.Log(Status.Info, $"The number of items in the cart is {cart.ListOfItems()}");

		//Act
		cart.RemoveOneItemFromCart();
		report.Log(Status.Info, "User removes one item from the cart");

		// Assert
		Assert.That(cart.ListOfItems(), Is.EqualTo(5));
		report.Log(Status.Info,
			$"The item has been successfully removed from the cart; the number of items in the cart is {cart.ListOfItems()}");
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
		report.Log(Status.Info, "User navigates to the cart page");

		//Act
		cart.ClickContinueShoppingButton();

		// Assert
		Assert.That(inventoryPage.GetItemsSuiteInt(), Is.EqualTo(6));
	}
}