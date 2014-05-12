using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;
using Portfolio.Business;
using Portfolio.Loader;
using Portfolio.Common;

namespace Portfolio.AzureJobRole
{
    public class WorkerRole : RoleEntryPoint
    {
        const string mailAddress = "yuwei24@gmail.com";

        public override void Run()
        {            
            while (true)
            {
                Thread.Sleep(3600000);
                Execute();
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections 
            ServicePointManager.DefaultConnectionLimit = 12;

            LogHelper.LogEvent("JobWorkerRole Starts");
            MailHelper.SendMail(mailAddress, mailAddress, "Portfolio JobWorkerRole Starts", "");
            
            return base.OnStart();
        }

        public override void OnStop()
        {
            LogHelper.LogEvent("JobWorkerRole Stops");
            MailHelper.SendMail(mailAddress, mailAddress, "Portfolio JobWorkerRole Stops", "");

            base.OnStop();
        }

        private void Execute()
        {            
            short success = 1;
            JobEventLog log;

            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday || DateTime.Now.Hour > 10)
                return;

            LogHelper.LogEvent("JobWorkerRole Fires");

            if (!JobEventLog.HasJobRun("AssetLoad", DateTime.Now.Date))
            {               
                try
                {
                    List<Fund> funds = Fund.GetFunds();
                    foreach (Fund fund in funds)
                    {
                        AbstractAssetLoader loader = AssetLoaderFactory.CreateLoader(fund);
                        if (loader != null)
                            loader.Load();
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.LogException(ex);
                    MailHelper.SendMail(mailAddress, mailAddress, "Portfolio load failure", ex.ToString());
                    success = -1;
                }

                log = JobEventLog.NewJobEventLog();
                log.Job = "AssetLoad";
                log.RunDate = DateTime.Now.Date;
                log.Status = success;
                log.LastRunOn = DateTime.Now;
                log = log.Save();
            }
            
            if (!JobEventLog.HasJobRun("CurrencyLoad", DateTime.Now.Date))
            {
                try
                {
                    AbstractExchangeLoader exchangeLoader = ExchangeLoaderFactory.CreateLoader();
                    exchangeLoader.Load();
                    success = 1;
                }
                catch (Exception ex)
                {
                    LogHelper.LogException(ex);
                    MailHelper.SendMail(mailAddress, mailAddress, "Portfolio load failure", ex.ToString());
                    success = -1;
                }

                log = JobEventLog.NewJobEventLog();
                log.Job = "CurrencyLoad";
                log.RunDate = DateTime.Now.Date;
                log.Status = success;
                log.LastRunOn = DateTime.Now;
                log = log.Save();
            }
        }
    }
}
