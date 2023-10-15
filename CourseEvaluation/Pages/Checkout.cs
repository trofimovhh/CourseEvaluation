using OpenQA.Selenium;

namespace CourseEvaluation.Pages;

public class Checkout
{
	private IWebDriver driver;

	public Checkout(IWebDriver driver)
	{
		this.driver = driver;
	}

	private string errorFirstNameNotification = "Error: First Name is required";
	private string errorLastNameNotification = "Error: Last Name is required";
	private string errorPostalCodeNotification = "Error: Postal Code is required";

	private By firstNameField = By.XPath("//input[@id='first-name']");
	private By lastNameField = By.XPath("//input[@id='last-name']");
	private By postalCodeField = By.XPath("//input[@id='postal-code']");
	private By continueButton = By.Id("continue");
	private By errorNotification = By.XPath("//h3");

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