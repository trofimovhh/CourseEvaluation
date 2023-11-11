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
		loginPage.Login(UserData.userNameLogin, UserData.userPassword);
		report.Log(Status.Info, "User successfully logs into the system");

		//Act
		report.Log(Status.Info, "User sorts products alphabetically from A to Z");
		inventoryPage.ClickSortContainerAtoZButton();

		//Assert
		Assert.That(inventoryPage.SortListAToZ(), Is.EqualTo(inventoryPage.GetItemsSuiteString()));
		report.Log(Status.Info, "Items are sorted from A to Z");
	}

	[Test(Description = "Test verifies sorting product items from Z to A by alphabetic")]
	public void NameZtoA()
	{
		//Arrange
		var loginPage = new LoginPage(driver);
		var inventoryPage = new InventoryPage(driver);
		loginPage.Login(UserData.userNameLogin, UserData.userPassword);
		report.Log(Status.Info, "User successfully logs into the system");

		//Act
		report.Log(Status.Info, "User sorts products alphabetically from Z to A");
		inventoryPage.ClickSortContainerZtoAButton();

		//Assert
		Assert.That(inventoryPage.SortListZToA(), Is.EqualTo(inventoryPage.GetItemsSuiteString()));
		report.Log(Status.Info, "Items are sorted from Z to A");
	}

	[Test(Description = "Test verifies sorting product items by price from low to high")]
	public void PriceLowToHigh()
	{
		//Arrange
		var loginPage = new LoginPage(driver);
		var inventoryPage = new InventoryPage(driver);
		loginPage.Login(UserData.userNameLogin, UserData.userPassword);
		report.Log(Status.Info, "User successfully logs into the system");

		//Act
		report.Log(Status.Info, "User sorts products by ascending price");
		inventoryPage.ClickPriceLowToHighButton();

		//Assert
		Assert.That(inventoryPage.SortPriceLowToHigh(), Is.EqualTo(inventoryPage.GetPriceItemsFromPage()));
		report.Log(Status.Info, "Items are sorted by price from low to high");
	}

	[Test(Description = "Test verifies sorting product items by price from high to low")]
	public void PriceHighToLow()
	{
		//Arrange
		var loginPage = new LoginPage(driver);
		var inventoryPage = new InventoryPage(driver);
		loginPage.Login(UserData.userNameLogin, UserData.userPassword);
		report.Log(Status.Info, "User successfully logs into the system");

		//Act
		report.Log(Status.Info, "User sorts products by descending price");
		inventoryPage.ClickPriceHighToLowButton();

		//Assert
		Assert.That(inventoryPage.SortPriceHighToLow(), Is.EqualTo(inventoryPage.GetPriceItemsFromPage()));
		report.Log(Status.Info, "Items are sorted by price from high to low");
	}
}