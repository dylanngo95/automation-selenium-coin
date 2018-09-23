using AutoCoin.Bitvise;
using AutoWeb.HBus;
using GoogleApi.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoManager
{
    public class Program
    {
        private static SheetApi sheetApi = new SheetApi();
        private static AutoBitvise autoBitvise = new AutoBitvise();
        private static HBusRegister hBus = new HBusRegister();

        public static void Main(string[] args)
        {
            FakeIP();
        }

        public static void FakeIP() {
            var accoutSSHs = sheetApi.GetAccountSSH();
            var accountGmails = sheetApi.GetAccountGmail();

            int position = 0;
            foreach (var accoutSSH in accoutSSHs) {
                Console.WriteLine("Connect to Host: {0} ", accoutSSH.Host);
                var isLogin = autoBitvise.LoginSSH(accoutSSH.Host, accoutSSH.UserName, accoutSSH.Password);
                if (isLogin)
                {
                    Console.WriteLine("Login success");
                    hBus.Register(accountGmails[position].Email, accountGmails[position].Password, accountGmails[position].RecoveryEMail);
                    position++;
                }
                else {
                    Console.WriteLine("Login fail");
                }
            }
        }
        
    }
}
