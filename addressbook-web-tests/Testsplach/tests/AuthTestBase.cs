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

namespace WebAddressbookTests
{
	public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetupLogin()
        {
            app.Auth.Login(new AccountData("admin", "secret"));
        }

    }
}

