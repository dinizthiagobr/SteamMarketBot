using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SteamMarketBot.Classes
{
    class Utils
    {
        private Requests req;
        public string name;
        public string _balance;
        public float balance;
        public string sessionId;

        public Utils(Requests _req, string _sessionId)
        {
            req = _req;
            sessionId = _sessionId;
            name = "";
            balance = 0.0f;
        }

        public void writeToFile(string filename, string text)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Thiago\Documents\Projetos Visual Studio\2015\SteamMarketBot\" + filename, false))
            {
                file.WriteLine(text);
            }
        }

        public void appendToFile(string filename, string newLine)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Thiago\Documents\Projetos Visual Studio\2015\SteamMarketBot\" + filename, true))
            {
                file.WriteLine(newLine);
            }
        }

        public static void appendToFileqq(string filename, string newLine)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Thiago\Documents\Projetos Visual Studio\2015\SteamMarketBot\" + filename, true))
            {
                file.WriteLine(newLine);
            }
        }

        public List<string> readLines(string filename)
        {
            List<string> items = new List<string>();
            using (System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\Thiago\Documents\Projetos Visual Studio\2015\SteamMarketBot\" + filename))
            {
                while (!file.EndOfStream)
                    items.Add(file.ReadLine());
            }

            return items;
        }

        public bool LogIn()
        {
            string r = req.SendGet(Requests.market);

            name = Regex.Match(r, "(?<=buynow_dialog_myaccountname\">)(.*)(?=</span>)").ToString().Trim();
            
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }

            _balance = Regex.Match(r, "(?<=marketWalletBalanceAmount\">)(.*)(?=</span>)").ToString();            
            balance = float.Parse(_balance.Substring(3));

            return true;
        }

        public string getNewlyListed()
        {
            string url = Requests.recentListing;
            url += String.Format(Requests.newlyListedQuery, "BR", "english", 7);

            string r = req.SendGet(url);

            return r;
        }

        public string getListingPage(string url)
        {
            string r = req.SendGet(url);

            return r;
        }

        public string buyItem(string url, string data, string referer)
        {
            string r = req.SendPost(url, data, referer);

            return r;
        }

    }
}
