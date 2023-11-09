using CourseEvaluation;
using OpenQA.Selenium;

public class OrderOverviewPage: WebDriverInit
{
	private IWebDriver driver;

	public OrderOverviewPage(IWebDriver driver)
	{
		WebDriverInit.driver = driver;
	}

	private By finishButton = By.Id("finish");
	private By cancelButton = By.Id("cancel");

	public void ClickFinishButton()
	{
		driver.FindElement(finishButton).Click();
	}

	public void ClickCancelButton()
	{
		driver.FindElement(cancelButton).Click();
	}
}