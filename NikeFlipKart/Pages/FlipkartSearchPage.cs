//Author : Srinivas Vadapalli

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace NikeFlipKart
{
	class FlipkartSearchPage : Baseclass
	{

		string searchItem = "Nike Shoe";

		[FindsBy(How = How.ClassName, Using = "LM6RPg")]
		private IWebElement txtfkSearch { get; set; }

		[FindsBy(How = How.ClassName, Using = "vh79eN")]
		private IWebElement btSearchIcon { get; set; }

		[FindsBy(How = How.XPath, Using = ".//*[@class='_2_hjz5']/ul/li[3]")]
		private IWebElement btlowestPrice { get; set; }

		[FindsBy(How = How.ClassName, Using = "_3liAhj")]
		private IWebElement btLowesPricetShoe { get; set; }

		[FindsBy(How = How.XPath, Using = ".//*[@id='swatch-0-size']/a")]
		private IWebElement btlowestsize { get; set; }

		public FlipkartSearchPage()
		{

			PageFactory.InitElements(Config.PropertiesCollection.driver, this);
		}


		public void enterSearchString()
		{
			System.Console.WriteLine("----- Searching shoe -----");
			waitFor(3);

			
			txtfkSearch.SendKeys(searchItem);
			waitFor(3);
			btSearchIcon.Click();
		}

		public void lowestPrice()
		{
			System.Console.WriteLine("----- Setting Lowest Price order -----");
			waitFor(3);
			btlowestPrice.Click();
		}

		public ProductPage clickOnLowestPriceShoe()
		{
			waitFor(3);
			
			IList<IWebElement> shoelist = Config.PropertiesCollection.driver.FindElements(By.ClassName("_3liAhj"));

			//Multi Window handler
			string winHandleBefore = Config.PropertiesCollection.driver.CurrentWindowHandle;

			waitFor(3);
			shoelist[0].Click();  //opens new window sometimes

			string winHandleafter = Config.PropertiesCollection.driver.CurrentWindowHandle;
			Config.PropertiesCollection.driver.SwitchTo().Window(winHandleafter);

			List<string> lstWindow = Config.PropertiesCollection.driver.WindowHandles.ToList();
			foreach (var handle in lstWindow)
			{
				Console.WriteLine("Windows ID >>" + handle);
				Config.PropertiesCollection.driver.SwitchTo().Window(handle);

			}

			return new ProductPage();
		}

	}

}
