using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using System.Diagnostics;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static Random random = new Random();
        public static string GenerateRandomString(int max)
        {
            const string src = "abcdefghijklmnopqrstuvwxyz0123456789";
            string randomString = "";
         
            for (var i = 0; i < max; i++)
            {
                string result = src[random.Next(0, src.Length)].ToString();
                randomString += (String.Concat(result.Where(c => !Char.IsWhiteSpace(c))));
            }
            return randomString;
        }

    }
}