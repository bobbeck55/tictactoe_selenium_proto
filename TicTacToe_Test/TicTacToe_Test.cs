using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Boa.Constrictor.Selenium;
using Boa.Constrictor.Screenplay;


namespace TicTacToe_Test
{
    partial class TicTacToe_Test
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

            // console log header
            // visual studio version
/*
            try
            {

                System.Diagnostics.ProcessStartInfo procStartInfo =
                    new System.Diagnostics.ProcessStartInfo("cmd", "C:\"\\Program Files\\Microsoft Visual Studio\"\\2022\\Community\\Common7\\Tools\\vsdevcmd.bat");

                // The following commands are needed to redirect the standard output.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                // Do not create the black window.
                procStartInfo.CreateNoWindow = true;
                // Now we create a process, assign its ProcessStartInfo and start it
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                // Get the output into a string
                string result = proc.StandardOutput.ReadToEnd();
                // Display the command output.
                Console.WriteLine(result);
            }
            catch (Exception objException)
            {
                // Log the exception
            }
 */
    // browser and version
    // .dotnet version
    // .sln file

}



        [TearDown]
        public void close_Browser()
        {
            driver.Quit();
        }
    }
}