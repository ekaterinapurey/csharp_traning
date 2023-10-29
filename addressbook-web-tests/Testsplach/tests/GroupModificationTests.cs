using System;
using NUnit.Framework;
using System.Text;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using OpenQA.Selenium;
using System.Security.Cryptography;
using AddressBookTests;

namespace WebAddressbookTests
{

    [TestFixture]

	public class GroupModificationTests : GroupTestBase
    {


    [Test]
    public void GroupModificationTest()
    {
            if (!app.Groups.GroupExists())  //группа не существует
            {
                GroupData group = new GroupData("аа");
                group.Header = "";
                group.Footer = "";

                app.Groups.Create(group);
            }


            List<GroupData> oldGroups = GroupData.GetAll();

            GroupData toBeModify = oldGroups[0];
            toBeModify.Name = "zzz";
            toBeModify.Header = null;
            toBeModify.Footer = null;

            app.Groups.Modify(toBeModify);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());


            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0] = toBeModify;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }

}