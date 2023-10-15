using CourseEvaluation.Pages;
using NUnit.Framework;
using static CourseEvaluation.Data.UserData;

namespace CourseEvaluation.Tests;

public class BuyProductTests : WebDriverInit
{
	[Test(Description = "E2E test, that checks possibility to login with correct data and make a successful purchase.")]
	public void BuyProduct()
	{
		// Arrange
		LoginPage loginPage = new LoginPage(driver);
		InventoryPage inventoryPage = new InventoryPage(driver);
		CartPage cart = new CartPage(driver);
		CheckoutPage checkoutPage = new CheckoutPage(driver);
		OrderOverviewPage orderOverviewPage = new OrderOverviewPage(driver);
		ConfirmationPage confirmationPage = new ConfirmationPage(driver);
		
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
		LoginPage loginPage = new LoginPage(driver);
		InventoryPage inventoryPage = new InventoryPage(driver);
		ItemPage itemPage = new ItemPage(driver);
		CartPage cart = new CartPage(driver);
		CheckoutPage checkoutPage = new CheckoutPage(driver);
		OrderOverviewPage orderOverviewPage = new OrderOverviewPage(driver);
		ConfirmationPage confirmationPage = new ConfirmationPage(driver);

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
		"Test confirms impossibility to make a purchase with an empty First Name field in the Checkout page.")]
	public void BuyProductWithEmptyFirstName()
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
	public void BuyProductWithIncorrectLastName()
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
	public void BuyProductWithIncorrectPostalCode()
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

	[Test(Description =
		"Test confirms the possibility to cancel a purchase before the customer fills in their personal data.")]
	public void CancelPurchase()
	{
		// Arrange
		LoginPage loginPage = new LoginPage(driver);
		InventoryPage inventoryPage = new InventoryPage(driver);
		CartPage cart = new CartPage(driver);
		CheckoutPage checkoutPage = new CheckoutPage(driver);
		OrderOverviewPage orderOverviewPage = new OrderOverviewPage(driver);

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