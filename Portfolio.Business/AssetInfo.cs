using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Csla;
using Csla.Data;
using Csla.Serialization;

namespace Portfolio.Business
{
    [Serializable()]
    public class AssetInfo : ReadOnlyBase<AssetInfo>
    {
        public static PropertyInfo<int> AssetIDProperty = RegisterProperty<int>(typeof(AssetInfo), new PropertyInfo<int>("AssetID"));
        public static PropertyInfo<int> FundIDProperty = RegisterProperty<int>(typeof(AssetInfo), new PropertyInfo<int>("FundID"));
        public static PropertyInfo<string> FundNameProperty = RegisterProperty<string>(typeof(AssetInfo), new PropertyInfo<string>("FundName"));
        public static PropertyInfo<string> FundTypeProperty = RegisterProperty<string>(typeof(AssetInfo), new PropertyInfo<string>("FundType"));
        public static PropertyInfo<decimal> SharesProperty = RegisterProperty<decimal>(typeof(AssetInfo), new PropertyInfo<decimal>("Shares"));
        public static PropertyInfo<decimal> AssetsProperty = RegisterProperty<decimal>(typeof(AssetInfo), new PropertyInfo<decimal>("Assets"));
        public static PropertyInfo<DateTime> AssetDateProperty = RegisterProperty<DateTime>(typeof(AssetInfo), new PropertyInfo<DateTime>("AssetDate"));
        public static PropertyInfo<decimal> DailyReturnProperty = RegisterProperty<decimal>(typeof(AssetInfo), new PropertyInfo<decimal>("DailyReturn"));

        public int AssetID
        {
            get { return GetProperty<int>(AssetIDProperty); }
            set { LoadProperty(AssetIDProperty, value); }
        }

        public int FundID
        {
            get { return GetProperty<int>(FundIDProperty); }
            set { LoadProperty(FundIDProperty, value); }
        }
        public string FundName
        {
            get { return GetProperty<string>(FundNameProperty); }
            set { LoadProperty(FundNameProperty, value); }
        }
        public string FundType
        {
            get { return GetProperty<string>(FundTypeProperty); }
            set { LoadProperty(FundTypeProperty, value); }
        }
        public decimal Shares
        {
            get { return GetProperty<decimal>(SharesProperty); }
            set { LoadProperty(SharesProperty, value); }
        }
        public decimal Assets
        {
            get { return GetProperty<decimal>(AssetsProperty); }
            set { LoadProperty(AssetsProperty, value); }
        }
        public DateTime AssetDate
        {
            get { return GetProperty<DateTime>(AssetDateProperty); }
            set { LoadProperty(AssetDateProperty, value); }
        }
        public decimal DailyReturn
        {
            get { return GetProperty<decimal>(DailyReturnProperty); }
            set { LoadProperty(DailyReturnProperty, value); }
        }
        public string FundNameAndReturnDisplay
        {
            get { return this.FundName + " " + this.DailyReturn.ToString("0.00%"); }
        }

        internal AssetInfo(int _assetID, int _fundID, string _fundName, string _fundType, decimal _shares, decimal _assets, DateTime _assetDate, decimal _dailyReturn)
        {
            this.AssetID = _assetID;
            this.FundID = _fundID;
            this.FundName = _fundName;
            this.FundType = _fundType;
            this.Shares = _shares;
            this.Assets = _assets;
            this.AssetDate = _assetDate;
            this.DailyReturn = _dailyReturn;
        }

        internal AssetInfo(int _assetID)
        {
            this.AssetID = _assetID;
        }

        public AssetInfo() { }
    }
}
