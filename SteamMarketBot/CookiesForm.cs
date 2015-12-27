using SteamMarketBot.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamMarketBot
{
    public partial class CookiesForm : Form
    {
        public CookieContainer ck;
        public string sessionId;
        
        public CookiesForm()
        {
            InitializeComponent();
            sessionId = "";
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            string sessionId = SessionIdTextBox.Text;
            string steamLogin = SteamLoginTextBox.Text;
            string steamLoginSecure = SteamLoginSecureTextBox.Text;
            string steamMachineAuth = SteamMachineAuthTextBox.Text;
            string webTradeEligibility = WebTradeEligibilityTextBox.Text;

            ck = new CookieContainer();            
            ck.Add(new Uri(Requests.mainSite), new Cookie("sessionid", sessionId));
            ck.Add(new Uri(Requests.mainSite), new Cookie("steamLogin", steamLogin));
            ck.Add(new Uri(Requests.mainSite), new Cookie("steamLoginSecure", steamLoginSecure));
            ck.Add(new Uri(Requests.mainSite), new Cookie("webTradeEligibility", webTradeEligibility));

            string steamMachineAuthCookieName = "steamMachineAuth";
            steamMachineAuthCookieName += steamLogin.Substring(0, 17);
            ck.Add(new Uri(Requests.mainSite), new Cookie(steamMachineAuthCookieName, steamMachineAuth));

            this.sessionId = sessionId;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CookiesForm_Load(object sender, EventArgs e)
        {
            /* Just so you don't have to copy and paste your cookies every time */
            SessionIdTextBox.Text = "YOUR_SESSIONID_COOKIE";
            SteamLoginTextBox.Text = "YOUR_LOGIN_COOKIE";
            SteamLoginSecureTextBox.Text = "YOUR_LOGIN_SECURE_COOKIE";
            SteamMachineAuthTextBox.Text = "YOUR_MACHINEAUTH_COOKIE";
            WebTradeEligibilityTextBox.Text = "YOUR_WEBTRADE_COOKIE";
        }
    }
}
