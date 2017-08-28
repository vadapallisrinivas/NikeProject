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
	class ProductPage : Baseclass
	{

		[FindsBy(How = How.XPath, Using = ".//*[@id='swatch-0-size']/a")]
		private IWebElement txtShoeSize { get; set; }

		[FindsBy(How = How.XPath, Using = ".//*[@id='container']/div/div[1]/div/div/div/div[1]/div/div[1]/div[2]/ul/li[1]/button")]
		private IWebElement btAddCart { get; set; }

		[FindsBy(How = How.XPath, Using = "//*[@id='container']/div/div[1]/div/div/div/div[1]/div/div[2]/div[2]/div[3]/div/div/div[1]")]
		private IWebElement lbPrice { get; set; }


		public ProductPage()
		{
			PageFactory.InitElements(Config.PropertiesCollection.driver, this);
		}

		public int getProductPrice()
		{
			waitFor(3);
			int price = formatprice(lbPrice.Text);
			return price;
		}

		public CartPage addItemToCart()
		{
			waitFor(3);
			txtShoeSize.Click();
			waitFor(3);
			btAddCart.Click();
			waitFor(3);
			return new CartPage();
		}

	}
}
