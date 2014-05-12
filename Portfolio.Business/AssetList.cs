using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Csla;
using Csla.Data;
using Csla.Serialization;
using Csla.Serialization.Mobile;
using Csla.Core;

namespace Portfolio.Business
{
    [Serializable()]
    public class AssetList : ReadOnlyListBase<AssetList, AssetInfo>
    {
        #region Authorization Rules

        protected static void AddObjectAuthorizationRules()
        {
        }

        #endregion //Authorization Rules

        #region Factory Methods
        public static AssetList GetAssetList(DateTime asOfDate, EventHandler<DataPortalResult<AssetList>> handler = null)
        {
#if SILVERLIGHT
            
            DataPortal<AssetList> dp = new DataPortal<AssetList>();

            if(null!=handler)
                     dp.FetchCompleted += handler;

            dp.BeginFetch(new SingleCriteria<DateTime>(asOfDate));

            return null;

#else
            return DataPortal.Fetch<AssetList>(new SingleCriteria<DateTime>(asOfDate));
#endif

        }

        public static AssetList GetAssetList(DateTime beginDate, DateTime endDate, EventHandler<DataPortalResult<AssetList>> handler = null)
        {
#if SILVERLIGHT
            
            DataPortal<AssetList> dp = new DataPortal<AssetList>();

            if(null!=handler)
                     dp.FetchCompleted += handler;

            dp.BeginFetch(new CriteriaByDateRange<AssetList, DateTime, DateTime>(beginDate, endDate));

            return null;

#else
            return DataPortal.Fetch<AssetList>(new CriteriaByDateRange<AssetList, DateTime, DateTime>(beginDate, endDate));
#endif
        }

        #endregion //Factory Methods

        #region Criteria

        [Serializable()]
        public class CriteriaByDateRange<A, B, C> : CriteriaBase<CriteriaByDateRange<A, B, C>>
        {
            private B _b;
            private C _c;
            public CriteriaByDateRange(B b, C c)
            {
                _b = b;
                _c = c;
            }
            public B BeginDate { get { return _b; } set { _b = value; } }
            public C EndDate { get { return _c; } set { _c = value; } }

            public CriteriaByDateRange() { }

            protected override void OnGetState(SerializationInfo info, StateMode mode)
            {
                base.OnGetState(info, mode);
                info.AddValue("First_Value", BeginDate);
                info.AddValue("Second_Value", EndDate);
            }

            protected override void OnSetState(SerializationInfo info, StateMode mode)
            {
                base.OnSetState(info, mode);
                BeginDate = info.GetValue<B>("First_Value");
                EndDate = info.GetValue<C>("Second_Value");
            }
        }

        #endregion

#if SILVERLIGHT
        public AssetList()
        { /* require use of factory method */ }

#else
        private AssetList()
        { /* require use of factory method */ }

        #region Data Access

        private void DataPortal_Fetch(SingleCriteria<DateTime> criteria)
        {
            using (var mgr = MyContextManager<Portfolio.Data.DataDataContext>.GetManager("PortfolioConnectionString"))
            {
                RaiseListChangedEvents = false;
                IsReadOnly = false;

                this.AddRange(
                    from row in mgr.DataContext.usp_SelectAssetsByDate("", criteria.Value)
                    select new AssetInfo(row.Id, row.FundId, row.FundName, row.FundType, row.Shares, row.Assets, row.AssetDate, row.DailyReturn.Value)
                    );

                IsReadOnly = true;
                RaiseListChangedEvents = true;
            }
        }

        private void DataPortal_Fetch(CriteriaByDateRange<AssetList, DateTime, DateTime> criteria)
        {
            using (var mgr = MyContextManager<Portfolio.Data.DataDataContext>.GetManager("PortfolioConnectionString"))
            {
                RaiseListChangedEvents = false;
                IsReadOnly = false;

                this.AddRange(
                    from row in mgr.DataContext.usp_SelectAssetsByDateRange("", criteria.BeginDate, criteria.EndDate)
                    select new AssetInfo(row.Id, row.FundId, row.FundName, row.FundType, row.Shares, row.Assets.Value, row.AssetDate, row.DailyReturn.Value)
                    );

                IsReadOnly = true;
                RaiseListChangedEvents = true;
            }
        }

        #endregion
#endif
    }
}
