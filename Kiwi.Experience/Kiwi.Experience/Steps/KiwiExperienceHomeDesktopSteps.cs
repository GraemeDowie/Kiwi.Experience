using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using Xunit;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Linq;

namespace Kiwi.Experience.Steps
{
    [Binding]
    public class KiwiExperienceHomeDesktopSteps
    {
        [Given(@"user has visited the homepage on desktop")]
        public void GivenUserHasVisitedTheHomepageOnDesktop()
        {
           SeleniumHelper.StartDriver();
        }
        
        [Then(@"user should see the special message bar text in purple")]
        public void ThenUserShouldSeeTheSpecialMessageBarTextInPurple(Table table)
        {
            var text = table.CreateInstance<SpecialMessage>();

            var actualMessage = SeleniumHelper.WebDriver.FindElement(By.CssSelector(".specialMessageBar"));
            Assert.Equal(text.specialMessage, actualMessage.Text);

            var textColor = table.CreateInstance<SpecialMessageColor>();

            var messageColor = SeleniumHelper.WebDriver.FindElement(By.CssSelector(".specialMessageBar"));
            Assert.Equal(textColor.specialMessageColor, messageColor.GetCssValue("color"));
        }

        [Then(@"the language of the page should be in English")]
        public void ThenTheLanguageOfThePageShouldBeInEnglish()
        {
            var engGB = SeleniumHelper.WebDriver.FindElement(By.CssSelector("#top_lang_btn > span.top-flag-gb.top-flag")).GetAttribute("class");
            Assert.Equal("top-flag-gb top-flag", engGB);

            var gbENG = SeleniumHelper.WebDriver.FindElement(By.CssSelector("#top_lang_btn > span.top-flag-gb.top-flag > span")).Text;
            Assert.Equal("ENG", gbENG);
        }

        [When(@"user clicks on the Golden Packpacker award image")]
        public void WhenUserClicksOnTheGoldenPackpackerAwardImage()
        {
            var goldBackPack = SeleniumHelper.WebDriver.FindElement(By.CssSelector(".floatingElement"));
            goldBackPack.Click();

            SeleniumHelper.WebDriver.SwitchTo().Window(SeleniumHelper.WebDriver.WindowHandles.Last());
        }

        [Then(@"it should take the user to a blog article about the award")]
        public void ThenItShouldTakeTheUserToABlogArticleAboutTheAward()
        {
            var pageURL = SeleniumHelper.WebDriver.Url;

            Assert.Equal("https://www.kiwiexperience.com/blog/kiwi-experience-takes-home-the-gold", pageURL);

            var blogPageHeading = SeleniumHelper.WebDriver.FindElement(By.CssSelector("#body > div.onBlogPostPage > div > article > h2:nth-child(1)"));
            Assert.Equal("KIWI EXPERIENCE TAKES HOME A DOUBLE WIN AT THE GOLDEN BACKPACKER AWARDS!", blogPageHeading.Text);
        }

    }
}
