using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Kiwi.Experience.Steps
{
    [Binding]
    public class NationalBusPassSteps
    {
        [Given(@"user has visited the kiwi experience home page on dektop")]
        public void GivenUserHasVisitedTheKiwiExperienceHomePageOnDektop()
        {
            SeleniumHelper.StartDriver();
        }
        
        [Given(@"user clicks on the whole kit and caboodle bus pass option")]
        public void GivenUserClicksOnTheWholeKitAndCaboodleBusPassOption()
        {
            var wholeKitCaboddleConfirm = SeleniumHelper.WebDriver.FindElement(By.CssSelector("#specialItemCarousel > a:nth-child(1) > div > div.specialItem_contentContainer > div.passName"));
            Assert.Equal("THE WHOLE KIT & CABOODLE\r\nMeet Your Moment", wholeKitCaboddleConfirm.Text);

            SeleniumHelper.wholeKitCabbodleLink();
        }
        
        [Then(@"user should be on the whole kit and caboodle page with three bus pass options")]
        public void ThenUserShouldBeOnTheWholeKitAndCaboodlePageWithThreeBusPassOptions(Table table)
        {
            var wholeKitCaboodleURL = SeleniumHelper.WebDriver.Url;
            Assert.Equal("https://www.kiwiexperience.com/book-your-nz-trip/kiwi-experience-deals#the-whole-kit-and-caboodle", wholeKitCaboodleURL);

            var passOne = table.CreateInstance<BusPassOne>();
            var passTwo = table.CreateInstance<BusPassTwo>();
            var passThree = table.CreateInstance<BusPassThree>();

            var wholeKitCaboodlePass = SeleniumHelper.WebDriver.FindElement(By.CssSelector("#the-whole-kit-and-caboodle > div > div > a:nth-child(1) > div.top.gutterItem > div > div.name"));
            Assert.Equal(passOne.busPassOne, wholeKitCaboodlePass.Text);

            var funkyChickenPass = SeleniumHelper.WebDriver.FindElement(By.CssSelector("#funky-chicken > div > div > a:nth-child(1) > div.top.gutterItem > div > div.name"));
            Assert.Equal(passTwo.busPassTwo, funkyChickenPass.Text);

            var northernRoundupPass = SeleniumHelper.WebDriver.FindElement(By.CssSelector("#northern-round-up > div > a:nth-child(1) > div > div.top.gutterItem > div > div.name"));
            Assert.Equal(passThree.busPassThree, northernRoundupPass.Text);
        }

        [When(@"user clicks on the view pass button")]
        public void WhenUserClicksOnTheViewPassButton()
        {
            var confirmViewPassLink = SeleniumHelper.WebDriver.FindElement(By.CssSelector("#the-whole-kit-and-caboodle > div > a.style2.yellow.btn")).GetAttribute("href");
            Assert.Equal("https://www.kiwiexperience.com/book-your-nz-trip/nz-bus-pass/the-whole-kit-and-caboodle", confirmViewPassLink);

            var selectToViewPass = SeleniumHelper.WebDriver.FindElement(By.CssSelector("#the-whole-kit-and-caboodle > div > a.style2.yellow.btn"));
            selectToViewPass.Click();
        }

        [Then(@"user should see the whole kit and caboodle summary content")]
        public void ThenUserShouldSeeTheWholeKitAndCaboodleSummaryContent(Table table)
        {
            var viewWholeKitCaboodlePassURL = SeleniumHelper.WebDriver.Url;
            Assert.Equal("https://www.kiwiexperience.com/book-your-nz-trip/nz-bus-pass/the-whole-kit-and-caboodle", viewWholeKitCaboodlePassURL);

            var passPriceNZ = table.CreateInstance<PriceNZ>();
            var passPriceAud = table.CreateInstance<PriceAUD>();
            var passtart = table.CreateInstance<Start>();
            var passFinish = table.CreateInstance<Finish>();
            var passTravelTime = table.CreateInstance<TravelTime>();
            var passCardholderDiscount = table.CreateInstance<CardholderDiscount>();

            var bussPassPriceNZ = SeleniumHelper.WebDriver.FindElement(By.CssSelector("div.summaryContent > table > tbody > tr:nth-child(1) > td.content"));
            Assert.Contains(passPriceNZ.priceNZ, bussPassPriceNZ.Text);

            var bussPassPriceAud = SeleniumHelper.WebDriver.FindElement(By.CssSelector("div.summaryContent > table > tbody > tr:nth-child(1) > td.content"));
            Assert.Contains(passPriceAud.priceAud, bussPassPriceAud.Text);

            var bussPassStart = SeleniumHelper.WebDriver.FindElement(By.CssSelector("div.summaryContent > table > tbody > tr:nth-child(2) > td.content"));
            Assert.Equal(passtart.start, bussPassStart.Text);

            var busPassFinish = SeleniumHelper.WebDriver.FindElement(By.CssSelector("div.summaryContent > table > tbody > tr:nth-child(3) > td.content"));
            Assert.Equal(passFinish.finish, busPassFinish.Text);

            var busPassTravelTIme = SeleniumHelper.WebDriver.FindElement(By.CssSelector("div.summaryContent > table > tbody > tr:nth-child(4) > td.content"));
            Assert.Equal(passTravelTime.travelTime, busPassTravelTIme.Text);

            var busPassCardHolder = SeleniumHelper.WebDriver.FindElement(By.CssSelector("div.summaryContent > table > tbody > tr:nth-child(5) > td.content"));
            Assert.Equal(passCardholderDiscount.cardholderDiscount, busPassCardHolder.Text);
        }

    }
}
