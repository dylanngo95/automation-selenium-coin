using AutoCoin.Bitvise;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoCoin.GoogleSheet
{
    public class SheetApi
    {
        private string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        private readonly string ApplicationName = "AutoCoin";
        private readonly String spreadsheetId = "16uiq6z_6zlexlllB095iGJ00e6nt5N1LDlfy9ong8WM";
        private readonly String range = "A:D";
        private UserCredential credential;

        private AutoBitvise autoBitvise = new AutoBitvise();

        public void GetAccountSSH() {

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


            // Create Google Sheets API service.
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });


            // Define request parameters.
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(spreadsheetId, range);


            // Prints the names and majors of students in a sample spreadsheet:
            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    // Print columns A and E, which correspond to indices 0 and 4.
                    Console.WriteLine("{0}, {1}, {2}, {3}", row[0], row[1], row[2], row[3]);

                    String host = row[0].ToString().Trim();
                    String username = row[1].ToString().Trim();
                    String password = row[2].ToString().Trim();

                    var isLogin = autoBitvise.LoginSSH(host, username, password);
                    if (isLogin) {
                        return;
                    }

                    Console.WriteLine("Login success");
                    
                }
            }
            else
            {
                Console.WriteLine("No data found.");
            }
            Console.Read();


        }

    }
}
