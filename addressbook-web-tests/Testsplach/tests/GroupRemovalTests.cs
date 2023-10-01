using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Reflection;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            if (!app.Groups.GroupExists()) //  группа не существует
            {
                GroupData group = new GroupData("x");
                group.Header = "x";
                group.Footer = "x";

                app.Groups.Create(group);
            }
            app.Groups.Remove(0);
            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);


        }
    }
}
