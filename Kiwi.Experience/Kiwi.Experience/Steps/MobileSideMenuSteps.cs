using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using Xunit;
using TechTalk.SpecFlow;

namespace Kiwi.Experience.Steps
{
    [Binding]
    public class MobileSideMenuSteps
    {
        [Given(@"user has visited the Kiwi Experience site on mobile")]
        public void GivenUserHasVisitedTheKiwiExperienceSiteOnMobile()
        {
            SeleniumHelper.StartMobileDriver();
        }

        [Given(@"clicks on the hamburger menu")]
        public void GivenClicksOnTheHamburgerMenu()
        {
            SeleniumHelper.ClickHamburger();
        }

        [Then(@"user should see a list of options to navigate the site (.*)")]
        public void ThenUserShouldSeeAListOfOptionsToNavigateTheSite(string slideOutMenu)
        {
            var mobileMenu = SeleniumHelper.WebDriver.FindElement(By.CssSelector("#menu-main"));
            Assert.Contains(slideOutMenu, mobileMenu.Text);
        }

        
    }
}
