using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Reflection;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            if (!app.Contacts.ContactExists()) //  контакт не существует
            {
                ContactData contact = new ContactData("Ivan");
                contact.Middlename = "Ivanovich";
                app.Contacts.Create(contact);

            }
            app.Contacts.Remove(1);

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts.Count, newContacts.Count);


        }
    }
}
