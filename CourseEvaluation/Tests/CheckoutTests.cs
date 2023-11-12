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
		loginPage.Login(userNameLogin, userPassword);
		report.Log(Status.Info, "User successfully logs into the system");
		inventoryPage.ClickAddCartSauceLabsBackpackButton();
		report.Log(Status.Info, "User adds a backpack to the cart");
		inventoryPage.ClickCartButton();
		report.Log(Status.Info, "User navigates to the cart page");
		cart.ClickCheckoutButton();
		report.Log(Status.Info, "User navigates to the checkout page");

		// Act
		checkoutPage.FillOutForm(lastName: lastName, postalCode: postalCode);
		report.Log(Status.Info, "User did not fill in the first name field");

		// Assert
		Assert.That(checkoutPage.GetErrorNotification(), Is.EqualTo(checkoutPage.GetErrorFirstNameNotification()));
		report.Log(Status.Info, "User receives a message: \"Error: First Name is required\"");
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
		loginPage.Login(userNameLogin, userPassword);
		report.Log(Status.Info, "User successfully logs into the system");
		inventoryPage.ClickAddCartSauceLabsBackpackButton();
		report.Log(Status.Info, "User adds a backpack to the cart");
		inventoryPage.ClickCartButton();
		report.Log(Status.Info, "User navigates to the cart page");
		cart.ClickCheckoutButton();
		report.Log(Status.Info, "User navigates to the checkout page");

		// Act
		checkoutPage.FillOutForm(firstname: firstName, postalCode: postalCode);
		report.Log(Status.Info, "User did not fill in the last name field");

		// Assert
		Assert.That(checkoutPage.GetErrorNotification(), Is.EqualTo(checkoutPage.GetErrorLastNameNotification()));
		report.Log(Status.Info, "User receives a message: \"Error: Last Name is required\"");
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
		loginPage.Login(userNameLogin, userPassword);
		report.Log(Status.Info, "User successfully logs into the system");
		inventoryPage.ClickAddCartSauceLabsBackpackButton();
		report.Log(Status.Info, "User adds a backpack to the cart");
		inventoryPage.ClickCartButton();
		report.Log(Status.Info, "User navigates to the cart page");
		cart.ClickCheckoutButton();
		report.Log(Status.Info, "User navigates to the checkout page");

		// Act
		checkoutPage.FillOutForm(firstName, lastName);
		report.Log(Status.Info, "User did not fill in the postal code field");

		// Assert
		Assert.That(checkoutPage.GetErrorNotification(), Is.EqualTo(checkoutPage.GetErrorPostalCodeNotification()));
		report.Log(Status.Info, "User receives a message: \"Error: Postal Code is required\"");
	}
}