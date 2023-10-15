using OpenQA.Selenium;

namespace CourseEvaluation.Pages;

public class CartPage
{
	private IWebDriver driver;

	public CartPage(IWebDriver driver)
	{
		this.driver = driver;
	}

	private By checkoutButton = By.Id("checkout");
	private By removeButton = By.XPath("//div[@class='cart_list']/div[@class='cart_item'][1]//button[text()='Remove']");
	private By removeButtons = By.XPath("//button[@class='btn_secondary cart_button']");
	private By listOfItems = By.XPath("//div[@class='cart_item']");
	private By continueShoppingButton = By.Id("continue-shopping");

	public void RemoveOneItemFromCart()
	{
		driver.FindElement(removeButton).Click();
	}

	public void RemoveAllItemsFromCart()
	{
		List<IWebElement> removeButtonsList = new List<IWebElement>(driver.FindElements(removeButtons));
		foreach (var button in removeButtonsList)
		{
			button.Click();
		}
	}

	public int ListOfItems()
	{
		List<IWebElement> items = new List<IWebElement>(driver.FindElements(listOfItems));
		return items.Count;
	}

	public void ClickCheckoutButton()
	{
		driver.FindElement(checkoutButton).Click();
	}

	public void ClickContinueShoppingButton()
	{
		driver.FindElement(continueShoppingButton).Click();
	}
}