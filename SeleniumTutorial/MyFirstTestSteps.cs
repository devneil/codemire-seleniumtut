using FluentAssertions;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace SeleniumTutorial
{
    [Binding]
    public class MyFirstTestSteps
    {
        private ChromeDriver _driver;

        [Given(@"I can navigate to Google")]
        public void GivenICanNavigateToGoogle()
        {
            _driver = new ChromeDriver();
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
            _driver.Dispose();
        }

    }
}
