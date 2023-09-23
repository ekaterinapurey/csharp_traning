using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            double total = 1500;
            bool VipClient = false;

            if (total > 1000 || VipClient)
            {
                total = total * 0.9;
                System.Console.Out.Write("Скидка 10%, общая сумма " + total);

            }
            else
            {
                System.Console.Out.Write("Скидки нет, общая сумма " + total);

            }
        }
    }
    }

