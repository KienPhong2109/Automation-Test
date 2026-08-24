using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ckptest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Khởi tạo Chrome Driver
            IWebDriver driver = new ChromeDriver();

            // Maximize cửa sổ trình duyệt
            driver.Manage().Window.Maximize();

            // Chờ phần tử xuất hiện
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(99999999));

            // =============================
            // Test Case 1: Register User
            // =============================

            // 1. Launch browser
            // (Đã launch khi tạo ChromeDriver)

            // 2. Navigate to url
            driver.Navigate().GoToUrl("http://automationexercise.com");
            Console.WriteLine("pass");

            // 3. Verify that home page is visible successfully
            wait.Until(d => d.Title.Contains("Automation Exercise"));

            // 4. Click on 'Signup / Login' button
            wait.Until(d => d.FindElement(By.PartialLinkText("Signup"))).Click();

            // 5. Verify 'New User Signup!' is visible
            wait.Until(d => d.PageSource.Contains("New User Signup!"));

            // 6. Enter name and email address
            driver.FindElement(By.Name("name")).SendKeys("TestUser");

            // Email random để tránh trùng
            string email = "test" + DateTime.Now.Ticks + "@gmail.com";
            driver.FindElement(By.XPath("//input[@data-qa='signup-email']")).SendKeys(email);

            // 7. Click 'Signup' button
            driver.FindElement(By.XPath("//button[@data-qa='signup-button']")).Click();

            // 8. Verify that 'ENTER ACCOUNT INFORMATION' is visible
            wait.Until(d => d.FindElement(By.Id("password")).Displayed);
            Console.WriteLine("Enter account information page loaded");


            // 9. Fill details: Title, Name, Email, Password, Date of birth

            // Title
            driver.FindElement(By.Id("id_gender1")).Click();

            // Password
            driver.FindElement(By.Id("password")).SendKeys("123456");

            // Date of birth
            new SelectElement(driver.FindElement(By.Id("days"))).SelectByValue("1");
            new SelectElement(driver.FindElement(By.Id("months"))).SelectByValue("1");
            new SelectElement(driver.FindElement(By.Id("years"))).SelectByValue("2000");

            // 10. Select checkbox 'Sign up for our newsletter!'
            driver.FindElement(By.Id("newsletter")).Click();

            // 11. Select checkbox 'Receive special offers from our partners!'
            IWebElement optin = driver.FindElement(By.Id("optin"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", optin);

            // 12. Fill details

            driver.FindElement(By.Id("first_name")).SendKeys("Test");
            driver.FindElement(By.Id("last_name")).SendKeys("User");
            driver.FindElement(By.Id("company")).SendKeys("ABC Company");
            driver.FindElement(By.Id("address1")).SendKeys("123 Street");
            driver.FindElement(By.Id("address2")).SendKeys("District 1");

            new SelectElement(driver.FindElement(By.Id("country"))).SelectByText("India");

            driver.FindElement(By.Id("state")).SendKeys("HCM");
            driver.FindElement(By.Id("city")).SendKeys("Ho Chi Minh");
            driver.FindElement(By.Id("zipcode")).SendKeys("700000");
            driver.FindElement(By.Id("mobile_number")).SendKeys("0123456789");

            // 13. Click 'Create Account button'
            driver.FindElement(By.XPath("//button[@data-qa='create-account']")).Click();

            // 14. Verify that 'ACCOUNT CREATED!' is visible
            wait.Until(d => d.FindElement(By.XPath("//b[text()='Account Created!']")).Displayed);

            // 15. Click 'Continue' button
            driver.FindElement(By.XPath("//a[@data-qa='continue-button']")).Click();

            // Chờ trang home load lại
            wait.Until(d => d.Title.Contains("Automation Exercise"));

            // Chờ menu user xuất hiện
            wait.Until(d => d.PageSource.Contains("Logged in as"));

            Console.WriteLine("Step 16 PASS: Logged in as user visible");

            // 17. Click 'Delete Account' button
            driver.FindElement(By.LinkText("Delete Account")).Click();

            // 18. Verify that 'ACCOUNT DELETED!' is visible
            wait.Until(d => d.FindElement(By.XPath("//h2[@data-qa='account-deleted']")).Displayed);
            Console.WriteLine("Step 18 PASS: Account deleted");
            // Click Continue
            driver.FindElement(By.XPath("//a[@data-qa='continue-button']")).Click();

            MessageBox.Show("Test case completed successfully!");

            // Đóng browser
            driver.Quit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Tài khoản đã tồn tại trên website
            string email = "finn@gmail.com";
            string password = "123456";

            // 1. Launch browser
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // 2. Navigate to url
            driver.Navigate().GoToUrl("http://automationexercise.com");

            // 3. Verify that home page is visible successfully
            wait.Until(d => d.Title.Contains("Automation Exercise"));

            // 4. Click on 'Signup / Login' button
            wait.Until(d => d.FindElement(By.PartialLinkText("Signup"))).Click();

            // 5. Verify 'Login to your account' is visible
            wait.Until(d => d.FindElement(By.XPath("//h2[text()='Login to your account']")).Displayed);

            // 6. Enter correct email address and password
            driver.FindElement(By.XPath("//input[@data-qa='login-email']")).SendKeys(email);
            driver.FindElement(By.XPath("//input[@data-qa='login-password']")).SendKeys(password);

            // 7. Click 'login' button
            driver.FindElement(By.XPath("//button[@data-qa='login-button']")).Click();

            // 8. Verify that 'Logged in as username' is visible
            wait.Until(d => d.FindElement(By.XPath("//a[contains(text(),'Logged in as')]")).Displayed);
            Console.WriteLine("Step 8 PASS: Login success");
            // 9. Click 'Delete Account' button
            driver.FindElement(By.LinkText("Delete Account")).Click();

            // 10. Verify that 'ACCOUNT DELETED!' is visible
            wait.Until(d => d.FindElement(By.XPath("//h2[@data-qa='account-deleted']")).Displayed);
            Console.WriteLine("Step 18 PASS: Account deleted");
            // Click Continue
            driver.FindElement(By.XPath("//a[@data-qa='continue-button']")).Click();

            MessageBox.Show("Test case completed successfully!");

            driver.Quit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Tài khoản đã tồn tại trên website
            string email = "finn@gmail.com";
            string password = "123456";

            // 1. Launch browser
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10999999999));

            // 2. Navigate to url
            driver.Navigate().GoToUrl("http://automationexercise.com");

            // 3. Verify that home page is visible successfully
            wait.Until(d => d.Title.Contains("Automation Exercise"));

            // 4. Click on 'Signup / Login' button
            wait.Until(d => d.FindElement(By.PartialLinkText("Signup"))).Click();

            // 5. Verify 'Login to your account' is visible
            wait.Until(d => d.FindElement(By.XPath("//h2[text()='Login to your account']")).Displayed);

            // 6. Enter correct email address and password
            driver.FindElement(By.XPath("//input[@data-qa='login-email']")).SendKeys(email);
            driver.FindElement(By.XPath("//input[@data-qa='login-password']")).SendKeys(password);

            // 7. Click login button
            driver.FindElement(By.XPath("//button[@data-qa='login-button']")).Click();

            // 8. Verify login success
            wait.Until(d => d.PageSource.Contains("Logged in as"));

            Console.WriteLine("Step 8 PASS: Login success");
            // 9. Click 'Delete Account' button
            driver.FindElement(By.LinkText("Delete Account")).Click();

            // 10. Verify that 'ACCOUNT DELETED!' is visible
            wait.Until(d => d.FindElement(By.XPath("//h2[@data-qa='account-deleted']")).Displayed);
            Console.WriteLine("Step 18 PASS: Account deleted");
            // Click Continue
            driver.FindElement(By.XPath("//a[@data-qa='continue-button']")).Click();

            MessageBox.Show("Test case completed successfully!");

            driver.Quit();
        }
    }
}
