using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace CourseEvaluation.Pages;

public class OrderOverviewPage : TestBase
{
	private readonly By cancelButton = By.Id("cancel");

	private readonly By finishButton = By.Id("finish");

	public OrderOverviewPage(IWebDriver driver)
	{
		TestBase.driver = driver;
	}

	public void ClickFinishButton()
	{
		driver.FindElement(finishButton).Click();
	}

	public void ClickCancelButton()
	{
		driver.FindElement(cancelButton).Click();
	}
}