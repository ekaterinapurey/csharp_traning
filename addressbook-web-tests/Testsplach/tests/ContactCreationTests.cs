using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationsTests : TestBase
    {

        [Test]
        public new void ContactCreationTest()
        {
            ContactData contact = new ContactData("Иван");
            contact.Firstname = "Иван";
            contact.Middlename = "Рыжиков";

            app.Contacts.Create(contact);
        }
    }
}
