using System;//1
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
 

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {

        [Test]
        public void GroupCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitNewGroupCreation();
            ReturnToGroupsPage();
            GroupData group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "fff";

            app.Groups.Create(group);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Groups.Create(group);
        }
    }
}
