using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Nunit_FB_Test_Demo.BaseClass;
using System.Threading;


namespace Nunit_FB_Test_Demo
{
    [TestFixture]
    public class Login_Negative_Scenario : Configuring_The_chrome
    {
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
            Thread.Sleep(3000);

            //Checking displed error message
            var err = driver.FindElement(By.XPath("//*[@id=\"globalContainer\"]/div[3]/div/div/div")).Text;
            Console.Write("Actual Message" + err);
            string expectedTooltip = "The email or phone number you’ve entered doesn’t match any account. Sign up for an account.";
            Assert.AreEqual(expectedTooltip, err);
        }

        [Test]
        public void Login_Negative_Invalid_pass()
        {
            //Writing Valid email with
            IWebElement email = driver.FindElement(By.Id("email"));
            email.SendKeys("jaimin12patel@gmail.com");

            //Writing pass with only Space
            IWebElement pass = driver.FindElement(By.Id("pass"));
            pass.SendKeys("         ");
            

            //Click on Submit Button to verify the error message on different page.
            IWebElement sub = driver.FindElement(By.Id("u_0_2"));
            sub.Click();
            Thread.Sleep(3000);


            //Checking displed error message
            var err = driver.FindElement(By.XPath("//*[@id=\"globalContainer\"]/div[3]/div/div/div")).Text;
            Console.Write("Actual Message" + err);
            string expectedTooltip = "The password you’ve entered is incorrect. Forgot Password?";
            Assert.AreEqual(expectedTooltip, err);
        }
    }
}
