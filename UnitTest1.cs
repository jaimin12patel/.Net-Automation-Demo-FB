using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;


namespace Tests
{
    public class Tests
    {
        IWebDriver driver;
        [SetUp]
        public void Setup_Chrome()
        {
            driver = new ChromeDriver("/Users/DIPAKPATEL/Documents/webdriver");
            driver.Url = "https://www.facebook.com";
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Login_Negative_Empty_Username_pass()
        {
            //Writing email with only space
            IWebElement email = driver.FindElement(By.Id("email"));
            email.SendKeys("       ");

            //Writing pass with only Space
            IWebElement pass = driver.FindElement(By.Id("pass"));
            pass.SendKeys("         ");

            //Click on Submit Button to verify the error message on different page.
            IWebElement sub = driver.FindElement(By.Id("u_0_2"));
            sub.Click();

            //Checking displed error message
            IWebElement err = driver.FindElement(By.XPath("//*[@id=\"globalContainer\"]/div[3]/div/div/div"));
            err.Text.Contains("The email or phone number you’ve entered doesn’t match any account. Sign up for an account.");

        }

        [TearDown]
        public void close_chrome()
        {
            driver.Quit();
        } 
    }
}