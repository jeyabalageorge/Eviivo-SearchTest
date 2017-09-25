using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace Eviivo
{
    class TopRoomsSearchTests
    {
        IWebDriver driver;
        [SetUp]
        public void LaunchBrowser()
        {
           driver = new ChromeDriver();
           driver.Url = "http://toprooms.com/";
           driver.Manage().Window.Maximize();
        }
        [Test]
        public void VerifySearchWithEmptyInput()
        {
            driver.FindElement(By.XPath("//*[@id='eviivo-search-destination']")).SendKeys("");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//*[@id='eviivo-search-button']")).Click();
        }
        [Test]
        public void VerifySearchWithInvalidInput()
        {
            driver.FindElement(By.XPath("//*[@id='eviivo-search-destination']")).SendKeys("France");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//*[@id='eviivo-search-button']")).Click();
        }
        [Test]
        public void VerifySearchWithValidInput()
        {
            driver.FindElement(By.XPath("//*[@id='eviivo-search-destination']")).SendKeys("London");
            Thread.Sleep(5000);

            driver.FindElement(By.XPath("//*[@class='ui-menu-item-geoname ui-menu-item'][7]")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//*[@id='eviivo-search-button']")).Click();
        }
        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }

                                  
     }
}
