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
            
            hBusRegister.Register("test123@gmail.com", "test123", "gjundat95@gmail.com");
            hBusRegister.GetInfoGmail("foiwnahoemono234@gmail.com", "chbk6tl3a25hsg", "vankuanwuomono12@gmail.com");
        }

    }
}
