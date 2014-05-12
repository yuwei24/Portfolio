using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Csla;
using Csla.Data;

namespace Portfolio.Business
{
    [Serializable()]
    public class Asset : BusinessBase<Asset>
    {
        #region Properties

        private static PropertyInfo<int> AssetIDProperty = RegisterProperty<int>(typeof(Asset), new PropertyInfo<int>("AssetID"));
        private static PropertyInfo<int> FundIDProperty = RegisterProperty<int>(typeof(Asset), new PropertyInfo<int>("FundID"));
        private static PropertyInfo<decimal> SharesProperty = RegisterProperty<decimal>(typeof(Asset), new PropertyInfo<decimal>("Shares"));
        private static PropertyInfo<decimal> AssetsProperty = RegisterProperty<decimal>(typeof(Asset), new PropertyInfo<decimal>("Assets"));
        private static PropertyInfo<DateTime> AssetDateProperty = RegisterProperty<DateTime>(typeof(Asset), new PropertyInfo<DateTime>("AssetDate"));

        public int AssetID
        {
            get { return GetProperty<int>(AssetIDProperty); }
            set { SetProperty<int>(AssetIDProperty, value); }
        }

        public int FundID
        {
            get { return GetProperty<int>(FundIDProperty); }
            set { SetProperty<int>(FundIDProperty, value); }
        }

        public decimal Shares
        {
            get { return GetProperty<decimal>(SharesProperty); }
            set { SetProperty<decimal>(SharesProperty, value); }
        }

        public decimal Assets
        {
            get { return GetProperty<decimal>(AssetsProperty); }
            set { SetProperty<decimal>(AssetsProperty, value); }
        }

        public DateTime AssetDate
        {
            get { return GetProperty<DateTime>(AssetDateProperty); }
            set { SetProperty<DateTime>(AssetDateProperty, value); }
        }

        #endregion //Properties

        #region Validation Rules

        protected override void AddBusinessRules()
        {
        }

        #endregion //Validation Rules

        #region Authorization Rules

        protected static void AddObjectAuthorizationRules()
        {
            //TODO: Define object-level authorization rules of Scheme
        }

        #endregion //Authorization Rules

        #region Criterias
        [Serializable()]
        private class CriteriaFundDate
        {
            int _fundId;
            DateTime _asOfDate;

            public int FundId
            {
                get { return _fundId; }
                set { _fundId = value; }
            }

            public DateTime AsOfDate
            {
                get { return _asOfDate; }
                set { _asOfDate = value; }
            }

            public CriteriaFundDate(int fundId, DateTime asOfDate)
            {
                _fundId = fundId;
                _asOfDate = asOfDate;
            }
        }
        #endregion

        #region Factory Methods

        public static Asset NewAsset()
        {
            return DataPortal.Create<Asset>();
        }

        public static Asset GetAsset(int AssetID)
        {
            return DataPortal.Fetch<Asset>(new SingleCriteria<Asset, int>(AssetID));
        }

        public static Asset GetAsset(int fundID, DateTime asOfDate)
        {
            return DataPortal.Fetch<Asset>(new CriteriaFundDate(fundID, asOfDate));
        }

        public static Asset UpdateAsset(Asset Asset)
        {
            return DataPortal.Update<Asset>(Asset);
        }

        public static void DeleteAsset(int AssetID)
        {
            DataPortal.Delete<Asset>(new SingleCriteria<Asset, int>(AssetID));
        }

        public override Asset Save()
        {
            return base.Save();
        }

        private Asset()
        { /* require use of factory method */ }

        #endregion //Factory Methods

        #region Data Access

        [RunLocal]
        protected override void DataPortal_Create()
        {
            BusinessRules.CheckRules();
        }

        private void DataPortal_Fetch(SingleCriteria<Asset, int> criteria)
        {
            using (var mgr = ContextManager<Portfolio.Data.DataDataContext>.GetManager("PortfolioConnectionString"))
            {
                var entities = mgr.DataContext.usp_SelectAsset(criteria.Value);
                if (entities.Count() == 0)
                {
                    return;
                }
                var Asset = (from d in mgr.DataContext.usp_SelectAsset(criteria.Value)
                             where d.Id == criteria.Value
                             select d).Single();

                LoadProperty(AssetIDProperty, Asset.Id);
                LoadProperty(FundIDProperty, Asset.FundId);
                LoadProperty(AssetDateProperty, Asset.AssetDate);
                LoadProperty(SharesProperty, Asset.Shares);
                LoadProperty(AssetsProperty, Asset.Assets);

                BusinessRules.CheckRules();
            } //using
        }

        private void DataPortal_Fetch(CriteriaFundDate criteria)
        {
            using (var mgr = ContextManager<Portfolio.Data.DataDataContext>.GetManager("PortfolioConnectionString"))
            {
                var entities = mgr.DataContext.usp_SelectAssetByFundAndDate(criteria.FundId, criteria.AsOfDate);
                if (entities.Count() == 0)
                {
                    return;
                }
                var Asset = (from d in mgr.DataContext.usp_SelectAssetByFundAndDate(criteria.FundId, criteria.AsOfDate)
                             where d.FundId == criteria.FundId && d.AssetDate == criteria.AsOfDate
                             select d).SingleOrDefault();

                if (Asset != null)
                {
                    LoadProperty(AssetIDProperty, Asset.Id);
                    LoadProperty(FundIDProperty, Asset.FundId);
                    LoadProperty(AssetDateProperty, Asset.AssetDate);
                    LoadProperty(SharesProperty, Asset.Shares);
                    LoadProperty(AssetsProperty, Asset.Assets);
                }

                BusinessRules.CheckRules();
            } //using
        }

        protected override void DataPortal_Insert()
        {
            using (var mgr = ContextManager<Portfolio.Data.DataDataContext>.GetManager("PortfolioConnectionString"))
            {
                int? AssetID = 0;
                mgr.DataContext.usp_InsertAsset(
                    ReadProperty<int>(FundIDProperty),
                    ReadProperty<DateTime>(AssetDateProperty),
                    ReadProperty<decimal>(SharesProperty),
                    ReadProperty<decimal>(AssetsProperty),
                    ref AssetID);
            } //using
        }

        protected override void DataPortal_Update()
        {
            using (var mgr = ContextManager<Portfolio.Data.DataDataContext>.GetManager("PortfolioConnectionString"))
            {
                if (IsSelfDirty)
                {
                    mgr.DataContext.usp_UpdateAsset(
                        ReadProperty<int>(AssetIDProperty),
                        ReadProperty<int>(FundIDProperty),
                        ReadProperty<DateTime>(AssetDateProperty),
                        ReadProperty<decimal>(SharesProperty),
                        ReadProperty<decimal>(AssetsProperty)
                        );
                }
            } //using
        }

        private void DataPortal_Delete(SingleCriteria<Asset, int> criteria)
        {
            using (var mgr = ContextManager<Portfolio.Data.DataDataContext>.GetManager("PortfolioConnectionString"))
            {
                mgr.DataContext.usp_DeleteAsset(criteria.Value);
            }
        }

        #endregion //Data Access
    }
}
