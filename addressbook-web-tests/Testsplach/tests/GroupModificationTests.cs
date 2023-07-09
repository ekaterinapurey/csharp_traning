using System;
using NUnit.Framework;
using System.Text;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using OpenQA.Selenium;




namespace WebAddressbookTests
{

[TestFixture]

	public class GroupModificationTests : TestBase
	{

    [Test]
    public void GroupModificationTest()
    {
        GroupData newData = new GroupData("zzz");
            newData.Header = "ttt";
            newData.Footer = "qqq";

        app.Groups.Modify(1, newData);
    }
}

}