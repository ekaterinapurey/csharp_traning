using System.Text;
using mantis_tests.appmanager;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace mantis_tests

{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        private StringBuilder verificationErrors;
        protected string baseURL;
        private bool acceptNextAlert = true;
        protected LoginHelper loginHelper;
        protected ProjectHelper projectHelper;
        protected NavigationHelper navigationHelper;

        public AdminHelper Admin { get; set; }
        public APIHelper API { get; set; }

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost/mantisbt-1.3.20";
            verificationErrors = new StringBuilder();
            Registration = new RegistrationHelper(this);
            loginHelper = new LoginHelper(this);
            projectHelper = new ProjectHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);
            Admin = new AdminHelper(this, baseURL);
            API = new APIHelper(this);

        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }

        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = newInstance.baseURL + "/login_page.php";
                app.Value = newInstance;

            }
            return app.Value;
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
        public RegistrationHelper Registration
        {
            get; set;
        }
        public FtpHelper Ftp
        {
            get; set;
        }
        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }
        public ProjectHelper Project
        {
            get
            {
                return projectHelper;
            }
        }
        public NavigationHelper Navigator
        {
            get
            {
                return navigationHelper;
            }
        }
    }
}