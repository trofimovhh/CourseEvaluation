using CourseEvaluation.Pages;
using NUnit.Framework;
using static CourseEvaluation.Data.UserData;

namespace CourseEvaluation.Tests;

public class BuyProductTests : WebDriverInit
{
	[Test]
	[Description("E2E test, that checks possibility to login with correct data and make a successful purchase.")]
	public void BuyProduct()
	{
		LoginPage loginPage = new LoginPage(driver);
		HomePage homePage = new HomePage(driver);
		CartPage cart = new CartPage(driver);
		CheckoutPage checkoutPage = new CheckoutPage(driver);
		OrderOverviewPage orderOverviewPage = new OrderOverviewPage(driver);
		ConfirmationPage confirmationPage = new ConfirmationPage(driver);

		loginPage.Login(userNameLogin, userPassword);
		homePage.ClickAddCartSauceLabsBackpackButton();
		homePage.ClickCartButton();
		cart.ClickCheckoutButton();
		checkoutPage.FillFields(firstName, lastName, postalCode);
		checkoutPage.ClickContinueButton();
		orderOverviewPage.ClickFinishButton();

		Assert.That(confirmationPage.GetGratitudeNotification(), Is.EqualTo("Thank you for your order!"));
	}

	[Test]
	[Description("Test checks the possibility to make a purchase from the product's page.")]
	public void BuyProductFromItsPage()
	{
		LoginPage loginPage = new LoginPage(driver);
		HomePage homePage = new HomePage(driver);
		ItemPage itemPage = new ItemPage(driver);
		CartPage cart = new CartPage(driver);
		CheckoutPage checkoutPage = new CheckoutPage(driver);
		OrderOverviewPage orderOverviewPage = new OrderOverviewPage(driver);
		ConfirmationPage confirmationPage = new ConfirmationPage(driver);

		loginPage.Login(userNameLogin, userPassword);
		homePage.ClickSauceLabsBackpack();
		itemPage.ClickAddToCartButton();
		itemPage.ClickCartButton();
		cart.ClickCheckoutButton();
		checkoutPage.FillFields(firstName, lastName, postalCode);
		checkoutPage.ClickContinueButton();
		orderOverviewPage.ClickFinishButton();

		Assert.That(confirmationPage.GetGratitudeNotification(), Is.EqualTo("Thank you for your order!"));
	}

	[Test]
	[Description("Test confirms impossibility to make a purchase with an empty First Name field in the Checkout page.")]
	public void BuyProductWithEmptyFirstName()
	{
		LoginPage loginPage = new LoginPage(driver);
		HomePage homePage = new HomePage(driver);
		CartPage cart = new CartPage(driver);
		CheckoutPage checkoutPage = new CheckoutPage(driver);

		loginPage.Login(userNameLogin, userPassword);
		homePage.ClickAddCartSauceLabsBackpackButton();
		homePage.ClickCartButton();
		cart.ClickCheckoutButton();
		checkoutPage.FillFields(emptyString, lastName, postalCode);
		checkoutPage.ClickContinueButton();

		Assert.That(checkoutPage.GetErrorNotification(), Is.EqualTo(checkoutPage.GetErrorFirstNameNotification()));
	}

	[Test]
	[Description(
		"Test confirms impossibility to make a purchase with an empty 'Last Name' field in the Checkout page.")]
	public void BuyProductWithIncorrectLastName()
	{
		LoginPage loginPage = new LoginPage(driver);
		HomePage homePage = new HomePage(driver);
		CartPage cart = new CartPage(driver);
		CheckoutPage checkoutPage = new CheckoutPage(driver);

		loginPage.Login(userNameLogin, userPassword);
		homePage.ClickAddCartSauceLabsBackpackButton();
		homePage.ClickCartButton();
		cart.ClickCheckoutButton();
		checkoutPage.FillFields(firstName, emptyString, postalCode);
		checkoutPage.ClickContinueButton();

		Assert.That(checkoutPage.GetErrorNotification(), Is.EqualTo(checkoutPage.GetErrorLastNameNotification()));
	}

	[Test]
	[Description(
		"Test confirms impossibility to make a purchase with an empty 'Zip/Postal Code' field in the Checkout page.")]
	public void BuyProductWithIncorrectPostalCode()
	{
		LoginPage loginPage = new LoginPage(driver);
		HomePage homePage = new HomePage(driver);
		CartPage cart = new CartPage(driver);
		CheckoutPage checkoutPage = new CheckoutPage(driver);

		loginPage.Login(userNameLogin, userPassword);
		homePage.ClickAddCartSauceLabsBackpackButton();
		homePage.ClickCartButton();
		cart.ClickCheckoutButton();
		checkoutPage.FillFields(firstName, lastName, emptyString);
		checkoutPage.ClickContinueButton();

		Assert.That(checkoutPage.GetErrorNotification(), Is.EqualTo(checkoutPage.GetErrorPostalCodeNotification()));
	}

	[Test]
	[Description(
		"Test confirms the possibility to cancel a purchase before the customer fills in their personal data.")]
	public void CancelPurchase()
	{
		LoginPage loginPage = new LoginPage(driver);
		HomePage homePage = new HomePage(driver);
		CartPage cart = new CartPage(driver);
		CheckoutPage checkoutPage = new CheckoutPage(driver);
		OrderOverviewPage orderOverviewPage = new OrderOverviewPage(driver);

		loginPage.Login(userNameLogin, userPassword);
		homePage.ClickAddCartSauceLabsBackpackButton();
		homePage.ClickCartButton();
		cart.ClickCheckoutButton();
		checkoutPage.FillFields(firstName, lastName, postalCode);
		checkoutPage.ClickContinueButton();
		orderOverviewPage.ClickCancelButton();

		Assert.That(homePage.GetItemsSuiteInt(), Is.EqualTo(6));
	}
}