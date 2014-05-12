using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Csla;
using Csla.Data;

namespace Portfolio.Business
{
    [Serializable()]
    public class ExchangeRate : BusinessBase<ExchangeRate>
    {
        #region Properties

        private static PropertyInfo<int> ExchangeRateIDProperty = RegisterProperty<int>(typeof(ExchangeRate), new PropertyInfo<int>("ExchangeRateID"));
        private static PropertyInfo<string> CurrencyProperty = RegisterProperty<string>(typeof(ExchangeRate), new PropertyInfo<string>("Currency"));        
        private static PropertyInfo<decimal> RateProperty = RegisterProperty<decimal>(typeof(ExchangeRate), new PropertyInfo<decimal>("Rate"));
        private static PropertyInfo<DateTime> RateDateProperty = RegisterProperty<DateTime>(typeof(ExchangeRate), new PropertyInfo<DateTime>("RateDate"));

        public int ExchangeRateID
        {
            get { return GetProperty<int>(ExchangeRateIDProperty); }
            set { SetProperty<int>(ExchangeRateIDProperty, value); }
        }

        public string Currency
        {
            get { return GetProperty<string>(CurrencyProperty); }
            set { SetProperty<string>(CurrencyProperty, value); }
        }

        public decimal Rate
        {
            get { return GetProperty<decimal>(RateProperty); }
            set { SetProperty<decimal>(RateProperty, value); }
        }     

        public DateTime RateDate
        {
            get { return GetProperty<DateTime>(RateDateProperty); }
            set { SetProperty<DateTime>(RateDateProperty, value); }
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
        private class CriteriaCurrencyDate
        {
            string _currency;
            DateTime _asOfDate;

            public string Currency
            {
                get { return _currency; }
                set { _currency = value; }
            }

            public DateTime AsOfDate
            {
                get { return _asOfDate; }
                set { _asOfDate = value; }
            }

            public CriteriaCurrencyDate(string currency, DateTime asOfDate)
            {
                _currency = Currency;
                _asOfDate = asOfDate;
            }
        }
        #endregion

        #region Factory Methods

        public static ExchangeRate NewExchangeRate()
        {
            return DataPortal.Create<ExchangeRate>();
        }

        public static ExchangeRate GetExchangeRate(int ExchangeRateID)
        {
            return DataPortal.Fetch<ExchangeRate>(new SingleCriteria<ExchangeRate, int>(ExchangeRateID));
        }

        public static ExchangeRate GetExchangeRate(string currency, DateTime asOfDate)
        {
            return DataPortal.Fetch<ExchangeRate>(new CriteriaCurrencyDate(currency, asOfDate));
        }

        public static ExchangeRate UpdateExchangeRate(ExchangeRate ExchangeRate)
        {
            return DataPortal.Update<ExchangeRate>(ExchangeRate);
        }

        public static void DeleteExchangeRate(int ExchangeRateID)
        {
            DataPortal.Delete<ExchangeRate>(new SingleCriteria<ExchangeRate, int>(ExchangeRateID));
        }

        public override ExchangeRate Save()
        {
            return base.Save();
        }

        private ExchangeRate()
        { /* require use of factory method */ }

        #endregion //Factory Methods

        #region Data Access

        [RunLocal]
        protected override void DataPortal_Create()
        {
            BusinessRules.CheckRules();
        }

        private void DataPortal_Fetch(CriteriaCurrencyDate criteria)
        {
            using (var mgr = ContextManager<Portfolio.Data.DataDataContext>.GetManager("PortfolioConnectionString"))
            {        
                var ExchangeRate = (from d in mgr.DataContext.usp_SelectExchangeRate(criteria.Currency, criteria.AsOfDate)
                                    where d.Currency == criteria.Currency && d.RateDate == criteria.AsOfDate
                             select d).SingleOrDefault();

                if (ExchangeRate != null)
                {
                    LoadProperty(ExchangeRateIDProperty, ExchangeRate.Id);
                    LoadProperty(CurrencyProperty, ExchangeRate.Currency);
                    LoadProperty(RateDateProperty, ExchangeRate.RateDate);
                    LoadProperty(RateProperty, ExchangeRate.Rate);
                }

                BusinessRules.CheckRules();
            } //using
        }

        protected override void DataPortal_Insert()
        {
            using (var mgr = ContextManager<Portfolio.Data.DataDataContext>.GetManager("PortfolioConnectionString"))
            {
                int? ExchangeRateID = 0;
                mgr.DataContext.usp_InsertExchangeRate(
                    ReadProperty<string>(CurrencyProperty),
                    ReadProperty<decimal>(RateProperty),
                    ReadProperty<DateTime>(RateDateProperty),                    
                    ref ExchangeRateID);
            } //using
        }

        protected override void DataPortal_Update()
        {
            using (var mgr = ContextManager<Portfolio.Data.DataDataContext>.GetManager("PortfolioConnectionString"))
            {
                if (IsSelfDirty)
                {
                    mgr.DataContext.usp_UpdateExchangeRate(
                        ReadProperty <int>(ExchangeRateIDProperty),
                        ReadProperty<string>(CurrencyProperty),
                        ReadProperty<decimal>(RateProperty),
                        ReadProperty<DateTime>(RateDateProperty)     
                        );
                }
            } //using
        }

        private void DataPortal_Delete(SingleCriteria<ExchangeRate, int> criteria)
        {
            using (var mgr = ContextManager<Portfolio.Data.DataDataContext>.GetManager("PortfolioConnectionString"))
            {
                mgr.DataContext.usp_DeleteExchangeRate(criteria.Value);
            }
        }

        #endregion //Data Access
    }
}
