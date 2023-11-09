using OpenQA.Selenium;

namespace CourseEvaluation.Pages;

public class ConfirmationPage : WebDriverInit
{
	public ConfirmationPage(IWebDriver driver)
	{
		WebDriverInit.driver = driver;
	}

	public string GetGratitudeNotification()
	{
		return driver.FindElement(By.XPath("//h2[text()='Thank you for your order!']")).Text;
	}
}