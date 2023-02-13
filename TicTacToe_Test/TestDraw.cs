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
        public void TestDraw()
        {
            Console.WriteLine("TicTacToe_Test::TestDraw");

            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> li = driver.FindElements(By.XPath(BoardPage.SquaresCollection));

            li[1].Click();
            li[5].Click();
            li[7].Click();
            li[4].Click();
            li[3].Click();
            li[6].Click();
            li[2].Click();
            li[0].Click();
            li[8].Click();

            Actor.WaitsUntil(Appearance.Of(GamePage.Status), IsEqualTo.True());
            string text = Actor.AsksFor(Text.Of(GamePage.Status));
            Assert.That(text, Is.EqualTo("Draw"));

            Percy.Snapshot(driver, "Draw");
        }
    }
}
