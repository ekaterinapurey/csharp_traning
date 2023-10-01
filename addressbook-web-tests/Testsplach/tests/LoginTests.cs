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
using WebAddressbookTests;

namespace WebAddressBookTests
{
    [TestFixture]
    internal class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            //prepate
            app.Auth.Logout();

            //action
            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);

            //verify
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            //prepate
            app.Auth.Logout();

            //action
            AccountData account = new AccountData("admin", "1234");
            app.Auth.Login(account);

            //verify
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}

