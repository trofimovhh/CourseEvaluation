using CourseEvaluation.Pages;
using NUnit.Framework;
using static CourseEvaluation.Data.UserData;

namespace CourseEvaluation.Tests;

public class LogonTests : WebDriverInit
{
	[Test]
	[Description("Login with correct Username and Password")]
	public void CorrectLoginPassword()
	{
		LoginPage loginPage = new LoginPage(driver);
		HomePage homePage = new HomePage(driver);

		loginPage.Login(userNameLogin, userPassword);
		Assert.IsTrue(homePage.GetVisibleCartButton().Displayed);
	}


	[Test]
	[Description("Login with empty Username field and see notification about the requirement of Username data")]
	public void LoginWithEmptyUsername()
	{
		LoginPage loginPage = new LoginPage(driver);

		loginPage.Login(emptyString, userPassword);
		Assert.AreEqual(loginPage.GetErrorNotificationUsername(), loginPage.LoginErrorNotification());
	}

	[Test]
	[Description("Login with empty Password and see notification about the requirement of Password data")]
	public void LoginWithEmptyPassword()
	{
		LoginPage loginPage = new LoginPage(driver);

		loginPage.Login(userNameLogin, emptyString);
		Assert.AreEqual(loginPage.GetErrorNotificationPassword(), loginPage.LoginErrorNotification());
	}

	[Test]
	[Description("Login with empty Username and Password and see error notification")]
	public void LoginWithEmptyUsernameAndPassword()
	{
		LoginPage loginPage = new LoginPage(driver);

		loginPage.Login(emptyString, emptyString);
		Assert.AreEqual(loginPage.GetErrorNotificationUsername(), loginPage.LoginErrorNotification());
	}

	[Test]
	[Description(
		"Login with incorrect Username and see error notification about incorrect match of any user in this service")]
	public void IncorrectLogin()
	{
		LoginPage loginPage = new LoginPage(driver);

		loginPage.Login(incorrectUsername, userPassword);
		Assert.AreEqual(loginPage.GetStrUsernameAndPassDoNotMatch(), loginPage.LoginErrorNotification());
	}

	[Test]
	[Description(
		"Login with incorrect Password and see error notification about incorrect match of any user in this service")]
	public void IncorrectPassword()
	{
		LoginPage loginPage = new LoginPage(driver);

		loginPage.Login(userNameLogin, incorrectPassword);
		Assert.AreEqual(loginPage.GetStrUsernameAndPassDoNotMatch(), loginPage.LoginErrorNotification());
	}

	[Test]
	[Description(
		"Login with incorrect Username and Password and see error notification about incorrect match of any user in this service")]
	public void IncorrectLoginAndPassword()
	{
		LoginPage loginPage = new LoginPage(driver);

		loginPage.Login(incorrectUsername, incorrectPassword);
		Assert.AreEqual(loginPage.GetStrUsernameAndPassDoNotMatch(), loginPage.LoginErrorNotification());
	}
	
	
}