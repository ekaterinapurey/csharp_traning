using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using AddressBookTests;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationsTests : ContactTestBase
    {

        public static IEnumerable<ContactData> RandomContactProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Middlename = GenerateRandomString(100),
                    Address = GenerateRandomString(100),
                    HomePhone = GenerateRandomString(30),
                    WorkPhone = GenerateRandomString(30),
                    MobilePhone = GenerateRandomString(30),
                    Email = GenerateRandomString(30)
                }
                );
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {

            return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(@"contacts.xml"));

        }
        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                 File.ReadAllText(@"contacts.json"));
        }

        public static IEnumerable<ContactData> ContactDataFromExcelFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"groups.xlsx"));
            Excel.Worksheet sheet = (Excel.Worksheet)wb.ActiveSheet;
            Excel.Range range = sheet.UsedRange;
            //for (int i = 1; i <= range.Rows.Count; i++)
            //{
            //    contacts.Add(new ContactData()
            //    {
            //        Firstname = range.Cells[i, 1].Value,

            //        Lastname = range.Cells[i, 2].Value,

            //        Middlename = range.Cells[i, 3].Value
            //    });
            //}
            wb.Close();
            app.Visible = false;
            app.Quit();
            return contacts;
        }

        //[Test, TestCaseSource("ContactDataFromExcelFile")]
        public void ContactCreationTest(ContactData contact)
        {

            List<ContactData> oldContacts = ContactData.GetAll();


            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());


            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);



        }

       
    }
}
