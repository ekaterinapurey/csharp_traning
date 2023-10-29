using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using LinqToDB.Mapping;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using WebAddressbookTests;

namespace AddressBookTests
{
    [Table(Name = "address_in_groups")]
    public class GroupContactRelation : HelperBase
    {
        public GroupContactRelation(ApplicationManager manager) : base(manager)
        {
        }

        [Column(Name = "group_id")]
        public string GroupId { get; set; }

        [Column(Name = "id")]
        public string ContactId { get; set; }
    }
}