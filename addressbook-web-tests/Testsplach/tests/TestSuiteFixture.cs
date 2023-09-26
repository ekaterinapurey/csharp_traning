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
        public static ApplicationManager app;

        [OneTimeSetUp]
		public void InitApplicationManager()
		{
			app = new ApplicationManager();
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));

        }
		[OneTimeTearDown]

		public void StopApplicationManager()
		{
            app.Stop();

        }

    }
}

