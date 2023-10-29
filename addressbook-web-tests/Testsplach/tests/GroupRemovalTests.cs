using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Reflection;
using System.Collections.Generic;
using AddressBookTests;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {

            app.Navigator.GoToGroupsPage();
            if (!app.Groups.GroupExists())
            {
                GroupData group = new GroupData("x");
                group.Header = "x";
                group.Footer = "x";

                app.Groups.Create(group);
            }

            List<GroupData> oldGroups = GroupData.GetAll();

            GroupData toBeRemoved = oldGroups[0];
            app.Groups.Remove(toBeRemoved);

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }

        }
    }
}
