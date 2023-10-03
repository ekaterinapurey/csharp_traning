using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationsTests : AuthTestBase
    {

        public static IEnumerable<ContactData> RandomContactProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                );
            }
            return contacts;
        }

        [Test, TestCaseSource("RandomContactProvider")]
        public void ContactCreationTest(ContactData contact)
        {

            //ContactData contact = new ContactData("");
            //contact.Firstname = "Иван";
            //contact.Middlename = "Рыжиков";

            //List<ContactData> oldContacts = app.Contacts.GetContactList();


            app.Contacts.Create(contact);

            //Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());


            //List<ContactData> newContacts = app.Contacts.GetContactList();
            //oldContacts.Add(contact);
            //oldContacts.Sort();
            //newContacts.Sort();
            //Assert.AreEqual(oldContacts.Count, newContacts.Count);



        }

       
    }
}
