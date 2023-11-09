using CourseEvaluation;
using OpenQA.Selenium;

public class ConfirmationPage: WebDriverInit
{
	private IWebDriver driver;

	public ConfirmationPage(IWebDriver driver)
	{
		WebDriverInit.driver = driver;
	}

	public string GetGratitudeNotification()
	{
		return driver.FindElement(By.XPath("//h2[text()='Thank you for your order!']")).Text;
	}
}