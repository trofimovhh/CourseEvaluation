using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CourseEvaluation;

public class  WebDriverInit
{
	protected static IWebDriver driver;
	private ExtentReports extent;
	private ExtentTest test;

	[OneTimeSetUp]
	public void OneTimeSetUp()
	{
		extent = new ExtentReports();
		var spark = new ExtentSparkReporter(
			@"C:\Users\user\RiderProjects\CourseEvaluation\CourseEvaluation\Reports\Report.html");
		extent.AttachReporter(spark);
	}

	[OneTimeTearDown]
	public void OneTimeTearDown()
	{
		extent.Flush();
	}


	[SetUp]
	public void SetUp()
	{
		test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
		driver = new ChromeDriver();
		driver.Url = "https://www.saucedemo.com";
		driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
	}

	[TearDown]
	public void Close()
	{
		driver.Quit();
		var status = TestContext.CurrentContext.Result.Outcome.Status;
		var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
			? ""
			: string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
		Status logstatus;
		switch (status)
		{
			case TestStatus.Failed:
				logstatus = Status.Fail;
				break;
			default:
				logstatus = Status.Pass;
				break;
		}

		test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
	}
}