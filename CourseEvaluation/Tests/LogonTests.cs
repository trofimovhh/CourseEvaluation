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
		report.Log(Status.Info, "Login verification with correct username and password.");
		loginPage.Login(userNameLogin, userPassword);

		// Assert
		Assert.IsTrue(inventoryPage.GetVisibleCartButton().Displayed);
		report.Log(Status.Info, "User successfully logs into the system");
	}

	[Test(Description = "Login with empty Username field")]
	public void LoginWithEmptyUsername()
	{
		// Arrange
		var loginPage = new LoginPage(driver);

		// Act
		report.Log(Status.Info, "Login verification with empty string in the username field");
		loginPage.Login(emptyString, userPassword);

		// Assert
		Assert.That(loginPage.LoginErrorNotification(),
			Is.EqualTo(loginPage.GetErrorNotificationUsername()));
		report.Log(Status.Info, "User receives a message: \"Username is required\"");
	}

	[Test(Description = "Login with empty Password and see notification about the requirement of Password data")]
	public void LoginWithEmptyPassword()
	{
		// Arrange
		var loginPage = new LoginPage(driver);

		// Act
		report.Log(Status.Info, "Login verification with empty string in the password field");
		loginPage.Login(userNameLogin, emptyString);

		// Assert
		Assert.AreEqual(loginPage.GetErrorNotificationPassword(), loginPage.LoginErrorNotification());
		report.Log(Status.Info, "User receives a message: \"Password is required\"");
	}

	[Test(Description =
		"Login with incorrect Username and see error notification about incorrect match of any user in this service")]
	public void IncorrectLogin()
	{
		// Arrange
		var loginPage = new LoginPage(driver);

		// Act
		report.Log(Status.Info, "Login verification with incorrect username");
		loginPage.Login(incorrectUsername, userPassword);

		// Assert
		Assert.AreEqual(loginPage.GetStrUsernameAndPassDoNotMatch(), loginPage.LoginErrorNotification());
		report.Log(Status.Info,
			"User receives a message: \"Username and password do not match any user in this service\"");
	}

	[Test(Description =
		"Login with incorrect Password and see error notification about incorrect match of any user in this service")]
	public void IncorrectPassword()
	{
		// Arrange
		var loginPage = new LoginPage(driver);

		// Act
		report.Log(Status.Info, "Login verification with incorrect username");
		loginPage.Login(userNameLogin, incorrectPassword);

		// Assert
		Assert.AreEqual(loginPage.GetStrUsernameAndPassDoNotMatch(), loginPage.LoginErrorNotification());
		report.Log(Status.Info,
			"User receives a message: \"Username and password do not match any user in this service\"");
	}
}