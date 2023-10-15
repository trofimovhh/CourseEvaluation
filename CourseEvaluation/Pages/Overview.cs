using OpenQA.Selenium;

namespace CourseEvaluation.Pages;

public class Overview
{
	private IWebDriver driver;

	public Overview(IWebDriver driver)
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