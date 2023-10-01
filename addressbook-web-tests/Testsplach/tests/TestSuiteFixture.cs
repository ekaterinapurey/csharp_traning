using System;
using NUnit.Framework;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Reflection;

namespace WebAddressbookTests
{
	[SetUpFixture]
	public class TestSuiteFixture
	{
        [OneTimeSetUp]
		public void InitApplicationManager()
		{
            ApplicationManager app = ApplicationManager.GetInstance();
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));

        }

    }
}

