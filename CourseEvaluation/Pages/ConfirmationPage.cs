using OpenQA.Selenium;

namespace CourseEvaluation.Pages;

public class ConfirmationPage : TestBase
{
	public ConfirmationPage(IWebDriver driver)
	{
		TestBase.driver = driver;
	}

	public string GetGratitudeNotification()
	{
		return driver.FindElement(By.XPath("//h2[text()='Thank you for your order!']")).Text;
	}
}