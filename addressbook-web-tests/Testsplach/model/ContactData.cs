﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string AllEmails { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string allPhones;
        public string Address { get; set; }
        public string ViewForm { get; set; }
        public string Nickname { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }

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
                    return CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ - ()]", "") + "\r\n";
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

                    if (Nickname != null && Nickname != "") allInfo += " " + Nickname;

                    if (Title != null && Title != "") allInfo += " " + Title;

                    if (Company != null && Company != "") allInfo += " " + Company;

                    if (Address != null && Address != "") allInfo += "\r\n" + Address;

                    if (AllPhones != null && AllPhones != "") allInfo += "\r\n\r\n" + "H: " + AllPhones;

                    if (AllEmails != null && AllEmails != "") allInfo += "\r\n" + "M: " + AllEmails;

                    return allInfo;
                }
                return allInfo;
            }
            set
            {
                allInfo = value;
            }
        }

        public ContactData(string firstName, string lastname)
        {
            Firstname = firstName;
            Lastname = lastname;
        }
    }

}