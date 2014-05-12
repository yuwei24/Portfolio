using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portfolio.Business;
using System.IO;
using System.Net;
using Portfolio.Common;

namespace Portfolio.Loader
{
    public class SHMFLoader : AbstractAssetLoader
    {
        string _url = "http://hq.sinajs.cn/list=";

        public SHMFLoader(Fund fund)
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
                decimal price = decimal.Parse(results[1]);

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
