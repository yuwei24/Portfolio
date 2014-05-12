using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portfolio.Business;
using System.IO;
using System.Net;
using System.Xml;
using HtmlAgilityPack;

namespace Portfolio.Loader
{
    public class DefaultExchangeLoader : AbstractExchangeLoader
    {
        string _url = "http://www.boc.cn/sourcedb/whpj/enindex.html";

        public DefaultExchangeLoader()
            : base()
        {
        }

        public override void Load()
        {
            try
            {
                decimal rate = 0;
                DateTime date = DateTime.Now;
                string currency = string.Empty;

                HtmlWeb webClient = new HtmlWeb();

                HtmlDocument doc = webClient.Load(_url);

                HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("/html[1]/body[1]/table[2]/tr[1]/td[2]/table[2]/tr[1]/td[1]/table[1]/tr");
                foreach (HtmlNode node in nodes)
                {
                    currency = node.ChildNodes[1].InnerText;
                    if (currency == "USD" || currency == "SGD" || currency == "HKD" || currency == "EUR")
                    {
                        rate = decimal.Parse(node.ChildNodes[3].InnerText);
                        date = DateTime.Parse(node.ChildNodes[13].InnerText.Substring(0, 10));
                        SaveExchangeRate(currency, rate, date);
                    }
                }                           
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
