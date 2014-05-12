using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portfolio.Business;
using System.IO;
using System.Net;

namespace Portfolio.Loader
{
    public abstract class AbstractExchangeLoader
    {
        public AbstractExchangeLoader()
        {
        }

        public abstract void Load();

        internal string GetResponse(string StrURL)
        {
            string strReturn = "";
            HttpWebRequest objRequest = null;
            //IAsyncResult ar = null;
            HttpWebResponse objResponse = null;
            StreamReader objs = null;
            try
            {

                objRequest = (HttpWebRequest)WebRequest.Create(StrURL);                
                objResponse = (HttpWebResponse)objRequest.GetResponse();
                objs = new StreamReader(objResponse.GetResponseStream());
                strReturn = objs.ReadToEnd();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                if (objResponse != null)
                    objResponse.Close();
                objRequest = null;
                //ar = null;
                objResponse = null;
                objs = null;
            }
            return strReturn;
        }

        internal void SaveExchangeRate(string currency, decimal rate, DateTime asOfDate)
        {
            ExchangeRate objRate = ExchangeRate.GetExchangeRate(currency, asOfDate);
            if (objRate.ExchangeRateID == 0)
            {
                objRate = ExchangeRate.NewExchangeRate();
                objRate.Currency = currency;
                objRate.Rate = rate;
                objRate.RateDate = asOfDate;
                objRate = objRate.Save();
            }
        }       
    }
}
