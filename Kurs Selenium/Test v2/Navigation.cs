using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Kurs_Selenium.Test_v2
{
	class Navigation
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

		public void GoToUrlTest()
		{
			driver.Navigate().GoToUrl("https://google.pl");
			string expectedUrl = "https://www.google.pl/";
			Assert.AreEqual(expectedUrl, driver.Url, "Url is not correct");

		}

		[Test]

		public void BackTest()
		{
			string expectedUrl = "https://www.google.pl/";
			string wpplURL = "https://www.wp.pl/";

			driver.Navigate().GoToUrl("https://google.pl");
			driver.Navigate().GoToUrl("https://www.wp.pl/");
			driver.Navigate().Back();
			Assert.AreEqual(expectedUrl, driver.Url, "Url is not correct");	

		}

		[Test]

		public void ForwardTest()
		{
			string expectedUrl = "https://www.google.pl/";
			string wpplUrl = "https://www.wp.pl/";

			
			driver.Navigate().GoToUrl("https://www.wp.pl/");
			driver.Navigate().GoToUrl("https://google.pl");
			driver.Navigate().Back();
			driver.Navigate().Forward();
			Assert.AreEqual(expectedUrl, driver.Url, "Url is not correct");

		}

		[Test]

		public void RefreshTest()
		{
			string ebayUrl = "https://www.ebay.com/";
			driver.Navigate().GoToUrl(ebayUrl);
			driver.Navigate().Refresh();
			Thread.Sleep(10000);

		}

		[TearDown]

		public void QuitDriver()
		{
			driver.Quit();
		}
	}
}
