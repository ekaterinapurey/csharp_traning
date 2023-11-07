namespace WebAddressbookTests
{
    public class RemoveContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemovingContactFromGroupTest()
        {
            List<GroupData> groups = GroupData.GetAll();
            GroupData group = new GroupData();
            ContactData toBeRemoved = new ContactData();
            List<ContactData> oldList = new List<ContactData>();
            int count = 0;
            foreach (GroupData g in groups)
            {
                List<ContactData> contactsInGroup = g.GetContacts();
                if (contactsInGroup.Count > 0)
                {
                    toBeRemoved = contactsInGroup[0];
                    group = g;
                    oldList = group.GetContacts();
                    break;
                }
                count++;
                if (count == groups.Count)
                {
                    ContactData contactForAdd = ContactData.GetAll()[0];
                    GroupData groupForAdd = GroupData.GetAll()[0];
                    app.Contacts.AddContactToGroup(contactForAdd, groupForAdd);
                    toBeRemoved = contactForAdd;
                    group = groupForAdd;
                    oldList = group.GetContacts();
                }
            }

            app.Contacts.RemoveContactFromGroup(toBeRemoved, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(toBeRemoved);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}