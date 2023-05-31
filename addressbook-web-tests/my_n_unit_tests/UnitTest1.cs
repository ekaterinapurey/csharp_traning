using NUnit.Framework;  //всегда делать
using OpenQA.Selenium; //селениум
using OpenQA.Selenium.Chrome; //для браузера
using System; // сам121
using System.Collections.Generic; //
using System.Linq; //
using System.Text;
using System.Threading.Tasks;


namespace my_n_unit_tests;

public class Tests
{

    IWebDriver mDriver;

    [SetUp]
    public void Setup()
    {
    }   

    [Test]
    public void cssDemo()
    {
        mDriver = new ChromeDriver("D:\\3rdparty\\chrome");
        mDriver.Url = "http://localhost/addressbook/index.php";
        mDriver.Manage().Window.Maximize();

        var loginInput = mDriver.FindElement(By.XPath(".//*[@name='user']"));
        loginInput.SendKeys("admin");
        var passwordInput = mDriver.FindElement(By.XPath(".//*[@name='pass']"));
        passwordInput.SendKeys("secret");
        Thread.Sleep(5000);
        var loginBtn = mDriver.FindElement(By.XPath(".//*[@value='Login']"));
        loginBtn.Click();
        Thread.Sleep(10000);

        mDriver.Close();
    }
}
