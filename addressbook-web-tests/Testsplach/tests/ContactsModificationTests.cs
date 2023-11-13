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

	public class ContactModificationTests : ContactTestBase
    {


    [Test]
    public void ContactModificationTest()
    {
            if (!app.Contacts.ContactExists()) //  контакт не существует
            {
                ContactData contact = new ContactData("Ivan");
                contact.Lastname = "Ivanov";
                contact.Middlename = "Ivanovich";
                app.Contacts.Create(contact);
            }

            List<ContactData> oldContacts = ContactData.GetAll();

            ContactData toBeModified = oldContacts[0];
            toBeModified.Lastname = "Пупкин";
            toBeModified.Firstname = "Петя";
            toBeModified.Middlename = "Саныч";
            app.Contacts.Modify(toBeModified);

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts[0] = toBeModified;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);



        }
    }
}