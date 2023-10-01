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
	[TestFixture]
	public class LoginTests : TestBase
	{
		[Test]
		public void LoginWithValidCredentials()
		{
			//Prepare(подготовка)
			app.Auth.Logout();

			//action (действие)
			AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);

			//verification (проверка)
			Assert.IsTrue(app.Auth.IsLoggedIn(account));
		}

        [Test]
        public void LoginWithInvalidCredentials()
        {
            //Prepare(подготовка)
            app.Auth.Logout();

            //action (действие)
            AccountData account = new AccountData("admin", "123456");
            app.Auth.Login(account);

            //verification (проверка)
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}

