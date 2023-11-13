using AventStack.ExtentReports;
using CourseEvaluation.Data;
using CourseEvaluation.Pages;
using NUnit.Framework;

namespace CourseEvaluation.Tests;

public class SortTests : TestBase
{
	[Test(Description = "Test verifies sorting product items from A to Z by alphabetic")]
	public void NameAtoZ()
	{
		//Arrange
		var loginPage = new LoginPage(driver);
		var inventoryPage = new InventoryPage(driver);
		report.Log(Status.Info, "User logs into the system");
		loginPage.Login(UserData.userNameLogin, UserData.userPassword);

		//Act
		report.Log(Status.Info, "User sorts products alphabetically from A to Z");
		inventoryPage.ClickSortContainerAtoZButton();

		//Assert
		report.Log(Status.Info, "Items are sorted from A to Z");
		Assert.That(inventoryPage.SortListAToZ(), Is.EqualTo(inventoryPage.GetItemsSuiteString()));
	}

	[Test(Description = "Test verifies sorting product items from Z to A by alphabetic")]
	public void NameZtoA()
	{
		//Arrange
		var loginPage = new LoginPage(driver);
		var inventoryPage = new InventoryPage(driver);
		report.Log(Status.Info, "User logs into the system");
		loginPage.Login(UserData.userNameLogin, UserData.userPassword);

		//Act
		report.Log(Status.Info, "User sorts products alphabetically from Z to A");
		inventoryPage.ClickSortContainerZtoAButton();

		//Assert
		report.Log(Status.Info, "Items are sorted from Z to A");
		Assert.That(inventoryPage.SortListZToA(), Is.EqualTo(inventoryPage.GetItemsSuiteString()));
	}

	[Test(Description = "Test verifies sorting product items by price from low to high")]
	public void PriceLowToHigh()
	{
		//Arrange
		var loginPage = new LoginPage(driver);
		var inventoryPage = new InventoryPage(driver);
		report.Log(Status.Info, "User logs into the system");
		loginPage.Login(UserData.userNameLogin, UserData.userPassword);

		//Act
		report.Log(Status.Info, "User sorts products by ascending price");
		inventoryPage.ClickPriceLowToHighButton();

		//Assert
		report.Log(Status.Info, "Items are sorted by price from low to high");
		Assert.That(inventoryPage.SortPriceLowToHigh(), Is.EqualTo(inventoryPage.GetPriceItemsFromPage()));
	}

	[Test(Description = "Test verifies sorting product items by price from high to low")]
	public void PriceHighToLow()
	{
		//Arrange
		var loginPage = new LoginPage(driver);
		var inventoryPage = new InventoryPage(driver);
		report.Log(Status.Info, "User logs into the system");
		loginPage.Login(UserData.userNameLogin, UserData.userPassword);

		//Act
		report.Log(Status.Info, "User sorts products by descending price");
		inventoryPage.ClickPriceHighToLowButton();

		//Assert
		report.Log(Status.Info, "Items are sorted by price from high to low");
		Assert.That(inventoryPage.SortPriceHighToLow(), Is.EqualTo(inventoryPage.GetPriceItemsFromPage()));
	}
}