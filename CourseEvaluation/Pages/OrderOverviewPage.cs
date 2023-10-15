using OpenQA.Selenium;

namespace CourseEvaluation.Pages;

public class OrderOverviewPage
{
	private IWebDriver driver;

	public OrderOverviewPage(IWebDriver driver)
	{
		this.driver = driver;
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