﻿using System;
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

        [Test]
        public void ContactCreationTest()
        {

            ContactData contact = new ContactData("");
            contact.Firstname = "Иван";
            contact.Middlename = "Рыжиков";

            List<ContactData> oldContacts = app.Contacts.GetContactList();


            app.Contacts.Create(contact);


            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);



        }
    }
}
