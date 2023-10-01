﻿using System;
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

	public class ContactModificationTests : AuthTestBase
	{


    [Test]
    public void ContactModificationTest()
    {
            if (!app.Contacts.ContactExists()) //  контакт не существует
            {
                ContactData contact = new ContactData("Ivan");
                contact.Firstname = "Ivanov";
                contact.Middlename = "Ivanovich";
                app.Contacts.Create(contact);
            }

            ContactData newContact = new ContactData("Иван");
            newContact.Firstname = "Иван";
            newContact.Middlename = "Чижиков";
            app.Contacts.Modify(1, newContact);
    }
  }
}