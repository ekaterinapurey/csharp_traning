﻿using System;
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
        public void ContactCreationTest()
        {
            app.Navigator.GoToHomePage();
            ContactData contact = new ContactData("Иван");
            contact.Firstname = "Иван";
            contact.Middlename = "Рыжиков";

            app.Contacts.Create(contact);
        }
    }
}
