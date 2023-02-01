using Xunit;
using System;
using OpenQA.Selenium;
using PercyIO.Selenium;
using OpenQA.Selenium.Chrome;

namespace Server.Test;

public class TestsFixture : IDisposable
{
    public readonly ChromeDriver driver;

    public TestsFixture()
    {
        //new DriverManager().SetUpDriver(new ChromeConfig());
        ChromeOptions options = new();
        options.AddArgument("--headless");

        driver = new(options);
    }

    public void Dispose()
    {
        driver.Quit();
    }
}

public class ExampleTests : IClassFixture<TestsFixture>
{
    public readonly ChromeDriver driver;

    public ExampleTests(TestsFixture data)
    {
        driver = data.driver;
        driver.Navigate().GoToUrl("http://localhost:3000");
    }

    [Fact]
    public void EmptyTodo()
    {
        Percy.Snapshot(driver, "Empty Todo State");
    }

    [Fact]
    public void WithIncompleteTodo()
    {
        driver.FindElement(By.ClassName("square")).Click();
        Percy.Snapshot(driver, "With a Todo");
    }

    [Fact]
    public void WithCompletedTodo()
    {
        driver.FindElement(By.ClassName("status")).Click();
        Percy.Snapshot(driver, "Completed Todo");
    }
}
