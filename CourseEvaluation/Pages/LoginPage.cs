using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace CourseEvaluation.Pages;

public class LoginPage : TestBase
{
	public LoginPage(IWebDriver driver)
	{
		TestBase.driver = driver;
	}

	private string errorNotificationPassword = "Epic sadface: Password is required";
	private string errorNotificationUsername = "Epic sadface: Username is required";

	private string errorUsernameAndPassDoNotMatch =
		"Epic sadface: Username and password do not match any user in this service";

	private IWebElement usernameInput = driver.FindElement(By.XPath("//input[@id='user-name']"));
	private IWebElement passwordInput = driver.FindElement(By.XPath("//input[@id='password']"));
	private IWebElement loginButton = driver.FindElement(By.Id("login-button"));

	public void Login(string login, string password)
	{
		usernameInput.SendKeys(login);
		// report.Log(Status.Info, $"Text \"{login}\" entered in the username field");
		passwordInput.SendKeys(password);
		// report.Log(Status.Info, $"Text \"{password}\" entered in the password field");
		loginButton.Click();
		// report.Log(Status.Info, "\"Login\" button clicked");
	}

	public string GetErrorNotificationUsername()
	{
		return errorNotificationUsername;
	}

	public string GetErrorNotificationPassword()
	{
		return errorNotificationPassword;
	}

	public string LoginErrorNotification()
	{
		return driver.FindElement(By.XPath("//h3[@data-test='error']")).Text;
	}

	public string GetStrUsernameAndPassDoNotMatch()
	{
		return errorUsernameAndPassDoNotMatch;
	}
}