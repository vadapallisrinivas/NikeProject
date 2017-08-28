//Author : Srinivas Vadapalli

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace NikeFlipKart.Tests
{

	[TestFixture]
	class TestRunner : Baseclass
	{

		FlipkartSearchPage flipkartsearchpage;
		ProductPage productpage;
		CartPage cartpage;

		[Test]
		public void verifyPrice()
		{
			flipkartsearchpage = new FlipkartSearchPage();
			flipkartsearchpage.enterSearchString();
			flipkartsearchpage.lowestPrice();
			flipkartsearchpage.clickOnLowestPriceShoe();


			productpage = new ProductPage();
			int actualPrice = productpage.getProductPrice();
			productpage.addItemToCart();

			cartpage = new CartPage();
			int expectedPrice = cartpage.finalCartPrice();
			Assert.AreEqual(actualPrice, expectedPrice);
		}
	}
}
