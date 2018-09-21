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
        private WiniumDriver driver;

        public AutoBitvise() {
            options.ApplicationPath = @"C:\Program Files (x86)\Bitvise SSH Client\BvSsh.exe";
            driver = new WiniumDriver(@"C:\Users\tinh.ngo\coin\Winium.Desktop.Driver", options);
        }


        public bool LoginSSH(String host, String username, String password) {
            driver.FindElementById("1004").SendKeys(host);
            driver.FindElementById("1020").SendKeys(username);
            driver.FindElementById("114").SendKeys(password);
            driver.FindElementById("1").Click();

            Thread.Sleep(6000);
            var response = driver.FindElementById("1").GetAttribute("Name");
            if (response.Equals("Abort") || response.Equals("Login"))
                return false;
            return true;

        }
    }
}
