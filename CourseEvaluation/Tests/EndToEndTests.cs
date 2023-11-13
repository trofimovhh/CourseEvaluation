using AventStack.ExtentReports;
using CourseEvaluation.Pages;
using NUnit.Framework;
using static CourseEvaluation.Data.UserData;

namespace CourseEvaluation.Tests;

public class EndToEndTests : TestBase
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

		report.Log(Status.Info, "User logs into the system");
		loginPage.Login(userNameLogin, userPassword);
		report.Log(Status.Info, "User adds a backpack to the cart");
		inventoryPage.ClickAddCartSauceLabsBackpackButton();
		report.Log(Status.Info, "User navigates to the cart page");
		inventoryPage.ClickCartButton();
		report.Log(Status.Info, "User navigates to the checkout page");
		cart.ClickCheckoutButton();
		report.Log(Status.Info, "User fills out the delivery form");
		checkoutPage.FillOutForm(firstName, lastName, postalCode);

		// Act
		report.Log(Status.Info, "User completes the purchase");
		orderOverviewPage.ClickFinishButton();

		// Assert
		report.Log(Status.Info, "User receives a confirmation message");
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
		
		report.Log(Status.Info, "User logs into the system");
		loginPage.Login(userNameLogin, userPassword);
		report.Log(Status.Info, "User navigates to the backpack product page");
		inventoryPage.ClickSauceLabsBackpack();
		report.Log(Status.Info, "User adds the item to the cart");
		itemPage.ClickAddToCartButton();
		report.Log(Status.Info, "User navigates to the cart page");
		itemPage.ClickCartButton();
		report.Log(Status.Info, "User navigates to the checkout page");
		cart.ClickCheckoutButton();
		report.Log(Status.Info, "User fills out the delivery form");
		checkoutPage.FillOutForm(firstName, lastName, postalCode);

		// Act
		report.Log(Status.Info, "User completes the purchase");
		orderOverviewPage.ClickFinishButton();

		// Assert
		report.Log(Status.Info, "User receives a confirmation message");
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
		report.Log(Status.Info, "User logs into the system");
		loginPage.Login(userNameLogin, userPassword);
		report.Log(Status.Info, "User adds a backpack to the cart");
		inventoryPage.ClickAddCartSauceLabsBackpackButton();
		report.Log(Status.Info, "User navigates to the cart page");
		inventoryPage.ClickCartButton();
		report.Log(Status.Info, "User navigates to the checkout page");
		cart.ClickCheckoutButton();
		report.Log(Status.Info, "User fills out delivery form");
		checkoutPage.FillOutForm(firstName, lastName, postalCode);

		// Act
		report.Log(Status.Info, "User cancels the purchase");
		orderOverviewPage.ClickCancelButton();

		// Assert
		report.Log(Status.Info, "User returns to the inventory page");
		Assert.That(inventoryPage.GetItemsSuiteInt(), Is.EqualTo(6));
	}
}