using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using OpenQA.Selenium;

namespace CourseEvaluation.Pages;

public class CartPage : TestBase
{
	private By checkoutButton = By.Id("checkout");
	private By continueShoppingButton = By.Id("continue-shopping");
	private By listOfItems = By.ClassName("cart_item");
	private By removeButton = By.XPath("//div[@class='cart_list']/div[@class='cart_item'][1]//button[text()='Remove']");
	private By removeButtons = By.XPath("//button[@class='btn_secondary cart_button']");

	public CartPage(IWebDriver driver)
	{
		TestBase.driver = driver;
	}

	public void RemoveOneItemFromCart()
	{
		driver.FindElement(removeButton).Click();
		report.Log(Status.Info, "\"Remove\" button is clicked");
	}

	public void RemoveAllItemsFromCart()
	{
		var removeButtonsList = new List<IWebElement>(driver.FindElements(removeButtons));
		foreach (var button in removeButtonsList) button.Click();
	}

	public int ListOfItems()
	{
		var items = new List<IWebElement>(driver.FindElements(listOfItems));
		return items.Count;
	}

	public void ClickCheckoutButton()
	{
		driver.FindElement(checkoutButton).Click();
		report.Log(Status.Info, "\"Checkout\" button is clicked");
	}

	public void ClickContinueShoppingButton()
	{
		driver.FindElement(continueShoppingButton).Click();
		report.Log(Status.Info, "\"Continue Shopping\" button is clicked");
	}
}