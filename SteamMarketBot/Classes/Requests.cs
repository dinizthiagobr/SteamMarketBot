using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SteamMarketBot.Classes
{
    public class Requests
    {
        public const string host = "steamcommunity.com";
        public const string mainSite = "http://" + host + "/";
        public const string mainSiteSecure = "https://" + host + "/";
        public const string market = mainSite + "market/";
        public const string buyListing = mainSiteSecure + "market/buylisting/";
        public const string listings = market + "listings/";
        public const string recentListing = market + "recent";
        public const string steamUserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";

        public const string buyQuery = "sessionid={0}&currency={1}&subtotal={2}&fee={3}&total={4}&quantity=1";
        public const string newlyListedQuery = "?country={0}&language={1}&currency={2}";

        public CookieContainer ck;

        public Requests(CookieContainer _ck)
        {
            ck = _ck;
        }

        public string SendGet(string url)
        {
            string content = string.Empty;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                request.Proxy = null;
                request.Timeout = 30000;

                request.KeepAlive = true;
                request.AutomaticDecompression = DecompressionMethods.GZip;

                request.Host = host;
                request.Referer = market;
                request.UserAgent = steamUserAgent;

                request.Accept = "text/javascript, text/html, application/xml, text/xml, */*";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";

                request.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
                request.Headers.Add("Accept-Language", "en-US,en;q=0.8,pt;q=0.6,es;q=0.4");
                request.Headers.Add("Cache-Control", "no-cache");

                request.CookieContainer = ck;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var stream = new StreamReader(response.GetResponseStream());
                    content = stream.ReadToEnd();
                    stream.Close();
                }
                else content = string.Empty;

                response.Close();
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse resp = (HttpWebResponse)e.Response;
                    Utils.appendToFileqq("Errors.txt", resp.StatusDescription);
                    return resp.StatusDescription;
                }                
            }
            return content;
        }

        public string SendPost(string url, string data, string referer)
        {
            byte[] requestData = Encoding.UTF8.GetBytes(data);
            string content = string.Empty;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";

                request.Proxy = null;
                request.Timeout = 30000;

                request.KeepAlive = true;
                request.AutomaticDecompression = DecompressionMethods.GZip;

                request.Host = host;                
                request.Referer = referer;
                request.UserAgent = steamUserAgent;

                request.Accept = "text/javascript, text/html, application/xml, text/xml, */*";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";

                request.Headers.Add("Accept-Encoding", "gzip, deflate");
                request.Headers.Add("Accept-Language", "en-US,en;q=0.8,pt;q=0.6,es;q=0.4");                

                request.CookieContainer = ck;

                Stream dataStream = request.GetRequestStream();
                dataStream.Write(requestData, 0, requestData.Length);
                dataStream.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var stream = new StreamReader(response.GetResponseStream());
                    content = stream.ReadToEnd();
                    stream.Close();
                }
                else content = string.Empty;

                response.Close();
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse resp = (HttpWebResponse)e.Response;
                    using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
                    {
                        content = sr.ReadToEnd();
                    }
                    return content;
                    //return resp.StatusDescription;
                    /*int statCode = (int)resp.StatusCode;

                    if (statCode == 403)
                    {
                        content = "403";
                    }
                    else
                    {
                        using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
                        {
                            content = sr.ReadToEnd();
                        }
                    }*/
                }
            }
            return content;
        }   
    }
}
