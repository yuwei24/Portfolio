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
    public class FundSupermartLoader : AbstractAssetLoader
    {
        string _url = "http://www.fundsupermart.com/main/fundinfo/dailyPricesHistory.tpl?id=";

        public FundSupermartLoader(Fund fund)
            : base(fund)
        {
        }

        public override void Load()
        {
            try
            {
                _url += Fund.FundCodePrefix + Fund.FundCode;
                HtmlWeb webClient = new HtmlWeb();

                HtmlDocument doc = webClient.Load(_url);

                HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("body[1]/table[1]/tr[3]");

                decimal price = decimal.Parse(nodes[0].ChildNodes[3].InnerText);
                DateTime date = DateTime.Parse(nodes[0].ChildNodes[7].InnerText);

                SavePrice(price, date);

                UpdateAsset(date);
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
