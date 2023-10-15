using OpenQA.Selenium;

namespace CourseEvaluation.Pages;

public class Finish
{
	private IWebDriver driver;

	public Finish(IWebDriver driver)
	{
		this.driver = driver;
	}

	public string GetGratitudeNotification()
	{
		return driver.FindElement(By.XPath("//h2[text()='Thank you for your order!']")).Text;
	}
}