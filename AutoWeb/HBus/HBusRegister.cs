using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoWeb.HBus
{
    public class HBusRegister
    {
        public void Register() {

            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"GeckoDriver22", "geckodriver.exe");
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            IWebDriver driver = new FirefoxDriver(service);
            driver.Navigate().GoToUrl("https://www.hbus.com/register");
        }
       
    }
}
