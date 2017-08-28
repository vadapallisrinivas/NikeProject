//Author : Srinivas Vadapalli

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeFlipKart
{

	class Baseclass
	{


		[OneTimeSetUp]
		public void driverInitialize()
		{
			Config.PropertiesCollection.driver = new ChromeDriver();
			Config.PropertiesCollection.driver.Url = "https://www.flipkart.com/";
			System.Console.WriteLine("----- Chrome Driver intialized -----");

			//intiating wait for elements.
			WebDriverWait wait = new WebDriverWait(Config.PropertiesCollection.driver, TimeSpan.FromMinutes(1));
			Config.PropertiesCollection.driver.Manage().Window.Maximize();
		}

		public int formatprice(string price)
		{
			int shoeprice = 0;
			price = price.Replace(",", "");
			int.TryParse(price.Substring(1), out shoeprice);
			return shoeprice;
		}

		public void waitFor(int seconds)
		{
			Config.PropertiesCollection.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
		}


		[OneTimeTearDown]
		public void cleanUp()
		{
			Config.PropertiesCollection.driver.Quit();
			System.Console.WriteLine("----- Completed Nunit Tests -----");
		}
	}
}