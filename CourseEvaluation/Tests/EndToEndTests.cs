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
		loginPage.Login(userNameLogin, userPassword);
		report.Log(Status.Info, "User successfully logs into the system");
		inventoryPage.ClickAddCartSauceLabsBackpackButton();
		report.Log(Status.Info, "User adds a backpack to the cart");
		inventoryPage.ClickCartButton();
		report.Log(Status.Info, "User navigates to the cart page");
		cart.ClickCheckoutButton();
		report.Log(Status.Info, "User navigates to the checkout page");
		checkoutPage.FillOutForm(firstName, lastName, postalCode);
		report.Log(Status.Info, "User filled out delivery form");

		// Act
		orderOverviewPage.ClickFinishButton();
		report.Log(Status.Info, "User successfully finished the purchase");

		// Assert
		Assert.That(confirmationPage.GetGratitudeNotification(), Is.EqualTo("Thank you for your order!"));
		report.Log(Status.Info, "User received a purchase confirmation message");
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
		loginPage.Login(userNameLogin, userPassword);
		report.Log(Status.Info, "User successfully logs into the system");
		inventoryPage.ClickSauceLabsBackpack();
		report.Log(Status.Info, "User navigates to the backpack product page");
		itemPage.ClickAddToCartButton();
		report.Log(Status.Info, "User adds the item to the cart");
		itemPage.ClickCartButton();
		report.Log(Status.Info, "User navigates to the cart page");
		cart.ClickCheckoutButton();
		report.Log(Status.Info, "User navigates to the checkout page");
		checkoutPage.FillOutForm(firstName, lastName, postalCode);
		report.Log(Status.Info, "User filled out delivery form");

		// Act
		orderOverviewPage.ClickFinishButton();
		report.Log(Status.Info, "User successfully finished the purchase");

		// Assert
		Assert.That(confirmationPage.GetGratitudeNotification(), Is.EqualTo("Thank you for your order!"));
		report.Log(Status.Info, "User received a purchase confirmation message");
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
		var confirmationPage = new ConfirmationPage(driver);
		loginPage.Login(userNameLogin, userPassword);
		report.Log(Status.Info, "User successfully logs into the system");
		inventoryPage.ClickAddCartSauceLabsBackpackButton();
		report.Log(Status.Info, "User adds a backpack to the cart");
		inventoryPage.ClickCartButton();
		report.Log(Status.Info, "User navigates to the cart page");
		cart.ClickCheckoutButton();
		report.Log(Status.Info, "User navigates to the checkout page");
		checkoutPage.FillOutForm(firstName, lastName, postalCode);
		report.Log(Status.Info, "User filled out delivery form");
		
		// Act
		orderOverviewPage.ClickCancelButton();

		// Assert
		Assert.That(inventoryPage.GetItemsSuiteInt(), Is.EqualTo(6));
	}
}