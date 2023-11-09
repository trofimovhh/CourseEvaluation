using CourseEvaluation.Data;
using CourseEvaluation.Pages;
using NUnit.Framework;

namespace CourseEvaluation.Tests;

public class CartTests : WebDriverInit
{
	[Test(Description =
		"Test confirms possibility to add one product item to cart and then delete product item from cart.")]
	public void AddItemToCartAndDeleteIt()
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
		Assert.AreEqual(0, cart.ListOfItems());
	}

	[Test(Description =
		"Test confirms possibility to add all product items to cart and then delete all product items from cart.")]
	public void AddAllItemsToCartAndDeleteIt()
	{
		// Arrange
		var loginPage = new LoginPage(driver);
		var inventoryPage = new InventoryPage(driver);
		var cart = new CartPage(driver);
		loginPage.Login(UserData.userNameLogin, UserData.userPassword);
		inventoryPage.AddAllItemsOfProductsToCart();
		inventoryPage.ClickCartButton();

		//Act
		cart.RemoveAllItemsFromCart();

		// Assert
		Assert.AreEqual(0, cart.ListOfItems());
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
		Assert.AreEqual(6, inventoryPage.GetItemsSuiteInt());
	}
}