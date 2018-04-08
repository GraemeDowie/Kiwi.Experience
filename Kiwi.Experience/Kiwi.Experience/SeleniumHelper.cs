using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiwi.Experience
{
    class SeleniumHelper
    {
        private static IWebDriver _webdriver;
        public static IWebDriver WebDriver
        {
            get
            {
                if(_webdriver == null)
                {
                    _webdriver = new ChromeDriver();
                }
                return _webdriver;
            }
        }

        public static IWebDriver StartMobileDriver()
        {
            WebDriver.Url = "https://www.kiwiexperience.com";
            WebDriver.Manage().Window.Size = new System.Drawing.Size(375, 812);

            return WebDriver;
        }

        public static IWebDriver StartDriver()
        {
            WebDriver.Url = "https://www.kiwiexperience.com";
            WebDriver.Manage().Window.Maximize();

            return WebDriver;
        }

        public static void ClickHamburger()
        {
            var clickHamburger = WebDriver.FindElement(By.CssSelector(".c-hamburger"));
            clickHamburger.Click();
        }

        public static void wholeKitCabbodleLink()
        {
            var wholeKitcabbodle = SeleniumHelper.WebDriver.FindElement(By.CssSelector("#specialItemCarousel > a:nth-child(1) > div > div.bookNowBtn"));
            wholeKitcabbodle.Click();
        }
    }
}
