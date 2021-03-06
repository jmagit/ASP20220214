// Generated by Selenium IDE
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
[TestFixture]
public class PaseoTest {
  private IWebDriver driver;
  public IDictionary<string, object> vars {get; private set;}
  private IJavaScriptExecutor js;
  [SetUp]
  public void SetUp() {
    driver = new ChromeDriver();
    js = (IJavaScriptExecutor)driver;
    vars = new Dictionary<string, object>();
  }
  [TearDown]
  protected void TearDown() {
    driver.Quit();
  }
  [Test]
  public void paseo() {
    driver.Navigate().GoToUrl("https://localhost:5001/");
    driver.Manage().Window.Size = new System.Drawing.Size(1535, 815);
    driver.FindElement(By.LinkText("Login")).Click();
    Assert.That(driver.FindElement(By.CssSelector("h1")).Text, Is.EqualTo("Log in"));
    driver.FindElement(By.LinkText("Productos")).Click();
    driver.FindElement(By.CssSelector("tr:nth-child(1) > td:nth-child(1)")).Click();
    Assert.That(driver.FindElement(By.CssSelector("tr:nth-child(1) > td:nth-child(1)")).Text, Is.EqualTo("uno"));
    driver.FindElement(By.LinkText("Edit")).Click();
    driver.FindElement(By.Id("Name")).Click();
    driver.FindElement(By.Id("Name")).SendKeys("Adjustable cambiar");
    driver.FindElement(By.Id("StandardCost")).Click();
    driver.FindElement(By.Id("StandardCost")).Click();
    driver.FindElement(By.Id("StandardCost")).SendKeys("0.00");
    driver.FindElement(By.CssSelector(".btn")).Click();
    {
      var element = driver.FindElement(By.Id("ListPrice-error"));
      Actions builder = new Actions(driver);
      builder.MoveToElement(element).Release().Perform();
    }
    Assert.That(driver.FindElement(By.Id("ListPrice-error")).Text, Is.EqualTo("The field ListPrice must be a number."));
  }
}
