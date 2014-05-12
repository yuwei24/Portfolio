using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portfolio.Business;
using System.IO;
using System.Net;

namespace Portfolio.Loader
{
    public abstract class AbstractAssetLoader
    {
        private Fund _fund;

        public Fund Fund
        {
            get { return _fund; }
            set { _fund = value; }
        }

        public AbstractAssetLoader(Fund fund)
        {
            this._fund = fund;
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

        internal void SavePrice(decimal price, DateTime asOfDate)
        {
            Price objPrice = Price.GetPrice(Fund.FundID, asOfDate);
            if (objPrice.PriceID == 0)
            {
                objPrice = Price.NewPrice();
                objPrice.FundID = this.Fund.FundID;
                objPrice.PriceNumber = price;
                objPrice.PriceDate = asOfDate;
                objPrice = objPrice.Save();
            }
        }

        internal void UpdateAsset(DateTime asOfDate)
        {
            Asset objAsset = Asset.GetAsset(Fund.FundID, asOfDate);
            if (objAsset.AssetID == 0)
            {
                objAsset = Asset.NewAsset();
                objAsset.FundID = this.Fund.FundID;
                objAsset.Shares = 0;
                objAsset.Assets = 0;
                objAsset.AssetDate = asOfDate;
                objAsset = objAsset.Save();
            }
        }
    }
}
