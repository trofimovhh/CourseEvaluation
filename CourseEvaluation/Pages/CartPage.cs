using OpenQA.Selenium;

namespace CourseEvaluation.Pages;

public class CartPage : WebDriverInit
{
	private readonly By checkoutButton = By.Id("checkout");
	private readonly By continueShoppingButton = By.Id("continue-shopping");
	private readonly By listOfItems = By.ClassName("cart_item");

	private readonly By removeButton =
		By.XPath("//div[@class='cart_list']/div[@class='cart_item'][1]//button[text()='Remove']");

	private readonly By removeButtons = By.XPath("//button[@class='btn_secondary cart_button']");

	public CartPage(IWebDriver driver)
	{
		WebDriverInit.driver = driver;
	}

	public void RemoveOneItemFromCart()
	{
		driver.FindElement(removeButton).Click();
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
	}

	public void ClickContinueShoppingButton()
	{
		driver.FindElement(continueShoppingButton).Click();
	}
}