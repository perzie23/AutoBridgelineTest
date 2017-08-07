using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeleniumTests
{
    [TestFixture]
    public class AutomationChallenge
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }

        public class Utility()
        {
            public void wait(int timeInSec)
            {
                Thread.Sleep(timeInSec);
            }


        }

        [TestCleanup]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheAutomationChallengeTest()
        {

            //entering diamond jig
            driver.FindElement(By.Id("lst-ib")).SendKeys("diamond jig");
            driver.FindElement(By.Id("lst-ib")).SendKeys(Keys.Tab);
            wait(5);

            //clicking the Search button
            driver.FindElement(By.Name("btnK")).Click();
            wait(5);

            //clicking the Shopping Menu / link
            driver.FindElement(By.LinkText("Shopping")).Click();
            wait(15);

            //clicking the third item
            driver.FindElement(By.Id("srpresultimg_11852383631752803345")).Click();
            wait(10);

            //clicking the Save to Shortlist
            driver.FindElement(By.CssSelector("div.gko-a-lbl")).Click();
            wait(10);

            //clicking to sign in
            driver.FindElement(By.CssSelector("div._-d.sh-gc__c-ad > div._-e > div._-s > div.sh-gc__c-sa")).Click();
            driver.FindElement(By.XPath("(//a[contains(text(),'Sign in')])[3]")).Click();
            wait(5);

            //entering log in name
            driver.FindElement(By.Id("identifierId")).Clear();
            driver.FindElement(By.Id("identifierId")).SendKeys("percybridgeline");

            //clicking next button
            driver.FindElement(By.CssSelector("content.CwaK9")).Click();
            wait(10);

            //entering password
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("percytest123");
            wait(10);

            //clicking Next Button
            driver.FindElement(By.CssSelector("span.RveJvd.snByac")).Click();
            wait(10);

            //viewing shortlist
            driver.FindElement(By.LinkText("View Shortlist")).Click();
            wait(10);

            //adding note to text area
            driver.FindElement(By.XPath("//body/div[3]/div[5]/div[2]/div/div[1]/div[1]/input")).Click();
            wait(10);
            driver.FindElement(By.XPath("//body/div[3]/div[5]/div[2]/div/div[1]/div[2]/textarea")).SendKeys("Please buy me");
            driver.FindElement(By.XPath("//body/div[3]/div[5]/div[2]/div/div[1]/div[2]/div[2]/div[1]")).Click();
            wait(5);


        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
