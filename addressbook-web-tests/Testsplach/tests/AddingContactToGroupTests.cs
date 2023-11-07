namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroupTest()
        {
            List<GroupData> groups = GroupData.GetAll();
            List<ContactData> contacts = ContactData.GetAll();
            if (groups.Count == 0)
            {
                app.Groups.Create(new GroupData("Артик и Асти"));
                groups = GroupData.GetAll();
            }
            if (contacts.Count == 0)
            {
                app.Contacts.Create(new ContactData("Анечка", "Асти"));
                contacts = ContactData.GetAll();
            }
            int count = 0;
            foreach (GroupData g in groups)
            {
                List<ContactData> contactsInGroup = g.GetContacts();
                contacts.Sort();
                contactsInGroup.Sort();
                if (contacts.Count() != contactsInGroup.Count())
                {
                    ContactData contact = contacts.Except(contactsInGroup).First();
                    List<ContactData> oldList = g.GetContacts();
                    app.Contacts.AddContactToGroup(contact, g);
                    List<ContactData> newList = g.GetContacts();
                    oldList.Add(contact);
                    oldList.Sort();
                    newList.Sort();
                    Assert.AreEqual(oldList, newList);
                    break;
                }
                count++;
                if (count == groups.Count())
                {
                    app.Contacts.Create(new ContactData("Анечка", "Асти"));
                    contacts = ContactData.GetAll();
                    ContactData contact = contacts.Except(contactsInGroup).First();
                    List<ContactData> oldList = g.GetContacts();
                    app.Contacts.AddContactToGroup(contact, g);
                    List<ContactData> newList = g.GetContacts();
                    oldList.Add(contact);
                    oldList.Sort();
                    newList.Sort();
                    Assert.AreEqual(oldList, newList);
                }
            }
        }
    }
}