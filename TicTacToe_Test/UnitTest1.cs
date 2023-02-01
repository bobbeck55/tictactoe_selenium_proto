using System;
using OpenQA.Selenium;
using PercyIO.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using Boa.Constrictor.Screenplay;
using Boa.Constrictor.Selenium;

namespace TicTacToe_Tests
{
    [TestFixture]
    public class CommonTests
    {

        private TicTacToeTests tests;

        public CommonTests()
        {
            tests = new TicTacToeTests();
        }
        [OneTimeSetUp]
        public void OneTimeSetUp() => tests.OneTimeSetUp();

        [OneTimeTearDown]
        public void OneTimeTearDown() => tests.OneTimeTearDown();

        [SetUp]
        public void Setup() => tests.Setup();

        [TearDown]
        public void Teardown() => tests.Teardown();

    }

    [TestFixture("Chrome")]

    public class TicTacToeTests
    {
        private IWebDriver driver;
        private IActor Actor;

        public TicTacToeTests()
        {

        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Actor = new Actor(name: "Bob", logger: new ConsoleLogger());

            ChromeOptions chromeOptions = new ChromeOptions();
            driver = new ChromeDriver(chromeOptions);
            Assert.That(driver, Is.Not.Null);
            Actor.Can(BrowseTheWeb.With(driver));

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

        }

        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void Teardown()
        {

        }

        [Test]
        [Category("Daily")]
        public void TC001()
        {

        }

    }
}