using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Csla;
using Csla.Data;

namespace Portfolio.Business
{
    [Serializable()]
    public class Price : BusinessBase<Price>
    {
        #region Properties

        private static PropertyInfo<int> PriceIDProperty = RegisterProperty<int>(typeof(Price), new PropertyInfo<int>("PriceID"));
        private static PropertyInfo<int> FundIDProperty = RegisterProperty<int>(typeof(Price), new PropertyInfo<int>("FundID"));
        private static PropertyInfo<decimal> PriceProperty = RegisterProperty<decimal>(typeof(Price), new PropertyInfo<decimal>("Price"));
        private static PropertyInfo<DateTime> PriceDateProperty = RegisterProperty<DateTime>(typeof(Price), new PropertyInfo<DateTime>("PriceDate"));

        public int PriceID
        {
            get { return GetProperty<int>(PriceIDProperty); }
            set { SetProperty<int>(PriceIDProperty, value); }
        }

        public int FundID
        {
            get { return GetProperty<int>(FundIDProperty); }
            set { SetProperty<int>(FundIDProperty, value); }
        }

        public decimal PriceNumber
        {
            get { return GetProperty<decimal>(PriceProperty); }
            set { SetProperty<decimal>(PriceProperty, value); }
        }

        public DateTime PriceDate
        {
            get { return GetProperty<DateTime>(PriceDateProperty); }
            set { SetProperty<DateTime>(PriceDateProperty, value); }
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

        public static Price NewPrice()
        {
            return DataPortal.Create<Price>();
        }

        public static Price GetPrice(int priceID)
        {
            return DataPortal.Fetch<Price>(new SingleCriteria<Price, int>(priceID));
        }

        public static Price GetPrice(int fundID, DateTime asOfDate)
        {
            return DataPortal.Fetch<Price>(new CriteriaFundDate(fundID, asOfDate));
        }

        public static Price UpdatePrice(Price Price)
        {
            return DataPortal.Update<Price>(Price);
        }

        public static void DeletePrice(int priceID)
        {
            DataPortal.Delete<Price>(new SingleCriteria<Price, int>(priceID));
        }

        public override Price Save()
        {
            return base.Save();
        }

        private Price()
        { /* require use of factory method */ }

        #endregion //Factory Methods

        #region Data Access

        [RunLocal]
        protected override void DataPortal_Create()
        {
            BusinessRules.CheckRules();
        }

        private void DataPortal_Fetch(SingleCriteria<Price, int> criteria)
        {
            using (var mgr = ContextManager<Portfolio.Data.DataDataContext>.GetManager("PortfolioConnectionString"))
            {
                var entities = mgr.DataContext.usp_SelectPrice(criteria.Value);
                if (entities.Count() == 0)
                {
                    return;
                }
                var Price = (from d in mgr.DataContext.usp_SelectPrice(criteria.Value)
                             where d.Id == criteria.Value
                             select d).Single();

                LoadProperty(PriceIDProperty, Price.Id);
                LoadProperty(FundIDProperty, Price.FundId);
                LoadProperty(PriceDateProperty, Price.PriceDate);
                LoadProperty(PriceProperty, Price.Price);

                BusinessRules.CheckRules();
            } //using
        }

        private void DataPortal_Fetch(CriteriaFundDate criteria)
        {
            using (var mgr = ContextManager<Portfolio.Data.DataDataContext>.GetManager("PortfolioConnectionString"))
            {
                var entities = mgr.DataContext.usp_SelectPriceByFundAndDate(criteria.FundId, criteria.AsOfDate);
                if (entities.Count() == 0)
                {
                    return;
                }
                var Price = (from d in mgr.DataContext.usp_SelectPriceByFundAndDate(criteria.FundId, criteria.AsOfDate)                        
                             where d.FundId == criteria.FundId && d.PriceDate == criteria.AsOfDate
                             select d).SingleOrDefault();

                if (Price != null)
                {
                    LoadProperty(PriceIDProperty, Price.Id);
                    LoadProperty(FundIDProperty, Price.FundId);
                    LoadProperty(PriceDateProperty, Price.PriceDate);
                    LoadProperty(PriceProperty, Price.Price);
                }

                BusinessRules.CheckRules();
            } //using
        }

        protected override void DataPortal_Insert()
        {
            using (var mgr = ContextManager<Portfolio.Data.DataDataContext>.GetManager("PortfolioConnectionString"))
            {
                int? PriceID = 0;
                mgr.DataContext.usp_InsertPrice(
                    ReadProperty<int>(FundIDProperty),
                    ReadProperty<DateTime>(PriceDateProperty),
                    ReadProperty<decimal>(PriceProperty),
                    ref PriceID);
            } //using
        }

        protected override void DataPortal_Update()
        {
            using (var mgr = ContextManager<Portfolio.Data.DataDataContext>.GetManager("PortfolioConnectionString"))
            {
                if (IsSelfDirty)
                {
                    mgr.DataContext.usp_UpdatePrice(
                        ReadProperty<int>(PriceIDProperty),
                        ReadProperty<int>(FundIDProperty),
                        ReadProperty<DateTime>(PriceDateProperty),
                        ReadProperty<decimal>(PriceProperty)
                        );
                }
            } //using
        }

        private void DataPortal_Delete(SingleCriteria<Price, int> criteria)
        {
            using (var mgr = ContextManager<Portfolio.Data.DataDataContext>.GetManager("PortfolioConnectionString"))
            {
                mgr.DataContext.usp_DeletePrice(criteria.Value);
            }
        }

        #endregion //Data Access
    }
}
