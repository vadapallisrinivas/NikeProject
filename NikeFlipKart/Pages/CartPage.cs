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
	class CartPage : Baseclass
	{

		[FindsBy(How = How.XPath, Using = "//*[@id='container']/div/div[1]/div/div/div[2]/div/div/div[1]/div[2]/div[1]/div[2]")]
		private IWebElement lblCartPrice { get; set; }

		public CartPage()
		{
			PageFactory.InitElements(Config.PropertiesCollection.driver, this);
		}


		public int finalCartPrice()
		{
			waitFor(3);
			return formatprice(lblCartPrice.Text);
		}
	}
}