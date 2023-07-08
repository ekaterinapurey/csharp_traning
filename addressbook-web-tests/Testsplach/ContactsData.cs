using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebAddressbookTests
{
    public class ContactsData
    {
        private string firstname;
        private string middlename;


        public ContactsData(string firstname, string middlename)
        {
            this.firstname = firstname;
            this.middlename = middlename;
        }
        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }
        public string Middlename
        {
            get
            {
                return middlename;
            }
            set
            {
                middlename = value;
            }
        }
    }
}
