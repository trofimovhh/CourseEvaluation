using OpenQA.Selenium;

namespace CourseEvaluation.Pages;

public class ConfirmationPage
{
	private IWebDriver driver;

	public ConfirmationPage(IWebDriver driver)
	{
		this.driver = driver;
	}

	public string GetGratitudeNotification()
	{
		return driver.FindElement(By.XPath("//h2[text()='Thank you for your order!']")).Text;
	}
}