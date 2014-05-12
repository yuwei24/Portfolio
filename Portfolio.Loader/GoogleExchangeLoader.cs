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
    public class GoogleExchangeLoader : AbstractExchangeLoader
    {
        //string _url = "http://www.boc.cn/sourcedb/whpj/enindex.html";
        string _url = "https://www.google.com/finance/converter?a=100&from={0}&to={1}";
        string[] _currencies = new[] { "USD", "SGD", "HKD", "EUR" };

        public GoogleExchangeLoader()
            : base()
        {
        }

        public override void Load()
        {
            try
            {
                foreach (string currency in _currencies)
                {
                    LoadExchangeRate(currency);                 
                }                            
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadExchangeRate(string currency)
        {
            decimal rate = 0;
            DateTime date = DateTime.Now;            

            string url = string.Format(_url, currency, "CNY");

            string result = GetResponse(url);
            //{lhs: "100 U.S. dollars",rhs: "637.950393 Chinese yuan",error: "",icc: true}
            //<span class=bld>60.9080 CNY</span>
            result = result.Substring(result.IndexOf("<span class=bld>"));
            result = result.Replace("<span class=bld>", "");
            result = result.Substring(0, result.IndexOf(" "));

            rate = decimal.Parse(result);

            SaveExchangeRate(currency, rate, date.Date);
        }
    }
}
