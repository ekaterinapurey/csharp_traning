using Google.Protobuf.WellKnownTypes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests;

namespace AddressBookTests
{
    public class ContactTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareUsersUI_DB()
        {
            if (Perform_Long_Check)
            {
                List<ContactData> fromUI = app.Contacts.GetContactList();
                List<ContactData> fromDB = ContactData.GetAll();
                fromUI.Sort();
                fromDB.Sort();
                Assert.AreEqual(fromUI, fromDB);
            }
        }
    }
}