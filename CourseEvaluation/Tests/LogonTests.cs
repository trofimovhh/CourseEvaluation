using AventStack.ExtentReports;
using CourseEvaluation.Pages;
using NUnit.Framework;
using static CourseEvaluation.Data.UserData;

namespace CourseEvaluation.Tests;

public class LogonTests : TestBase
{
	[Test(Description = "Login with correct Username and Password")]
	public void CorrectLoginPassword()
	{
		// Arrange
		var loginPage = new LoginPage(driver);
		var inventoryPage = new InventoryPage(driver);

		// Act
		report.Log(Status.Info, "User logs in with correct username and password");
		loginPage.Login(userNameLogin, userPassword);

		// Assert
		report.Log(Status.Info, "User navigates to the product page");
		Assert.That(inventoryPage.GetVisibleCartButton().Displayed);
	}

	[Test(Description = "Login with empty Username field")]
	public void LoginWithEmptyUsername()
	{
		// Arrange
		var loginPage = new LoginPage(driver);

		// Act
		report.Log(Status.Info, "User logs in with empty username field");
		loginPage.Login(password: userPassword);

		// Assert
		report.Log(Status.Info, "User receives a message: \"Username is required\"");
		Assert.That(loginPage.LoginErrorNotification(),
			Is.EqualTo(loginPage.GetErrorNotificationUsername()));
	}

	[Test(Description = "Login with empty Password and see notification about the requirement of Password data")]
	public void LoginWithEmptyPassword()
	{
		// Arrange
		var loginPage = new LoginPage(driver);

		// Act
		report.Log(Status.Info, "User logs in with empty password field");
		loginPage.Login(login: userNameLogin);

		// Assert
		report.Log(Status.Info, "User receives a message: \"Password is required\"");
		Assert.That(loginPage.GetErrorNotificationPassword().Equals(loginPage.LoginErrorNotification()));
	}

	[Test(Description =
		"Login with incorrect Username and see error notification about incorrect match of any user in this service")]
	public void IncorrectLogin()
	{
		// Arrange
		var loginPage = new LoginPage(driver);

		// Act
		report.Log(Status.Info, "User logs in with incorrect username");
		loginPage.Login(incorrectUsername, userPassword);

		// Assert
		report.Log(Status.Info,
			"User receives a message: \"Username and password do not match any user in this service\"");
		Assert.That(loginPage.GetStrUsernameAndPassDoNotMatch().Equals(loginPage.LoginErrorNotification()));
	}

	[Test(Description =
		"Login with incorrect Password and see error notification about incorrect match of any user in this service")]
	public void IncorrectPassword()
	{
		// Arrange
		var loginPage = new LoginPage(driver);

		// Act
		report.Log(Status.Info, "User logs in with incorrect password");
		loginPage.Login(userNameLogin, incorrectPassword);

		// Assert
		report.Log(Status.Info,
			"User receives a message: \"Username and password do not match any user in this service\"");
		Assert.That(loginPage.GetStrUsernameAndPassDoNotMatch().Equals(loginPage.LoginErrorNotification()));
	}
}