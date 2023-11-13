using AventStack.ExtentReports;
using CourseEvaluation.Pages;
using NUnit.Framework;
using static CourseEvaluation.Data.UserData;

namespace CourseEvaluation.Tests;

public class CheckoutTests : TestBase
{
	[Test(Description =
		"Test confirms impossibility to make a purchase with an empty First Name field in the Checkout page")]
	public void CheckoutWithEmptyFirstName()
	{
		// Arrange
		var loginPage = new LoginPage(driver);
		var inventoryPage = new InventoryPage(driver);
		var cart = new CartPage(driver);
		var checkoutPage = new CheckoutPage(driver);
		report.Log(Status.Info, "User logs into the system");
		loginPage.Login(userNameLogin, userPassword);
		report.Log(Status.Info, "User adds a backpack to the cart");
		inventoryPage.ClickAddCartSauceLabsBackpackButton();
		report.Log(Status.Info, "User navigates to the cart page");
		inventoryPage.ClickCartButton();
		report.Log(Status.Info, "User navigates to the checkout page");
		cart.ClickCheckoutButton();

		// Act
		report.Log(Status.Info, "User fills out last name and postal code in the delivery form");
		checkoutPage.FillOutForm(lastName: lastName, postalCode: postalCode);

		// Assert
		report.Log(Status.Info, "User receives a message: \"Error: First Name is required\"");
		Assert.That(checkoutPage.GetErrorNotification(), Is.EqualTo(checkoutPage.GetErrorFirstNameNotification()));
	}

	[Test(Description =
		"Test confirms impossibility to make a purchase with an empty 'Last Name' field in the Checkout page")]
	public void CheckoutWithEmptyLastName()
	{
		// Arrange
		var loginPage = new LoginPage(driver);
		var inventoryPage = new InventoryPage(driver);
		var cart = new CartPage(driver);
		var checkoutPage = new CheckoutPage(driver);
		report.Log(Status.Info, "User logs into the system");
		loginPage.Login(userNameLogin, userPassword);
		report.Log(Status.Info, "User adds a backpack to the cart");
		inventoryPage.ClickAddCartSauceLabsBackpackButton();
		report.Log(Status.Info, "User navigates to the cart page");
		inventoryPage.ClickCartButton();
		report.Log(Status.Info, "User navigates to the checkout page");
		cart.ClickCheckoutButton();

		// Act
		report.Log(Status.Info, "User fills out first name and postal code in the delivery form");
		checkoutPage.FillOutForm(firstname: firstName, postalCode: postalCode);

		// Assert
		report.Log(Status.Info, "User receives a message: \"Error: Last Name is required\"");
		Assert.That(checkoutPage.GetErrorNotification(), Is.EqualTo(checkoutPage.GetErrorLastNameNotification()));
	}

	[Test(Description =
		"Test confirms impossibility to make a purchase with an empty 'Zip/Postal Code' field in the Checkout page.")]
	public void CheckoutWithEmptyPostalCode()
	{
		// Arrange
		var loginPage = new LoginPage(driver);
		var inventoryPage = new InventoryPage(driver);
		var cart = new CartPage(driver);
		var checkoutPage = new CheckoutPage(driver);
		report.Log(Status.Info, "User logs into the system");
		loginPage.Login(userNameLogin, userPassword);
		report.Log(Status.Info, "User adds a backpack to the cart");
		inventoryPage.ClickAddCartSauceLabsBackpackButton();
		report.Log(Status.Info, "User navigates to the cart page");
		inventoryPage.ClickCartButton();
		report.Log(Status.Info, "User navigates to the checkout page");
		cart.ClickCheckoutButton();

		// Act
		report.Log(Status.Info, "User fills out first name and last name in the delivery form");
		checkoutPage.FillOutForm(firstName, lastName);

		// Assert
		report.Log(Status.Info, "User receives a message: \"Error: Postal Code is required\"");
		Assert.That(checkoutPage.GetErrorNotification(), Is.EqualTo(checkoutPage.GetErrorPostalCodeNotification()));
	}
}