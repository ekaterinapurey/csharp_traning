﻿using System;
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

            GroupData newData = new GroupData("zzz");
             newData.Header = null;
             newData.Footer = null;

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Modify(0, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());


            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0] = newData;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }

}