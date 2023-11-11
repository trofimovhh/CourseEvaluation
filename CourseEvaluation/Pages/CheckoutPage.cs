using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using OpenQA.Selenium;

namespace CourseEvaluation.Pages;

public class CheckoutPage : TestBase
{
	private readonly By continueButton = By.Id("continue");

	private readonly string errorFirstNameNotification = "Error: First Name is required";
	private readonly string errorLastNameNotification = "Error: Last Name is required";
	private readonly By errorNotification = By.XPath("//h3");
	private readonly string errorPostalCodeNotification = "Error: Postal Code is required";

	private readonly By firstNameField = By.XPath("//input[@id='first-name']");
	private readonly By lastNameField = By.XPath("//input[@id='last-name']");
	private readonly By postalCodeField = By.XPath("//input[@id='postal-code']");

	public CheckoutPage(IWebDriver driver)
	{
		TestBase.driver = driver;
	}

	public void FillFields(string firstname, string lastName, string postalCode)
	{
		driver.FindElement(firstNameField).SendKeys(firstname);
		driver.FindElement(lastNameField).SendKeys(lastName);
		driver.FindElement(postalCodeField).SendKeys(postalCode);
	}

	public void ClickContinueButton()
	{
		driver.FindElement(continueButton).Click();
	}

	public string GetErrorFirstNameNotification()
	{
		return errorFirstNameNotification;
	}

	public string GetErrorLastNameNotification()
	{
		return errorLastNameNotification;
	}

	public string GetErrorPostalCodeNotification()
	{
		return errorPostalCodeNotification;
	}

	public string GetErrorNotification()
	{
		return driver.FindElement(errorNotification).Text;
	}
}