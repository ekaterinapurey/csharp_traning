using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Reflection;
using AddressBookTests;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
          
            if (!app.Contacts.ContactExists()) //  контакт не существует
            {
                ContactData contact = new ContactData("Ivan");
                contact.Middlename = "Ivanovich";
                app.Contacts.Create(contact);

            }

            List<ContactData> oldContacts = ContactData.GetAll();

            ContactData toBeRemoved = oldContacts[0];
            app.Contacts.Remove(toBeRemoved);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }


        }
    }
}
