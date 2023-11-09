using CourseEvaluation.Pages;
using NUnit.Framework;
using static CourseEvaluation.Data.UserData;

namespace CourseEvaluation.Tests;

public class BuyProductTests : WebDriverInit
{
	[Test(Description = "E2E test, that checks possibility to login with correct data and make a purchase.")]
	public void BuyProduct()
	{
		// Arrange
		var loginPage = new LoginPage(driver);
		var inventoryPage = new InventoryPage(driver);
		var cart = new CartPage(driver);
		var checkoutPage = new CheckoutPage(driver);
		var orderOverviewPage = new OrderOverviewPage(driver);
		var confirmationPage = new ConfirmationPage(driver);

		// Act
		loginPage.Login(userNameLogin, userPassword);
		inventoryPage.ClickAddCartSauceLabsBackpackButton();
		inventoryPage.ClickCartButton();
		cart.ClickCheckoutButton();
		checkoutPage.FillFields(firstName, lastName, postalCode);
		checkoutPage.ClickContinueButton();
		orderOverviewPage.ClickFinishButton();

		// Assert
		Assert.That(confirmationPage.GetGratitudeNotification(), Is.EqualTo("Thank you for your order!"));
	}

	[Test(Description = "Test checks the possibility to make a purchase from the product's page.")]
	public void BuyProductFromItsPage()
	{
		// Arrange
		var loginPage = new LoginPage(driver);
		var inventoryPage = new InventoryPage(driver);
		var itemPage = new ItemPage(driver);
		var cart = new CartPage(driver);
		var checkoutPage = new CheckoutPage(driver);
		var orderOverviewPage = new OrderOverviewPage(driver);
		var confirmationPage = new ConfirmationPage(driver);

		// Act
		loginPage.Login(userNameLogin, userPassword);
		inventoryPage.ClickSauceLabsBackpack();
		itemPage.ClickAddToCartButton();
		itemPage.ClickCartButton();
		cart.ClickCheckoutButton();
		checkoutPage.FillFields(firstName, lastName, postalCode);
		checkoutPage.ClickContinueButton();
		orderOverviewPage.ClickFinishButton();

		// Assert
		Assert.That(confirmationPage.GetGratitudeNotification(), Is.EqualTo("Thank you for your order!"));
	}

	[Test(Description =
		"Test confirms the possibility to cancel a purchase before the customer fills in their personal data.")]
	public void CancelPurchase()
	{
		// Arrange
		var loginPage = new LoginPage(driver);
		var inventoryPage = new InventoryPage(driver);
		var cart = new CartPage(driver);
		var checkoutPage = new CheckoutPage(driver);
		var orderOverviewPage = new OrderOverviewPage(driver);

		// Act
		loginPage.Login(userNameLogin, userPassword);
		inventoryPage.ClickAddCartSauceLabsBackpackButton();
		inventoryPage.ClickCartButton();
		cart.ClickCheckoutButton();
		checkoutPage.FillFields(firstName, lastName, postalCode);
		checkoutPage.ClickContinueButton();
		orderOverviewPage.ClickCancelButton();

		// Assert
		Assert.That(inventoryPage.GetItemsSuiteInt(), Is.EqualTo(6));
	}
}