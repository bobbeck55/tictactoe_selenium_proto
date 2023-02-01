using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Boa.Constrictor.Selenium;
using static Boa.Constrictor.Selenium.WebLocator;
using Boa.Constrictor.Screenplay;

namespace TicTacToe_Test
{



    class TicTacToe_Test
    {
        String test_url = "http://localhost:3000/";
        public static IWebLocator ToggleButton => L(
            "Toggle Button",
            By.XPath("//button[@type='submit']"));
        public static IWebLocator SquareTopRowFarLeftCell => L(
            "Game board - top row, far left cell",
            By.XPath("//div[1]/button[@class='square'][1]"));

        public static IWebLocator SquareTopRowMiddleCell => L(
            "Game board - top row, middle cell",
            By.XPath("//div[1]/button[@class='square'][2]"));

        public static IWebLocator SquareTopRowFarRightCell => L(
            "Game board - top row, far right cell",
            By.XPath("//div[@class='board-row']/button[@class='square']"));

        public static IWebLocator SquareMiddleRowFarLeftCell => L(
    "Game board - middle row, far left cell",
    By.XPath("//div[2]/button[@class='square'][1]"));

        public static IWebLocator SquareMiddleRowMiddleCell => L(
            "Game board - middle row, middle cell",
            By.XPath("//div[2]/button[@class='square'][2]"));

        public static IWebLocator SquareMiddleRowFarRightCell => L(
            "Game board - middle row, far right cell",
            By.XPath("//div[2]/button[@class='square'][3]"));

        public static IWebLocator SquareBottomRowFarLeftCell => L(
            "Game board - bottom row, far left cell",
            By.XPath("//div[3]/button[@class='square'][1]"));

        public static IWebLocator SquareBottomRowMiddleCell => L(
            "Game board - bottom row, middle cell",
            By.XPath("//div[3]/button[@class='square'][2]"));

        public static IWebLocator SquareBottomRowFarRightCell => L(
            "Game board - bottom row, far right cell",
            By.XPath("//div[3]/button[@class='square'][3]"));


        private IWebDriver driver;
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
            if (!profileUrl.Contains(test_url))
            {
                Console.WriteLine("not at url");
            }
        }

        [Test]
        public void Test_Win_X()
        {

            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> li = driver.FindElements(By.XPath("//div/button[@class='square']"));

            li[1].Click();
            li[4].Click();


        }

        [Test]
        public void Test_Win_O()
        {

        }

        [Test]
        public void Test_Draw()
        {

        }

        [Test]
        public void ToggleMoveHistoryOrder()
        {
            Actor.AttemptsTo(Click.On(ToggleButton));
        }
        [TearDown]
        public void close_Browser()
        {
            driver.Quit();
        }
    }
}