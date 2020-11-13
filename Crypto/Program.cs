using System;
using System.Text;
using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
using System.IO;
using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
using System.Net;
//using System.Threading.Tasks;

namespace Crypto
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://min-api.cryptocompare.com/data/pricemulti?fsyms=BTC,ETH,DASH&tsyms=USD";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json; charset=utf-8";
            request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes("username:password"));
            request.PreAuthenticate = true;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                string list = reader.ReadToEnd();
                //Console.WriteLine(list);

                Dictionary<string, object> objectlist = JsonConvert.DeserializeObject<Dictionary<string, object>>(list);

                string[] tickers = new string[] { "BTC", "ETH", "DASH" };

                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                using (FileStream fs = new FileStream(path + "/answer.htm", FileMode.OpenOrCreate))
                {

                    using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                    {
                        w.WriteLine("<H1>List for Cryptoprices</H1>");

                        foreach (string t in tickers)
                        {
                            string pr = objectlist[t].ToString();
                            pr = pr.Trim(new char[] { '{', '}' });
                            int s = pr.IndexOf(':');
                            pr = pr.Remove(1, s);

                            w.WriteLine("<table><tr><td>" + t + "</td ><td>" + pr + "</td></tr></table>");

                        }

                    }
                }
            }
            Console.WriteLine("Тhe information has saved in file answer.htm on Desktop.Plese press any key to complete.");
            Console.ReadKey();
        }
    }
}
