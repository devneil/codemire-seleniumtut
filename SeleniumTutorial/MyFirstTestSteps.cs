using System;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace SeleniumTutorial
{
    [Binding]
    public class MyFirstTestSteps
    {
        private ChromeDriver _driver;

        [BeforeScenario]
        public void SetUp()
        {
            _driver = new ChromeDriver();   
        }

        [AfterScenario]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Status == TestStatus.Failed)
            {
                string filename = CleanFileName(GetTestName());
                _driver.GetScreenshot().SaveAsFile(filename + ".jpg", ImageFormat.Jpeg);
            }

            _driver.Dispose();
        }

        private string GetTestName()
        {
            return TestContext.CurrentContext.Test.Name;
        }

        private string CleanFileName(string fname)
        {
            string invalidChars = Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars()));
            string invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);

            return Regex.Replace(fname, invalidRegStr, "_");

        }

        [Given(@"I can navigate to Google")]
        public void GivenICanNavigateToGoogle()
        {
            _driver.Navigate().GoToUrl("http://google.com");
        }

        [When(@"I search for muppets")]
        public void WhenISearchForMuppets()
        {
            _driver.FindElementById("lst-ib").SendKeys("muppets");
            _driver.FindElementByClassName("lsb").Click();
        }

        [Then(@"I should see an image")]
        public void ThenIShouldSeeAnImage()
        {
            _driver.FindElementsByTagName("img").Count.Should().BeGreaterThan(0);
            throw new Exception();
        }

    }
}
