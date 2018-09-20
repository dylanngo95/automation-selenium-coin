using OpenQA.Selenium.Winium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCoin.Bitvise
{
    public class AutoBitvise
    {
        DesktopOptions options = new DesktopOptions();
        WiniumDriver driver;

        public AutoBitvise() {
            options.ApplicationPath = @"C:\Program Files (x86)\Bitvise SSH Client\BvSsh.exe";
            driver = new WiniumDriver(@"C:\Users\TinhNgo\coin\Winium.Desktop.Driver", options);
        }

        public void GetData() {

        }

        public void BindingWithName() {
            driver.FindElementByName("Host").SendKeys("127.0.0.1:8099");
        }
    }
}
