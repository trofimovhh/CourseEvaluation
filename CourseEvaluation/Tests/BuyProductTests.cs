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
		Checkout checkout = new Checkout(driver);
		Overview overview = new Overview(driver);
		Finish finish = new Finish(driver);

		loginPage.Login(userNameLogin, userPassword);
		homePage.ClickAddCartSauceLabsBackpackButton();
		homePage.ClickCartButton();
		cart.ClickCheckoutButton();
		checkout.FillFields(firstName, lastName, postalCode);
		checkout.ClickContinueButton();
		overview.ClickFinishButton();

		Assert.That(finish.GetGratitudeNotification(), Is.EqualTo("Thank you for your order!"));
	}

	[Test]
	[Description("Test checks the possibility to make a purchase from the product's page.")]
	public void BuyProductFromItsPage()
	{
		LoginPage loginPage = new LoginPage(driver);
		HomePage homePage = new HomePage(driver);
		SauceLabsBackpack sauceLabsBackpack = new SauceLabsBackpack(driver);
		CartPage cart = new CartPage(driver);
		Checkout checkout = new Checkout(driver);
		Overview overview = new Overview(driver);
		Finish finish = new Finish(driver);

		loginPage.Login(userNameLogin, userPassword);
		homePage.ClickSauceLabsBackpack();
		sauceLabsBackpack.ClickAddToCartButton();
		sauceLabsBackpack.ClickCartButton();
		cart.ClickCheckoutButton();
		checkout.FillFields(firstName, lastName, postalCode);
		checkout.ClickContinueButton();
		overview.ClickFinishButton();

		Assert.That(finish.GetGratitudeNotification(), Is.EqualTo("Thank you for your order!"));
	}

	[Test]
	[Description("Test confirms impossibility to make a purchase with an empty First Name field in the Checkout page.")]
	public void BuyProductWithEmptyFirstName()
	{
		LoginPage loginPage = new LoginPage(driver);
		HomePage homePage = new HomePage(driver);
		CartPage cart = new CartPage(driver);
		Checkout checkout = new Checkout(driver);

		loginPage.Login(userNameLogin, userPassword);
		homePage.ClickAddCartSauceLabsBackpackButton();
		homePage.ClickCartButton();
		cart.ClickCheckoutButton();
		checkout.FillFields(emptyString, lastName, postalCode);
		checkout.ClickContinueButton();

		Assert.That(checkout.GetErrorNotification(), Is.EqualTo(checkout.GetErrorFirstNameNotification()));
	}

	[Test]
	[Description(
		"Test confirms impossibility to make a purchase with an empty 'Last Name' field in the Checkout page.")]
	public void BuyProductWithIncorrectLastName()
	{
		LoginPage loginPage = new LoginPage(driver);
		HomePage homePage = new HomePage(driver);
		CartPage cart = new CartPage(driver);
		Checkout checkout = new Checkout(driver);

		loginPage.Login(userNameLogin, userPassword);
		homePage.ClickAddCartSauceLabsBackpackButton();
		homePage.ClickCartButton();
		cart.ClickCheckoutButton();
		checkout.FillFields(firstName, emptyString, postalCode);
		checkout.ClickContinueButton();

		Assert.That(checkout.GetErrorNotification(), Is.EqualTo(checkout.GetErrorLastNameNotification()));
	}

	[Test]
	[Description(
		"Test confirms impossibility to make a purchase with an empty 'Zip/Postal Code' field in the Checkout page.")]
	public void BuyProductWithIncorrectPostalCode()
	{
		LoginPage loginPage = new LoginPage(driver);
		HomePage homePage = new HomePage(driver);
		CartPage cart = new CartPage(driver);
		Checkout checkout = new Checkout(driver);

		loginPage.Login(userNameLogin, userPassword);
		homePage.ClickAddCartSauceLabsBackpackButton();
		homePage.ClickCartButton();
		cart.ClickCheckoutButton();
		checkout.FillFields(firstName, lastName, emptyString);
		checkout.ClickContinueButton();

		Assert.That(checkout.GetErrorNotification(), Is.EqualTo(checkout.GetErrorPostalCodeNotification()));
	}

	[Test]
	[Description(
		"Test confirms the possibility to cancel a purchase before the customer fills in their personal data.")]
	public void CancelPurchase()
	{
		LoginPage loginPage = new LoginPage(driver);
		HomePage homePage = new HomePage(driver);
		CartPage cart = new CartPage(driver);
		Checkout checkout = new Checkout(driver);
		Overview overview = new Overview(driver);

		loginPage.Login(userNameLogin, userPassword);
		homePage.ClickAddCartSauceLabsBackpackButton();
		homePage.ClickCartButton();
		cart.ClickCheckoutButton();
		checkout.FillFields(firstName, lastName, postalCode);
		checkout.ClickContinueButton();
		overview.ClickCancelButton();

		Assert.That(homePage.GetItemsSuiteInt(), Is.EqualTo(6));
	}
}