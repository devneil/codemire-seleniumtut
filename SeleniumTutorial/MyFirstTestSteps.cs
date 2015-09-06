using FluentAssertions;
using NUnit.Framework;
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
            _driver.Dispose();
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
        }

    }
}
