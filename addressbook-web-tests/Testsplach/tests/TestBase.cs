namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager app;
        public static bool Perform_Long_Check = false;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static Random random = new Random();
        public static string GenerateRandomString(int max)
        {
            const string src = "abcdefghijklmnopqrstuvwxyz0123456789";
            string randomString = "";
         
            for (var i = 0; i < max; i++)
            {
                string result = src[random.Next(0, src.Length)].ToString();
                randomString += (String.Concat(result.Where(c => !Char.IsWhiteSpace(c))));
            }
            return randomString;
        }

    }
}