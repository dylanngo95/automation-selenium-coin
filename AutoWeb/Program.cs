using AutoWeb.HBus;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Auto Web");

            HBusRegister hBusRegister = new HBusRegister();
            hBusRegister.Register();

        }

        public void Test() {

            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\Users\TinhNgo\coin\gecko\geckodriver-v0.22.0-win64\", "geckodriver.exe");
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            IWebDriver driver = new FirefoxDriver(service);
            driver.Navigate().GoToUrl("https://www.hbus.com/register");

        }
    }
}
