using OpenQA.Selenium;

namespace CourseEvaluation.Pages;

public class ItemPage : WebDriverInit
{
	private readonly By addToCartButton = By.Id("add-to-cart-sauce-labs-backpack");
	private readonly By cartButton = By.XPath("//div[@id='shopping_cart_container']/a");

	public ItemPage(IWebDriver driver)
	{
		WebDriverInit.driver = driver;
	}

	public void ClickAddToCartButton()
	{
		driver.FindElement(addToCartButton).Click();
	}

	public void ClickCartButton()
	{
		driver.FindElement(cartButton).Click();
	}
}