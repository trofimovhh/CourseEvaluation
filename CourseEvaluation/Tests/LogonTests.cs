using CourseEvaluation;
using NUnit.Framework;
using static CourseEvaluation.Data.UserData;


public class LogonTests : WebDriverInit
{
	[Test(Description = "Login with correct Username and Password")]
	public void CorrectLoginPassword()
	{
		// Arrange
		LoginPage loginPage = new LoginPage(driver);
		InventoryPage inventoryPage = new InventoryPage(driver);

		// Act
		loginPage.Login(userNameLogin, userPassword);
		
		// Assert
		Assert.IsTrue(inventoryPage.GetVisibleCartButton().Displayed);
	}

	[Test(Description = "Login with empty Username field")]
	public void LoginWithEmptyUsername()
	{
		// Arrange
		LoginPage loginPage = new LoginPage(driver);

		// Act
		loginPage.Login(emptyString, userPassword);
		
		// Assert
		Assert.That(loginPage.LoginErrorNotification(),
			Is.EqualTo(loginPage.GetErrorNotificationUsername()));
	}

	[Test(Description = "Login with empty Password and see notification about the requirement of Password data")]
	public void LoginWithEmptyPassword()
	{
		LoginPage loginPage = new LoginPage(driver);

		loginPage.Login(userNameLogin, emptyString);
		Assert.AreEqual(loginPage.GetErrorNotificationPassword(), loginPage.LoginErrorNotification());
	}

	[Test(Description = "Login with empty Username and Password and see error notification")]
	public void LoginWithEmptyUsernameAndPassword()
	{
		LoginPage loginPage = new LoginPage(driver);

		loginPage.Login(emptyString, emptyString);
		Assert.AreEqual(loginPage.GetErrorNotificationUsername(), loginPage.LoginErrorNotification());
	}

	[Test(Description =
		"Login with incorrect Username and see error notification about incorrect match of any user in this service")]
	public void IncorrectLogin()
	{
		LoginPage loginPage = new LoginPage(driver);

		loginPage.Login(incorrectUsername, userPassword);
		Assert.AreEqual(loginPage.GetStrUsernameAndPassDoNotMatch(), loginPage.LoginErrorNotification());
	}

	[Test(Description =
		"Login with incorrect Password and see error notification about incorrect match of any user in this service")]
	public void IncorrectPassword()
	{
		LoginPage loginPage = new LoginPage(driver);

		loginPage.Login(userNameLogin, incorrectPassword);
		Assert.AreEqual(loginPage.GetStrUsernameAndPassDoNotMatch(), loginPage.LoginErrorNotification());
	}

	[Test(Description =
		"Login with incorrect Username and Password and see error notification about incorrect match of any user in this service")]
	public void IncorrectLoginAndPassword()
	{
		LoginPage loginPage = new LoginPage(driver);

		loginPage.Login(incorrectUsername, incorrectPassword);
		Assert.AreEqual(loginPage.GetStrUsernameAndPassDoNotMatch(), loginPage.LoginErrorNotification());
	}
}