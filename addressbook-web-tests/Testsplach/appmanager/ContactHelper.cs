using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        private List<ContactData> contactCache = null;

        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            InitNewContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper Remove(ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            SelectContactById(contact.Id);
            RemoveContact();
            SubmitContactRemove();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
   
        public ContactHelper FillContactForm(ContactData contact)
        {
            
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("middlename")).Click();
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename"))?.SendKeys(contact.Middlename);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname"))?.SendKeys(contact.Lastname);
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            contactCache = null;

            return this;

        }

        public ContactHelper Modify(ContactData contact, int index)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(contact.Id);
            ClickOnEditElementEditing(index);
            FillContactForm(contact);
            SubmitContactModification();
            manager.Navigator.GoToHomePage();

            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
               .FindElements(By.TagName("td"))[7]
               .FindElement(By.TagName("a")).Click();

            return this;
        }

        public ContactHelper ClickOnEditElementEditing(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (index + 2) +"]/td[8]/a/img")).Click();
            return this;
        }

        public ContactHelper GoToContactView(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
               .FindElements(By.TagName("td"))[6]
               .FindElement(By.TagName("a")).Click();

            return this;
        }
        public ContactHelper SelectContact(int index)
        {

            driver.FindElement(By.XPath("//tr[" + (index + 2) + "]//input")).Click();

            return this;
        }

        public ContactHelper SelectContactById(string Id)
        {

            driver.FindElement(By.XPath("//tr//input[@name= 'selected[]' and @value='" + Id + "']")).Click();

            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SubmitContactRemove()
        {

            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;
        }
        public ContactHelper SubmitContactModification()
        {


            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            manager.Navigator.GoToHomePage();


            return this;
        }

        public bool ContactExists()
        {
            return ContactData.GetAll().Count() > 0;
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,

            };


            throw new NotImplementedException();
        }


        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Company = company,
                Middlename = middleName,
                Title = title,
                Nickname = nickName,

            };


        }

        public ContactData GetContactInformationFromViewForm(int index)
        {
            manager.Navigator.GoToHomePage();
            GoToContactView(index);

            string info = driver.FindElement(By.XPath("/html//div[@id='content']")).Text;

            return new ContactData()
            {
                AllInfo = info
            };

        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)

            {
                contactCache = new List<ContactData>();

                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']"));
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    string lastName = cells[1].Text;
                    string firstName = cells[2].Text;
                    string address = cells[3].Text;
                    string emails = cells[3].Text;
                    string phones = cells[3].Text;
                    contactCache.Add(
                        new ContactData(firstName)
                        {
                            Id = element.FindElement(By.TagName("td")).FindElement(By.TagName("input")).GetAttribute("value"),
                            Lastname = lastName,
                            Address = address,
                            AllEmails = emails,
                            AllPhones = phones
                        }
                        );
                }
                            
            }

            return new List<ContactData>(contactCache);

        }
        public int GetContactCount()
        {
            return driver.FindElements(By.CssSelector("tr[name='entry']")).Count;
        }

        internal void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        private void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        private void SelectContact(string userId)
        {
            driver.FindElement(By.Id(userId)).Click();
        }

        private void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        private void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public void FilterGroupsByName(String groupName)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(groupName);
        }

        public void RemoveContactFromgroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        public void RemoveContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            FilterGroupsByName(group.Name);
            SelectContactById(contact.Id);
            RemoveContactFromgroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
            manager.Navigator.GoToHomePage();

        }
    }
}