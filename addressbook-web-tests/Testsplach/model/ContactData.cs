using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAaddressbookTests
{
    public class ContactData
    {
        public string firstname;
        public string middlename = "";

        public ContactData(string firstname)
        {
            this.firstname = firstname;
        }
        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        public string Middlename
        {
            get { return middlename; }
            set { middlename = value; }
        }


    }

}