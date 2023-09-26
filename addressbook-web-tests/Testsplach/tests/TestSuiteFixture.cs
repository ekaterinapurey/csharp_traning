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

        [SetUp]
		public void InitApplicationManager()
		{
			app = new ApplicationManager();
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));

        }
		[TearDown]

		public void StopApplicationManager()
		{
            app.Stop();

        }

    }
}

