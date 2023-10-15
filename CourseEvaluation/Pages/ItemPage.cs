using OpenQA.Selenium;

namespace CourseEvaluation.Pages;

public class ItemPage
{
	private IWebDriver driver;

	public ItemPage(IWebDriver driver)
	{
		this.driver = driver;
	}

	private By addToCartButton = By.Id("add-to-cart-sauce-labs-backpack");
	private By cartButton = By.XPath("//div[@id='shopping_cart_container']/a");

	public void ClickAddToCartButton()
	{
		driver.FindElement(addToCartButton).Click();
	}

	public void ClickCartButton()
	{
		driver.FindElement(cartButton).Click();
	}
}