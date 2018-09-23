using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoWeb.HBus
{
    public class HBusRegister
    {
        private int timeAwaitRegister = 10000;
        private int timeAwaitGmail = 5000;
        private int timeSleep = 5000;

        public HBusRegister() {
            
        }

        public bool Register(String email, String password, String recoveryEmail) {

            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"GeckoDriver22", "geckodriver.exe");
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            IWebDriver driver = new FirefoxDriver(service);

            driver.Navigate().GoToUrl("https://www.hbus.com/register");
            // driver.Manage().Window.Maximize();

            if (driver.Title.Equals("Sign Up | HBUS")) {
                var inputs = driver.FindElements(By.ClassName("item"));
                inputs[0].SendKeys(email);
                var showCapcha = driver.FindElement(By.ClassName("el-button--text"));
                showCapcha.Click();

                timeAwaitRegister += 1000;
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(timeAwaitRegister);
                //Thread.Sleep(timeSleep);

                var swipe = showCapcha.FindElement(By.XPath("//*[@id=\"nc_1_n1t\"]"));
                if (!swipe.Displayed) {
                    driver.FindElement(By.ClassName("switch-btn")).Click();
                }

                timeAwaitRegister += 1000;
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(timeAwaitRegister);
                //Thread.Sleep(timeSleep);

                Actions actions = new Actions(driver);
                var span = driver.FindElement(By.XPath("//*[@id=\"nc_1_n1z\"]"));
                IAction action = (IAction)actions.DragAndDropToOffset(span, swipe.Size.Width, 0);
                action.Perform();

                timeAwaitRegister += 1000;
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(timeAwaitRegister);
                //Thread.Sleep(timeSleep);

                driver.FindElement(By.XPath("//button[contains(text(),'Confirm')]")).Click();

            }

            return true;
        }


        public void GetInfoGmail(String userName, String password, String recoveryEmail)
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"GeckoDriver22", "geckodriver.exe");
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            IWebDriver driver = new FirefoxDriver(service);

            driver.Navigate().GoToUrl("https://accounts.google.com/signin/v2/identifier?service=mail&continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&ltmpl=default&flowName=GlifWebSignIn&flowEntry=ServiceLogin");

            driver.FindElement(By.XPath("//input[@id='identifierId']")).SendKeys(userName);
            driver.FindElement(By.XPath("//div[@id='identifierNext']")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeAwaitGmail);
            timeAwaitGmail += 1000;
            Thread.Sleep(timeSleep);

            driver.FindElement(By.XPath("//input[@name='password']")).SendKeys(password);
            driver.FindElement(By.XPath("//div[@id='passwordNext']")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeAwaitGmail);
            Thread.Sleep(timeSleep);


        }

        public void javaScriptExcutor() {
            //IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            //if (jse.GetType() == typeof(IWebDriver))
            //{
            //    jse.ExecuteScript("document.getElementById('nc_1__bg').style.width = 436;");
            //    jse.ExecuteScript("document.getElementById('nc_1_n1z').style.left = 436;");
            //}
        }

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);


    }
}
