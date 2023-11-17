using System.Text.RegularExpressions;


namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Fax { get; set; }
        public string AllEmails { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string allPhones;
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string ViewForm { get; set; }
        public string Nickname { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string HomePage { get; set; }
        public string Notes { get; set; }

        public ContactData(string firstname)
        {
           Firstname = firstname;
        }


        public ContactData()
        {
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + Lastname + " " + Firstname + Address + HomePhone + MobilePhone
                + Email + Email2 + Email3;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            int result = Firstname.CompareTo(other.Firstname);
            if (result != 0)
            {
                return result;
            }
            else if (!String.IsNullOrEmpty(Lastname) && !String.IsNullOrEmpty(other.Lastname))
            {
                return Lastname.CompareTo(other.Lastname);
            }
            return 0;
        }

        public string Firstname { get; set; }
        public string Middlename { get; set; }

        public string Lastname { get; set; }

        public string Id { get; set; }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set { allPhones = value; }
        }


        public string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }

        public string allInfo = null;
        public string AllInfo
        {
            get
            {
                if (allInfo == null)
                {
                    if (Firstname != null && Firstname != "") allInfo += Firstname;

                    if (Middlename != null && Middlename != "") allInfo += " " + Middlename;

                    if (Lastname != null && Lastname != "") allInfo += " " + Lastname;

                    if (Nickname != null && Nickname != "") allInfo += "\r\n" + Nickname;

                    if (Title != null && Title != "") allInfo += "\r\n" + Title;

                    if (Company != null && Company != "") allInfo += "\r\n" + Company;

                    if (Address != null && Address != "") allInfo += "\r\n" + Address;

                    if (HomePhone != null && HomePhone != "") allInfo += "\r\n\r\n" + "H: " + HomePhone;

                    if (MobilePhone != null && MobilePhone != "") allInfo += "\n\n" + "M: " + MobilePhone;

                    if (WorkPhone != null && WorkPhone != "") allInfo += "\r\n" + "W: " + WorkPhone;

                    if (Fax != null && Fax != "") allInfo += "\r\n" + "F: " + Fax;

                    if (Email != null && Email != "") allInfo += "\n\n" + Email;

                    if (Email2 != null && Email2 != "") allInfo += "\r\n" + Email2;

                    if (Email3 != null && Email3 != "") allInfo += "\r\n" + Email3;

                    if (HomePage != null && HomePage != "") allInfo += "\r\n" + "Homepage:\r\n" + HomePage;

                    if (Address2 != null && Address2 != "") allInfo += "\r\n" + Address2;

                    if (Notes != null && Notes != "") allInfo += "\r\n\r\n" + Notes;

                    return allInfo;
                }
                return allInfo;
            }
            set
            {
                allInfo = value;
            }
        }


        public string shortInfo = null;
        public string ShortInfo
        {
            get
            {
                if (shortInfo == null)
                {
                    if (Firstname != null && Firstname != "") shortInfo += Firstname;

                    if (Lastname != null && Lastname != "") shortInfo += " " + Lastname;

                    if (Address != null && Address != "") shortInfo += Address;

                    if (AllPhones != null && AllPhones != "") shortInfo += AllPhones;

                    if (AllEmails != null && AllEmails != "") shortInfo += AllEmails;

                    return shortInfo;
                }
                return shortInfo;
            }
            set
            {
                shortInfo = value;
            }
        }

        public ContactData(string firstName, string lastname)
        {
            Firstname = firstName;
            Lastname = lastname;
        }
    }

}