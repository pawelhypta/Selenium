using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Kurs_Selenium
{
	public class Tests
	{
		IWebDriver driver;

		[SetUp]
		public void Setup()
		{
			driver = new ChromeDriver();
			driver.Manage().Window.Position = new System.Drawing.Point(8, 30);
			driver.Manage().Window.Size = new System.Drawing.Size(1290, 730);

			driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(15);
			driver.Manage().Timeouts().PageLoad = System.TimeSpan.FromSeconds(15);
		}

		[Test]
		public void Test1()
		{
			driver.Navigate().GoToUrl("https://google.pl");
			IWebElement searchField = driver.FindElement(By.CssSelector("[title='Szukaj']"));
			string searchEntry = "Adam Mickiewicz";
			
			searchField.SendKeys(searchEntry);
			searchField.Submit();
 
			string title = "Adam Mickiewicz – Wikipedia, wolna encyklopedia";
			driver.FindElement(By.XPath(".//*[text()='" + title + "']")).Click();

			string entryURL = "https://pl.wikipedia.org/wiki/Adam_Mickiewicz";
			Assert.AreEqual(entryURL, driver.Url, "Url is correct.");

		}

		[TearDown]

		public void QuitDriver()
		{
		driver.Quit();	
		}
	}
}
