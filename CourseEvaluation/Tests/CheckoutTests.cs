using CourseEvaluation;
using NUnit.Framework;
using static CourseEvaluation.Data.UserData;

public class CheckoutTests : WebDriverInit
{
	[Test(Description =
		"Test confirms impossibility to make a purchase with an empty First Name field in the Checkout page.")]
	public void CheckoutWithEmptyFirstName()
	{
		// Arrange
		LoginPage loginPage = new LoginPage(driver);
		InventoryPage inventoryPage = new InventoryPage(driver);
		CartPage cart = new CartPage(driver);
		CheckoutPage checkoutPage = new CheckoutPage(driver);
		loginPage.Login(userNameLogin, userPassword);

		// Act
		inventoryPage.ClickAddCartSauceLabsBackpackButton();
		inventoryPage.ClickCartButton();
		cart.ClickCheckoutButton();
		checkoutPage.FillFields(emptyString, lastName, postalCode);
		checkoutPage.ClickContinueButton();

		// Assert
		Assert.That(checkoutPage.GetErrorNotification(), Is.EqualTo(checkoutPage.GetErrorFirstNameNotification()));
	}

	[Test(Description =
		"Test confirms impossibility to make a purchase with an empty 'Last Name' field in the Checkout page.")]
	public void CheckoutWithEmptyLastName()
	{
		// Arrange
		LoginPage loginPage = new LoginPage(driver);
		InventoryPage inventoryPage = new InventoryPage(driver);
		CartPage cart = new CartPage(driver);
		CheckoutPage checkoutPage = new CheckoutPage(driver);

		// Act
		loginPage.Login(userNameLogin, userPassword);
		inventoryPage.ClickAddCartSauceLabsBackpackButton();
		inventoryPage.ClickCartButton();
		cart.ClickCheckoutButton();
		checkoutPage.FillFields(firstName, emptyString, postalCode);
		checkoutPage.ClickContinueButton();

		// Assert
		Assert.That(checkoutPage.GetErrorNotification(), Is.EqualTo(checkoutPage.GetErrorLastNameNotification()));
	}

	[Test(Description =
		"Test confirms impossibility to make a purchase with an empty 'Zip/Postal Code' field in the Checkout page.")]
	public void CheckoutWithEmptyPostalCode()
	{
		// Arrange
		LoginPage loginPage = new LoginPage(driver);
		InventoryPage inventoryPage = new InventoryPage(driver);
		CartPage cart = new CartPage(driver);
		CheckoutPage checkoutPage = new CheckoutPage(driver);

		// Act
		loginPage.Login(userNameLogin, userPassword);
		inventoryPage.ClickAddCartSauceLabsBackpackButton();
		inventoryPage.ClickCartButton();
		cart.ClickCheckoutButton();
		checkoutPage.FillFields(firstName, lastName, emptyString);
		checkoutPage.ClickContinueButton();

		// Assert
		Assert.That(checkoutPage.GetErrorNotification(), Is.EqualTo(checkoutPage.GetErrorPostalCodeNotification()));
	}
}