using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portfolio.Business;
using System.IO;
using System.Net;
using HtmlAgilityPack;
using Portfolio.Common;

namespace Portfolio.Loader
{
    public class SHALoader : AbstractAssetLoader
    {
        string _url = "http://hq.sinajs.cn/list=";
        //string _url = "http://money.finance.sina.com.cn/corp/go.php/vMS_MarketHistory/stockid/";

        public SHALoader(Fund fund)
            : base(fund)
        {
        }

        public override void Load()
        {
            try
            {
                _url += Fund.FundCodePrefix + Fund.FundCode;

                string result = GetResponse(_url);
                string[] results = result.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                decimal price = decimal.Parse(results[2]); //last closing price

                DateTime asOfDate = DateHelper.GetAsOfDate();

                SavePrice(price, asOfDate);

                UpdateAsset(asOfDate);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }        
    }
}
