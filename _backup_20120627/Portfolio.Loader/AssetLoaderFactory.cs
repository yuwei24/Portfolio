using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portfolio.Business;

namespace Portfolio.Loader
{
    public class AssetLoaderFactory
    {
        public static AbstractAssetLoader CreateLoader(Fund fund)
        {
            if (fund.FundType == "SHA")
                return new SHALoader(fund);
            else if (fund.FundType == "SHMF")
                return new SHMFLoader(fund);
            else if (fund.FundType == "SHCF" || fund.FundType == "CASH")
                return new SHCFLoader(fund);
            else if (fund.FundType == "SGMF")
                return new FundSupermartLoader(fund);
            else
                return null;
        }
    }
}
