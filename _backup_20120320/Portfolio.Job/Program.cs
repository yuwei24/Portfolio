using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portfolio.Business;
using Portfolio.Loader;

namespace Portfolio.Job
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!JobEventLog.HasJobRun("AssetLoad", DateTime.Now.Date))
            {

                for (int i = 1; i <= 12; i++)
                {
                    Fund fund = Fund.GetFund(i);

                    AbstractAssetLoader loader = AssetLoaderFactory.CreateLoader(fund);
                    if (loader != null)
                        loader.Load();
                }

                JobEventLog log = JobEventLog.NewJobEventLog();
                log.Job = "AssetLoad";
                log.RunDate = DateTime.Now.Date;
                log.Status = 1;
                log.LastRunOn = DateTime.Now;
                log = log.Save();
            }

            if (!JobEventLog.HasJobRun("CurrencyLoad", DateTime.Now.Date))
            {
                AbstractExchangeLoader exchangeLoader = ExchangeLoaderFactory.CreateLoader();
                exchangeLoader.Load();

                JobEventLog log = JobEventLog.NewJobEventLog();
                log.Job = "CurrencyLoad";
                log.RunDate = DateTime.Now.Date;
                log.Status = 1;
                log.LastRunOn = DateTime.Now;
                log = log.Save();
            }
        }
    }
}
