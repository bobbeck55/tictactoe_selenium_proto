using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Boa.Constrictor.Selenium;
using Boa.Constrictor.Screenplay;
using PercyIO.Selenium;

namespace TicTacToe_Test
{
    class TicTacToe_Test
    {
        String test_url = "http://localhost:3000/";
        private ChromeDriver driver;
        private IActor Actor;

        [SetUp]
        public void Setup()
        {
            // Local Selenium WebDriver
            ChromeOptions options = new();
            //options.AddArgument("--headless");
            driver = new ChromeDriver(options);
            Assert.That(driver, Is.Not.Null);
            driver.Url = test_url;
            driver.Manage().Window.Maximize();
            Actor = new Actor(name: "Bob", logger: new ConsoleLogger());
            Assert.That(Actor, Is.Not.Null);
            Actor.Logger.Log("In OneTimeSetUp");
            Actor.Can(BrowseTheWeb.With(driver));
            string profileUrl = Actor.AsksFor(CurrentUrl.FromBrowser());
            Assert.That(profileUrl, Is.EqualTo(test_url));
        }

        [Test]
        public void Test_Win_X()
        {
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> li = driver.FindElements(By.XPath(BoardPage.SquaresCollection));

            li[2].Click();
            li[4].Click();
            li[8].Click();
            li[7].Click();
            li[5].Click();

            Actor.WaitsUntil(Appearance.Of(GamePage.Status), IsEqualTo.True());
            string text = Actor.AsksFor(Text.Of(GamePage.Status));
            Assert.That(text, Is.EqualTo("Winner: X"));

            Percy.Snapshot(driver, "Winner: X");
        }

        [Test]
        public void Test_Win_O()
        {
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> li = driver.FindElements(By.XPath(BoardPage.SquaresCollection));

            li[1].Click();
            li[2].Click();
            li[0].Click();
            li[5].Click();
            li[4].Click();
            li[8].Click();

            Actor.WaitsUntil(Appearance.Of(GamePage.Status), IsEqualTo.True());
            string text = Actor.AsksFor(Text.Of(GamePage.Status));
            Assert.That(text, Is.EqualTo("Winner: O"));
            Percy.Snapshot(driver, "Winner: O");
        }

        [Test]
        public void Test_Draw()
        {
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> li = driver.FindElements(By.XPath(BoardPage.SquaresCollection));

            li[1].Click();
            li[2].Click();
            li[4].Click();
            li[7].Click();
            li[5].Click();
            li[3].Click();
            li[0].Click();
            li[8].Click();
            li[6].Click();

            Actor.WaitsUntil(Appearance.Of(GamePage.Status), IsEqualTo.True());
            string text = Actor.AsksFor(Text.Of(GamePage.Status));
            Assert.That(text, Is.EqualTo("Draw"));

            Percy.Snapshot(driver, "Draw");
        }

        [Test]
        public void ToggleMoveHistoryOrder()
        {
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> li = driver.FindElements(By.XPath(BoardPage.SquaresCollection));

            li[1].Click();
            li[2].Click();
            li[0].Click();
            li[5].Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));
            Actor.AttemptsTo(Click.On(GamePage.ToggleButton));
        }
        [TearDown]
        public void close_Browser()
        {
            //driver.Quit();
        }
    }
}