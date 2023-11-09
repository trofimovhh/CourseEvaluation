using CourseEvaluation.Data;
using CourseEvaluation.Pages;
using NUnit.Framework;

namespace CourseEvaluation.Tests;

public class SortTests : WebDriverInit
{
	[Test(Description = "Test verifies sorting product items from A to Z by alphabetic")]
	public void NameAtoZ()
	{
		//Arrange
		var loginPage = new LoginPage(driver);
		var inventoryPage = new InventoryPage(driver);
		loginPage.Login(UserData.userNameLogin, UserData.userPassword);

		//Act
		inventoryPage.ClickSortContainerAtoZButton();

		//Assert
		Assert.That(inventoryPage.SortListAToZ(), Is.EqualTo(inventoryPage.GetItemsSuiteString()));
	}

	[Test(Description = "Test verifies sorting product items from Z to A by alphabetic")]
	public void NameZtoA()
	{
		//Arrange
		var loginPage = new LoginPage(driver);
		var inventoryPage = new InventoryPage(driver);
		loginPage.Login(UserData.userNameLogin, UserData.userPassword);

		//Act
		inventoryPage.ClickSortContainerZtoAButton();

		//Assert
		Assert.That(inventoryPage.SortListZToA(), Is.EqualTo(inventoryPage.GetItemsSuiteString()));
	}

	[Test(Description = "Test verifies sorting product items by price from low to high")]
	public void PriceLowToHigh()
	{
		//Arrange
		var loginPage = new LoginPage(driver);
		var inventoryPage = new InventoryPage(driver);
		loginPage.Login(UserData.userNameLogin, UserData.userPassword);

		//Act
		inventoryPage.ClickPriceLowToHighButton();

		//Assert
		Assert.That(inventoryPage.SortPriceLowToHigh(), Is.EqualTo(inventoryPage.GetPriceItemsFromPage()));
	}

	[Test(Description = "Test verifies sorting product items by price from high to low")]
	public void PriceHighToLow()
	{
		//Arrange
		var loginPage = new LoginPage(driver);
		var inventoryPage = new InventoryPage(driver);
		loginPage.Login(UserData.userNameLogin, UserData.userPassword);

		//Act
		inventoryPage.ClickPriceHighToLowButton();

		//Assert
		Assert.That(inventoryPage.SortPriceHighToLow(), Is.EqualTo(inventoryPage.GetPriceItemsFromPage()));
	}
}