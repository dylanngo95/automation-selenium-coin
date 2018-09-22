using OpenQA.Selenium.Winium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoCoin.Bitvise
{
    public class AutoBitvise
    {
        private DesktopOptions options = new DesktopOptions();
        private WiniumDriver driver = null;

        private String bitvisePath = @"C:\Program Files (x86)\Bitvise SSH Client\BvSsh.exe";

        public AutoBitvise()
        {
            options.ApplicationPath = bitvisePath;
            driver = new WiniumDriver(@"Winium", options);
        }

        public void OpenBitvise()
        {
            options.ApplicationPath = bitvisePath;
            driver = new WiniumDriver(@"Winium", options);
        }


        public bool LoginSSH(String host, String username, String password)
        {

            bool isLogin = true;

            if (driver == null)
            {
                OpenBitvise();
            }

            driver.FindElementById("1004").SendKeys(host);
            driver.FindElementById("1020").SendKeys(username);
            driver.FindElementById("114").SendKeys(password);
            driver.FindElementById("1").Click();

            Thread.Sleep(6000);
            try
            {
                var response = driver.FindElementById("1").GetAttribute("Name");
                if (response.Equals("Login"))
                {
                    isLogin = false;
                }
                else
                if (response.Equals("Abort"))
                {
                    driver.FindElementById("1").Click();
                    isLogin = false;
                }
                else
                if (response.Equals("Logout"))
                {
                    isLogin = true;
                }
                else
                if (response.Equals("OK"))
                {
                    driver.FindElementById("2").Click();
                    isLogin = false;
                }
                else
                    isLogin = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                isLogin = false;
            }

            if (!isLogin)
            {
                driver.FindElementById("1141").Click();
                driver = null;
            }

            return isLogin;

        }

    }
}
