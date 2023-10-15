using OpenQA.Selenium;

namespace CourseEvaluation.Pages;

public class HomePage : WebDriverInit
{
	private By sauceLabsBackpack = By.XPath("//div[text()='Sauce Labs Backpack']");

	private By addCartSauceLabsBackpackToCartButton =
		By.Id("add-to-cart-sauce-labs-backpack");

	private By cartButton = By.XPath("//div[@id='shopping_cart_container']/a");
	private By itemsSuite = By.XPath("//div[@class='inventory_item']//div[@class='inventory_item_name']");
	private By addToCartButtons = By.XPath("//button[@class='btn_primary btn_inventory']");

	public HomePage(IWebDriver driver)
	{
		WebDriverInit.driver = driver;
	}

	public int GetItemsSuiteInt()
	{
		List<IWebElement> itemsSuiteList = driver.FindElements(itemsSuite).ToList();
		return itemsSuiteList.Count;
	}

	public IWebElement GetVisibleCartButton()
	{
		IWebElement visibleCartButton = driver.FindElement(cartButton);
		return visibleCartButton;
	}

	public void ClickSauceLabsBackpack()
	{
		driver.FindElement(sauceLabsBackpack).Click();
	}

	public void ClickAddCartSauceLabsBackpackButton()
	{
		driver.FindElement(addCartSauceLabsBackpackToCartButton).Click();
	}

	public void ClickCartButton()
	{
		driver.FindElement(cartButton).Click();
	}

	public void AddAllItemsOfProductsToCart()
	{
		List<IWebElement> allProductsAddToCartButtons = driver.FindElements(addToCartButtons).ToList();
		foreach (var button in allProductsAddToCartButtons)
		{
			button.Click();
		}
	}
}