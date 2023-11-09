using CourseEvaluation;
using OpenQA.Selenium;

public class LoginPage : WebDriverInit
{
	public LoginPage(IWebDriver driver)
	{
		WebDriverInit.driver = driver;
	}
	
	private string errorNotificationUsername = "Epic sadface: Username is required";
	private string errorNotificationPassword = "Epic sadface: Password is required";

	private string errorUsernameAndPassDoNotMatch =
		"Epic sadface: Username and password do not match any user in this service";

	public void Login(string login, string password)
	{
		driver.FindElement(By.XPath("//input[@id='user-name']")).SendKeys(login);
		driver.FindElement(By.XPath("//input[@id='password']")).SendKeys(password);
		driver.FindElement(By.Id("login-button")).Click();
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