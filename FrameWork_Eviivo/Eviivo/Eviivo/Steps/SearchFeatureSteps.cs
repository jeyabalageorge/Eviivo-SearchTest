using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Eviivo.Steps
{
    
    [Binding]
    public class SearchFeatureSteps
    {
        IWebDriver driver;
        // Given conditions start here
        [Given(@"User has launched http://toprooms\.com/ website")]
        public void GivenUserHasLaunchedHttpToprooms_ComWebsite()
        {
            driver = new ChromeDriver();
            driver.Url = "http://toprooms.com/";
            driver.Manage().Window.Maximize();
        }

        [Given(@"User has Not typed any location in search box")]
        public void GivenUserHasNotTypedAnyLocationInSearchBox()
        {
            driver.FindElement(By.XPath("//*[@id='eviivo-search-destination']")).SendKeys("");
            Thread.Sleep(5000);
        }

        [Given(@"User has typed the InValid location in search box")]
        public void GivenUserHasTypedTheInValidLocationInSearchBox()
        {
            driver.FindElement(By.XPath("//*[@id='eviivo-search-destination']")).SendKeys("France");
            Thread.Sleep(5000);
        }


        [Given(@"User has typed the Valid location in search box")]
        public void GivenUserHasTypedTheValidLocationInSearchBox()
        {
            driver.FindElement(By.XPath("//*[@id='eviivo-search-destination']")).SendKeys("London");
            Thread.Sleep(5000);
            
            driver.FindElement(By.XPath("//*[@class='ui-menu-item-geoname ui-menu-item'][7]")).Click();
            Thread.Sleep(5000);
                       
        }

        // Given conditions Finish here

        // When conditions start here
        [When(@"User click the search button")]
        public void WhenUserClickTheSearchButton()
        {
        driver.FindElement(By.XPath("//*[@id='eviivo-search-button']")).Click();
            Thread.Sleep(5000);
        }

        // when conditions Finish here

        // Then statements start here

        [Then(@"Error message is shown in tooltip above the search box")]
        public void ThenErrorMessageIsShownInTooltipAboveTheSearchBox()
        {
            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='eviivo-search-destination-tooltip']")).Displayed);
            Thread.Sleep(5000);
        }

        
        [Then(@"the result is listed on the page")]
        public void ThenTheResultIsListedOnThePage()
        {
            

            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='results-holder']/h1")).Displayed);
            Thread.Sleep(5000);
            
        }

        [Then(@"tooltip to check availablity is dispalyed near checkin date box\.")]
        public void ThenTooltipToCheckAvailablityIsDispalyedNearCheckinDateBox_()
        {
            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='datepicker-tooltip']")).Displayed);
            Thread.Sleep(5000);
        }

        // Then statements finish here


    }
}
