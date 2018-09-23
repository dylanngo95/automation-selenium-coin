using Google.Apis.Auth.OAuth2;
using Google.Apis.Http;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using GoogleApi.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoogleApi.Sheets
{
    public class SheetApi
    {
        private string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        private readonly string ApplicationName = "AutoCoin";
        private UserCredential credential;

        // Get data account ssh
        private readonly String idAcountSSH = "16uiq6z_6zlexlllB095iGJ00e6nt5N1LDlfy9ong8WM";
        private readonly String rangeAcountSSH = "A:D";
        // Get data account gmail
        private readonly String idAcountGmail = "1EQ5A080EGjGaGDqNeTkM1nb7GDlb7_BCXBKyce2Ff-A";
        private readonly String rangeAcountGmail = "A:C";


        public List<AccountSSH> GetAccountSSH()
        {
            GetCredential();

            // Create Google Sheets API service.
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });


            // Define request parameters.
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(idAcountSSH, rangeAcountSSH);


            // Prints the names and majors of students in a sample spreadsheet:
            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;

            if (values != null && values.Count > 0)
            {
                List<AccountSSH> accountSSHs = new List<AccountSSH>();
                foreach (var row in values)
                {
                    //Console.WriteLine("SSH Account: {0}, {1}, {2}, {3}", row[0], row[1], row[2], row[3]);

                    //String host = row[0].ToString().Trim();
                    //String username = row[1].ToString().Trim();
                    //String password = row[2].ToString().Trim();

                    accountSSHs.Add(new AccountSSH {
                        Host= row[0].ToString().Trim(),
                        UserName = row[1].ToString().Trim(),
                        Password = row[2].ToString().Trim()
                    });
                }
                return accountSSHs;
            }
            else
            {
                Console.WriteLine("No data found.");
                return null;
            }
        }

        public List<AccountGmail> GetAccountGmail() {

            GetCredential();

            // Create Google Sheets API service.
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });


            // Define request parameters.
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(idAcountGmail, rangeAcountGmail);


            // Prints the names and majors of students in a sample spreadsheet:
            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;
            if (values != null && values.Count > 0)
            {
                List<AccountGmail> accountGmails = new List<AccountGmail>();
                foreach (var row in values)
                {
                    // Print columns A and E, which correspond to indices 0 and 4.
                    // Console.WriteLine("Gmail: {0}, {1}, {2}", row[0], row[1], row[2]);

                    String email = row[0].ToString().Trim();
                    String password = row[1].ToString().Trim();
                    String recoveryEmail = row[2].ToString().Trim();

                    accountGmails.Add(new AccountGmail {
                        Email = row[0].ToString().Trim(),
                        Password = row[1].ToString().Trim(),
                        RecoveryEMail = row[2].ToString().Trim()
                    });

                }

                return accountGmails;
            }
            else
            {
                Console.WriteLine("No data found.");
                return null;
            }
        }

        private void GetCredential()
        {
            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;

                //Console.WriteLine("Credential file saved to: " + credPath);
            }
        }

    }
}
