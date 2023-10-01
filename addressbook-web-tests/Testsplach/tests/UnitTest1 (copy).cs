//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            IWebDriver driver = null;
            int attempt = 0;

            do
            {
                System.Threading.Thread.Sleep(1000);
                attempt++;

            }
            while (driver.FindElements(By.Id("test")).Count == 0 && attempt < 60);
        }
    }
}
