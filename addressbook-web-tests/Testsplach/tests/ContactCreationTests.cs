﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationsTests : AuthTestBase
    {

        [Test]
        public void ContactCreationTest()
        {

            ContactData contact = new ContactData("");
            contact.Firstname = "Иван";
            contact.Middlename = "Рыжиков";

            app.Contacts.Create(contact);

        }
    }
}
