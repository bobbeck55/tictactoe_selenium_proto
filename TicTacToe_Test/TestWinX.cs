using NUnit.Framework;
using OpenQA.Selenium;
using Boa.Constrictor.Selenium;
using Boa.Constrictor.Screenplay;
using PercyIO.Selenium;

namespace TicTacToe_Test
{
    partial class TicTacToe_Test
    {
        [Test]
        public void TestWinX()
        {
            Console.WriteLine("TicTacToe_Test::TestWinX");

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
    }
}
