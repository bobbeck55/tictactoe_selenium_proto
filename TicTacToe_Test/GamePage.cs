
using OpenQA.Selenium;
using Boa.Constrictor.Selenium;
using static Boa.Constrictor.Selenium.WebLocator;


namespace TicTacToe_Test
{
    public class GamePage
    {
        public static IWebLocator ToggleButton => L(
            "Toggle Button",
            By.XPath("//button[@type='submit']"));
        public static IWebLocator Status => L(
            "Game Status",
            By.XPath("//div[@class='status']"));

    };

}

