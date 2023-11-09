using CourseEvaluation;
using OpenQA.Selenium;

public class InventoryPage : WebDriverInit
{
	private By sauceLabsBackpack = By.XPath("//div[text()='Sauce Labs Backpack']");

	private By addCartSauceLabsBackpackToCartButton =
		By.Id("add-to-cart-sauce-labs-backpack");

	private By cartButton = By.XPath("//div[@id='shopping_cart_container']/a");
	private By itemsSuite = By.XPath("//div[@class='inventory_item']//div[@class='inventory_item_name ']");
	private By addToCartButtons = By.XPath("//button[@class='btn_primary btn_inventory']");
	private By sortContainer = By.XPath("//select[@class='product_sort_container']");
	private By sortAtoZButton = By.XPath("//select[@class='product_sort_container']//option[@value='az']");
	private By sortZtoAButton = By.XPath("//select[@class='product_sort_container']//option[@value='za']");
	private By sortPriceLowToHigh = By.XPath("//select[@class='product_sort_container']//option[@value='lohi']");
	private By sortPriceHighToLow = By.XPath("//select[@class='product_sort_container']//option[@value='hilo']");
	private By sidebarButton = By.XPath("//div[@class='bm-burger-button']");
	private By allItemsLink = By.XPath("//a[@id='inventory_sidebar_link']");
	private By aboutLink = By.XPath("//a[@id='about_sidebar_link']");
	private By logoutLink = By.XPath("//a[@id='logout_sidebar_link']");
	private By itemsPrice = By.XPath("//div[@class='inventory_item_price']");

	public InventoryPage(IWebDriver driver)
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
	public List<string> SortListAToZ()
	{
		List<string> obtainedList = new List<string>();
		List<IWebElement> elementList = driver.FindElements(itemsSuite).ToList();

		foreach (var element in elementList)
		{
			obtainedList.Add(element.Text);
		}

		obtainedList.Sort();
		return obtainedList;
	}

	public List<string> SortListZToA()
	{
		List<string> obtainedList = new List<string>();
		List<IWebElement> elementList = driver.FindElements(itemsSuite).ToList();

		foreach (var element in elementList)
		{
			obtainedList.Add(element.Text);
		}

		obtainedList.Sort();
		obtainedList.Reverse();
		return obtainedList;
	}

	public List<string> GetNotSortedItemList()
	{
		List<string> obtainedList = new List<string>();
		List<IWebElement> itemsList = driver.FindElements(itemsSuite).ToList();

		foreach (var element in itemsList)
		{
			obtainedList.Add(element.Text);
		}

		return obtainedList;
	}

	public List<double> SortPriceLowToHigh()
	{
		List<IWebElement> priceItems = driver.FindElements(itemsPrice).ToList();
		List<string> sortLowHigh = new List<string>();
		List<double> price = new List<double>();

		foreach (var element in priceItems)
		{
			sortLowHigh.Add(element.Text);
		}

		foreach (var item in sortLowHigh)
		{
			price.Add(double.Parse(item.Replace("$", "").Replace(".", ",")));
		}

		price.Sort();
		return price;
	}

	public List<double> SortPriceHighToLow()
	{
		List<IWebElement> priceItems = driver.FindElements(itemsPrice).ToList();
		List<string> sortLowHigh = new List<string>();
		List<double> price = new List<double>();

		foreach (var element in priceItems)
		{
			sortLowHigh.Add(element.Text);
		}

		foreach (var item in sortLowHigh)
		{
			price.Add(double.Parse(item.Replace("$", "").Replace(".", ",")));
		}

		price.Sort();
		price.Reverse();
		return price;
	}

	public List<double> GetPriceItemsFromPage()
	{
		List<IWebElement> priceItems = driver.FindElements(itemsPrice).ToList();
		List<double> price = new List<double>();

		foreach (var element in priceItems)
		{
			price.Add(double.Parse(element.Text.Replace("$", "").Replace(".", ",")));
		}

		return price;
	}

	public void AddSeveralItemsToCart()
	{
		List<IWebElement> buttonAddToCart = driver.FindElements(By.XPath("//button[text()='ADD TO CART']")).ToList();
		for (int i = 0; i < 3; i++)
		{
			buttonAddToCart[i].Click();
		}
	}

	public List<string> GetItemsSuiteString()
	{
		List<IWebElement> obtainedList = driver.FindElements(itemsSuite).ToList();
		List<string> itemsList = new List<string>();

		foreach (var element in obtainedList)
		{
			itemsList.Add(element.Text);
		}

		return itemsList;
	}

	public void ClickSideBarButton()
	{
		driver.FindElement(sidebarButton).Click();
	}

	public void ClickAllItemsButton()
	{
		driver.FindElement(allItemsLink).Click();
	}

	public void ClickAboutButton()
	{
		driver.FindElement(aboutLink).Click();
	}

	public string GetCurrentURL()
	{
		return driver.Url;
	}

	public void ClickLogoutButton()
	{
		driver.FindElement(logoutLink).Click();
	}

	public void ClickSortContainer()
	{
		driver.FindElement(sortContainer).Click();
		driver.FindElement(sortAtoZButton).Click();
	}

	public void ClickSortContainerAtoZButton()
	{
		driver.FindElement(sortContainer).Click();
		driver.FindElement(sortAtoZButton).Click();
	}

	public void ClickSortContainerZtoAButton()
	{
		driver.FindElement(sortContainer).Click();
		driver.FindElement(sortZtoAButton).Click();
	}

	public void ClickPriceLowToHighButton()
	{
		driver.FindElement(sortContainer).Click();
		driver.FindElement(sortPriceLowToHigh).Click();
	}

	public void ClickPriceHighToLowButton()
	{
		driver.FindElement(sortContainer).Click();
		driver.FindElement(sortPriceHighToLow).Click();
	}
}