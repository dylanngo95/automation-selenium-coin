using AutoCoin.GoogleApi;
using AutoWeb.HBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoManager
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //HBusRegister hBusRegister = new HBusRegister();
            //hBusRegister.Register();

            SheetApi sheetApi = new SheetApi();
            sheetApi.GetAccountSSH();

        }
    }
}
