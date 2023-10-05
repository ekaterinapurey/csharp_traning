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

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            ContactData newContact = new ContactData("Иван");
            newContact.Firstname = "Иван";
            newContact.Middlename = "Чижиков";
            app.Contacts.Modify(0, newContact);
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0] = newContact;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);



        }
    }
}