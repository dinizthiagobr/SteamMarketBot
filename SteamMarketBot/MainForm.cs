using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SteamMarketBot.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamMarketBot
{
    public partial class MainForm : Form
    {
        private Utils utils;
        private List<Item> newlyListedItems;
        private List<Item> listingPageItems;
        private Thread oThread;
        private Thread oThread2;

        public MainForm()
        {
            InitializeComponent();
            newlyListedItems = new List<Item>();
            listingPageItems = new List<Item>();
        }

        private void cookiesButton_Click(object sender, EventArgs e)
        {
            CookiesForm cf = new CookiesForm();
            if (cf.ShowDialog() == DialogResult.OK)
            {
                Requests req = new Requests(cf.ck);
                utils = new Utils(req, cf.sessionId);

                bool code = utils.LogIn();

                if (code)
                {
                    NameLabel.Text = utils.name;
                    NameLabel.Enabled = true;
                    BalanceLabel.Text = utils._balance;
                    BalanceLabel.Enabled = true;

                    cookiesButton.Text = "Logged in";
                    cookiesButton.Enabled = false;

                    RefreshItemsButton.Enabled = true;
                    StartButton.Enabled = true;
                    StopButton.Enabled = true;

                    RefreshItemsButton.PerformClick();
                }
            }

        }

        private void RefreshItemsButton_Click(object sender, EventArgs e)
        {
            List<string> lines = utils.readLines("Items.txt");
            ItemsListBox.Items.Clear();

            newlyListedItems.Clear();
            listingPageItems.Clear();

            foreach (string l in lines)
            {
                string[] data = l.Split(';');
                Item newItem = new Item(data[0], int.Parse(data[1]), data[2]);
                if (newItem.type.Equals("Listing Page"))
                {
                    listingPageItems.Add(newItem);
                }
                else if (newItem.type.Equals("Newly Listed"))
                {
                    newlyListedItems.Add(newItem);
                }

                ItemsListBox.Items.Add(newItem.item.Split('/').Last() + " : " + newItem.desiredPrice + " : " + newItem.type);
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            oThread = new Thread(new ThreadStart(this.CheckNewlyListed));
            oThread.Start();
            while (!oThread.IsAlive) ;

            oThread2 = new Thread(new ThreadStart(this.CheckListingPages));
            oThread2.Start();
            while (!oThread.IsAlive) ;

            RunningLabel.Text = "Running";
            RunningLabel.ForeColor = Color.Green;
        }

        private void CheckListingPages()
        {
            while (true) {
                bool done = false;

                if (LogListView.Items.Count >= 20) {
                    Invoke(new Action(() =>
                    {
                        LogListView.Items.Clear();
                        LogListView.Clear();
                    }));                    
                }

                foreach (Item item in listingPageItems)
                {
                    done = false;
                    string results_html = utils.getListingPage(item.item);

                    if (string.IsNullOrEmpty(results_html))
                    {
                        /* show something */
                        continue;
                    }

                    MatchCollection matches = Regex.Matches(results_html, "(?<=div class=\"market_listing_row market_recent_listing_row listing_)(.*?)(?=<div style=\"clear: both;\"></div>)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                    foreach (Match match in matches)
                    {
                        if (done) continue;
                        string qq = match.ToString();

                        MatchCollection prices = Regex.Matches(match.ToString(), "([0-9]+,[0-9]+)");

                        if (prices.Count == 2 || prices.Count == 3)
                        {
                            int total = (int)(float.Parse(prices[0].ToString()) * 100);
                            if (total <= item.desiredPrice && (utils.balance * 100) >= total)
                            {
                                int subTotal = (int)(float.Parse(prices[2].ToString()) * 100);
                                int fee = total - subTotal;
                                string listingId = String.Concat(match.ToString().TakeWhile(char.IsDigit));

                                string sessionId = utils.sessionId;
                                int currency = 7;
                                string buyQuery = string.Format(Requests.buyQuery, sessionId, currency, subTotal, fee, total);
                                string url = Requests.buyListing + listingId;

                                Invoke(new Action(() =>
                                {
                                    LogListView.Items.Add(total.ToString()).ForeColor = Color.Green;
                                }));

                                utils.appendToFile("Log.txt", item.item + " : " + total + " : " + item.type);

                                string response = utils.buyItem(url, buyQuery, item.item);

                                if (response.Contains("problem") || response.Contains("already") || response.Contains("error"))
                                {
                                    Invoke(new Action(() =>
                                    {
                                        BuyTriesListView.Items.Add("Couldn't buy").ForeColor = Color.Red;
                                    }));
                                }
                                else
                                {
                                    Invoke(new Action(() =>
                                    {
                                        BuyTriesListView.Items.Add("Bought something").ForeColor = Color.Green;
                                    }));
                                }

                                utils.appendToFile("BuyResponse.txt", response);
                                utils.appendToFile("BuyResponse.txt", "\n\n");
                                System.Threading.Thread.Sleep(30000);
                            }
                            else
                            {
                                Invoke(new Action(() =>
                                {
                                    LogListView.Items.Add(total.ToString()).ForeColor = Color.Red;
                                }));

                                //utils.appendToFile("Kek.txt", item.item + " : " + total);
                            }
                            done = true;
                        }                        
                    }
                    System.Threading.Thread.Sleep(6000);
                }
            }
        }

        private void CheckNewlyListed()
        {
            while (true)
            {
                string r = utils.getNewlyListed();
                if (string.IsNullOrEmpty(r))
                {
                    /* show something */
                    continue;
                }
                else if (!r.StartsWith("{"))
                {
                    /* show something */
                    continue;
                }

                JToken jsonR = JObject.Parse(r);

                bool success = (bool)jsonR.SelectToken("success");

                if (success)
                {
                    string results_html = (string)jsonR.SelectToken("results_html");
                    MatchCollection matches = Regex.Matches(results_html, "(?<=div class=\"market_listing_item_name_block\">)(.*?)(?=</div>)", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline);

                    foreach (Match match in matches)
                    {
                        string listingId = Regex.Match(match.ToString(), "(?<=listing_sell_new_)[0-9]+").ToString();
                        string itemUrl = Regex.Match(match.ToString(), "(?<=href=\")(.*)(?=\">)").ToString();

                        Item foundItem = newlyListedItems.FirstOrDefault(i => i.item.Equals(itemUrl));

                        if (foundItem != null)
                        {
                            var listings = JsonConvert.DeserializeObject<dynamic>(r);
                            listings = listings.listinginfo;
                            var itemListing = listings[listingId];

                            if ((int)(itemListing["asset"]["amount"]) == 0)
                                continue;

                            if (itemListing["converted_price"] == null)
                                continue;

                            int subTotal = (int)itemListing["converted_price"];
                            int fee = (int)itemListing["converted_fee"];
                            int total = subTotal + fee;

                            if (total <= foundItem.desiredPrice && (utils.balance * 100) >= total)
                            {
                                string sessionId = utils.sessionId;
                                int currency = 7;
                                string buyQuery = string.Format(Requests.buyQuery, sessionId, currency, subTotal, fee, total);
                                string url = Requests.buyListing + listingId;

                                Invoke(new Action(() =>
                                {
                                    LogListView.Items.Add(total.ToString()).ForeColor = Color.Green;                                                                        
                                }));

                                utils.appendToFile("Log.txt", foundItem.item + " : " + total + " : " + foundItem.type);

                                string response = utils.buyItem(url, buyQuery, foundItem.item);
                                if (response.Contains("problem") || response.Contains("already") || response.Contains("error"))
                                {
                                    Invoke(new Action(() =>
                                    {
                                        BuyTriesListView.Items.Add("Couldn't buy").ForeColor = Color.Red;
                                    }));
                                }
                                else
                                {
                                    Invoke(new Action(() =>
                                    {
                                        BuyTriesListView.Items.Add("Bought something").ForeColor = Color.Green;
                                    }));
                                }

                                utils.appendToFile("BuyResponse.txt", response);
                                utils.appendToFile("BuyResponse.txt", "\n\n");
                                System.Threading.Thread.Sleep(30000);
                            }
                            else
                            {
                                Invoke(new Action(() =>
                                {
                                    LogListView.Items.Add(total.ToString()).ForeColor = Color.Red;
                                }));

                                //utils.appendToFile("Kek2.txt", foundItem.item + " : " + total);
                            }
                        }
                    }
                }
                else
                {
                    /* do something */
                    continue;
                }
                System.Threading.Thread.Sleep(6000);
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            oThread.Abort();
            oThread.Join();
            oThread2.Abort();
            oThread2.Join();
            RunningLabel.Text = "Stopped";
            RunningLabel.ForeColor = Color.Red;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogListView.Items.Clear();
            LogListView.Clear();
        }
    }
}
