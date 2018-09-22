using AutoCoin.GoogleApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSSH
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //AutoBitvise autoBitvise = new AutoBitvise();
            //autoBitvise.BindingWithName();

            SheetApi sheetApi = new SheetApi();
            sheetApi.GetAccountSSH();

            //HBusRegister hBusRegister = new HBusRegister();
            //hBusRegister.Register(args);

        }
    }
}
