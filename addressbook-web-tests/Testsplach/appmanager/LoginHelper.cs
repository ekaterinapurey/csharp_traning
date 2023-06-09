﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;



namespace WebAddressbookTests
{
	public class LoginHelper : HelperBase
	{

        public LoginHelper(ApplicationManager manager)
            : base(manager)
        {
     
        }

            public void Login(AccountData account)
            {
                driver.FindElement(By.Name("user")).Clear();
                driver.FindElement(By.Name("user")).SendKeys(account.Username);
                driver.FindElement(By.Name("pass")).Clear();
                driver.FindElement(By.Name("pass")).SendKeys(account.Password);
                driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
	}
}

