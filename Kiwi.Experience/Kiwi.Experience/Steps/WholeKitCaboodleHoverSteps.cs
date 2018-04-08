using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using Xunit;
using TechTalk.SpecFlow;

namespace Kiwi.Experience.Steps
{
    [Binding]
    public class WholeKitCaboodleHoverSteps
    {
        [Given(@"user has visited the whole kit ad caboodle bus pass page")]
        public void GivenUserHasVisitedTheWholeKitAdCaboodleBusPassPage()
        {
            SeleniumHelper.WebDriver.Url = ("https://www.kiwiexperience.com/book-your-nz-trip/nz-bus-pass/the-whole-kit-and-caboodle");
            SeleniumHelper.WebDriver.Manage().Window.Maximize();
        }
        
        [When(@"user hovers on the unlimited travel icon in the summary container")]
        public void WhenUserHoversOnTheUnlimitedTravelIconInTheSummaryContainer()
        {
            var hoverUnlimited = SeleniumHelper.WebDriver.FindElement(By.CssSelector("section.summary > div.panel > a > div"));

            Actions unlimitedHover = new Actions(SeleniumHelper.WebDriver);
            unlimitedHover.MoveToElement(hoverUnlimited).Perform();
        }

        [Then(@"user should see information displayed via a tool tip")]
        public void ThenUserShouldSeeInformationDisplayedViaAToolTip()
        {
            var tooltip = SeleniumHelper.WebDriver.FindElement(By.CssSelector("section.summary > div.panel > a")).GetAttribute("title");
            Assert.NotEqual("Unlimited Travel - once you have completed your pass in full, you can go around again and again for 12 months.", tooltip);
        }

        [When(@"user hovers on the minimum (.*)days question mark")]
        public void WhenUserHoversOnTheMinimumDaysQuestionMark(int p0)
        {
            var questionMark = SeleniumHelper.WebDriver.FindElement(By.CssSelector("section.summary > div.panel > div.summaryContent > table > tbody > tr:nth-child(4) > td.content > div"));

            Actions hoverQuestionMark = new Actions(SeleniumHelper.WebDriver);
            hoverQuestionMark.MoveToElement(questionMark).Perform();
        }

        [Then(@"user should see the tooltip text diplayed")]
        public void ThenUserShouldSeeTheTooltipTextDiplayed()
        {
            var tooltipVisible = SeleniumHelper.WebDriver.FindElement(By.ClassName("tooltiptext")).GetCssValue("visibility");
            Assert.Equal("visible", tooltipVisible);
        }

    }
}
