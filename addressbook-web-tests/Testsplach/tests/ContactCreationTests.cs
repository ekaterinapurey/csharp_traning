using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactsCreationTests : TestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData ("Иван", "Чижиков");
            contact.Middlename = "Чижиков";
            app.Contacts.Create(contact);

        }
    }
}
