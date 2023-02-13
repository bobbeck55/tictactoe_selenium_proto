using NUnit.Framework;
using OpenQA.Selenium;
using Boa.Constrictor.Selenium;
using PercyIO.Selenium;

namespace TicTacToe_Test
{
    partial class TicTacToe_Test
    {
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

            Percy.Snapshot(driver, "ToggleMoveHistoryOrder");
        }
    }
}