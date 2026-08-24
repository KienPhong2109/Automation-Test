using System;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        IWebDriver driver;
        WebDriverWait wait;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnRunTest_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Launch browser
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();

                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                // 2. Navigate to url
                driver.Navigate().GoToUrl("http://automationexercise.com");

                // đợi trang load
                wait.Until(d => d.FindElement(By.TagName("body")));

                // 3. Verify home page is visible successfully
                wait.Until(d => d.Title.Contains("Automation Exercise"));

                // ===== TỰ ĐỘNG ĐÓNG QUẢNG CÁO =====
                try
                {
                    var frames = driver.FindElements(By.TagName("iframe"));

                    foreach (var frame in frames)
                    {
                        driver.SwitchTo().Frame(frame);

                        var closeBtn = driver.FindElements(By.XPath("//div[@id='dismiss-button']"));

                        if (closeBtn.Count > 0)
                        {
                            closeBtn[0].Click();
                            break;
                        }

                        driver.SwitchTo().DefaultContent();
                    }
                }
                catch { }

                driver.SwitchTo().DefaultContent();

                // 4. Click Signup / Login
                wait.Until(d => d.FindElement(By.XPath("//a[@href='/login']"))).Click();

                // 5. Verify 'Login to your account' is visible
                wait.Until(d => d.FindElement(By.XPath("//h2[contains(text(),'Login to your account')]")).Displayed);

                // 6. Enter email address and password
                driver.FindElement(By.Name("email")).SendKeys("chungphong@gmail.com");
                driver.FindElement(By.Name("password")).SendKeys("123456");

                // 7. Click login button
                driver.FindElement(By.XPath("//button[contains(text(),'Login')]")).Click();

                // 8. Verify 'Logged in as username'
                wait.Until(d => d.FindElement(By.XPath("//*[contains(text(),'Logged in as')]")));

                // 9. Click Logout
                driver.FindElement(By.XPath("//a[contains(text(),'Logout')]")).Click();

                // 10. Verify login page
                wait.Until(d => d.FindElement(By.XPath("//h2[contains(text(),'Login to your account')]")).Displayed);

                MessageBox.Show("Test Passed");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Launch browser
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();

                // wait tối đa 10 giây
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                // 2. Navigate to url
                driver.Navigate().GoToUrl("http://automationexercise.com");

                // 3. Verify that home page is visible successfully
                wait.Until(d => d.Title.Contains("Automation Exercise"));

                // ---- đóng quảng cáo nếu có ----
                try
                {
                    driver.FindElement(By.XPath("//button[contains(text(),'Close')]")).Click();
                }
                catch { }

                // 4. Click 'Signup / Login'
                wait.Until(d => d.FindElement(By.LinkText("Signup / Login"))).Click();

                // 5. Verify 'New User Signup!' is visible
                wait.Until(d => d.FindElement(By.XPath("//h2[contains(text(),'New User Signup')]")).Displayed);

                // 6. Enter name and already registered email address
                driver.FindElement(By.Name("name")).SendKeys("Test User");

                driver.FindElement(By.XPath("//input[@data-qa='signup-email']"))
                      .SendKeys("chungphong@gmail.com"); // email đã tồn tại

                // 7. Click 'Signup' button
                driver.FindElement(By.XPath("//button[contains(text(),'Signup')]")).Click();

                // 8. Verify error 'Email Address already exist!' is visible
                wait.Until(d => d.FindElement(By.XPath("//*[contains(text(),'already exist')]")).Displayed);

                MessageBox.Show("Test Passed - Email already exists error displayed");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Launch browser
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();

                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                // 2. Navigate to url
                driver.Navigate().GoToUrl("http://automationexercise.com");

                // đợi trang load
                wait.Until(d => d.FindElement(By.TagName("body")));

                // 3. Verify home page visible
                wait.Until(d => d.Title.Contains("Automation Exercise"));

                // ===== TỰ ĐỘNG ĐÓNG QUẢNG CÁO =====
                try
                {
                    var frames = driver.FindElements(By.TagName("iframe"));

                    foreach (var frame in frames)
                    {
                        driver.SwitchTo().Frame(frame);

                        var closeBtn = driver.FindElements(By.XPath("//div[@id='dismiss-button']"));

                        if (closeBtn.Count > 0)
                        {
                            closeBtn[0].Click();
                            break;
                        }

                        driver.SwitchTo().DefaultContent();
                    }
                }
                catch { }

                driver.SwitchTo().DefaultContent();

                // 4. Click 'Contact Us'
                wait.Until(d => d.FindElement(By.XPath("//a[contains(text(),'Contact us')]"))).Click();

                // 5. Verify 'GET IN TOUCH'
                wait.Until(d => d.FindElement(By.XPath("//h2[contains(text(),'Get In Touch')]")).Displayed);

                // 6. Enter name, email, subject, message
                driver.FindElement(By.Name("name")).SendKeys("Test User");
                driver.FindElement(By.Name("email")).SendKeys("testuser123@gmail.com");
                driver.FindElement(By.Name("subject")).SendKeys("Automation Test");
                driver.FindElement(By.Name("message")).SendKeys("This is a Selenium automation test.");

                // 7. Upload file
                driver.FindElement(By.Name("upload_file"))
                      .SendKeys(@"C:\test"); // sửa đường dẫn file nếu cần

                // 8. Click Submit
                driver.FindElement(By.XPath("//input[@value='Submit']")).Click();

                // 9. Click OK alert
                driver.SwitchTo().Alert().Accept();

                // 10. Verify success message
                wait.Until(d => d.FindElement(By.XPath("//*[contains(text(),'Success! Your details have been submitted successfully.')]")).Displayed);

                // 11. Click Home
                driver.FindElement(By.XPath("//a[contains(text(),'Home')]")).Click();

                // Verify về trang home
                wait.Until(d => d.Title.Contains("Automation Exercise"));

                MessageBox.Show("Contact Us Test Passed");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}