using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Csla;
using Csla.Data;

namespace Portfolio.Business
{
    [Serializable()]
    public class Fund : BusinessBase<Fund>
    {
        #region Properties

        private static PropertyInfo<int> FundIDProperty = RegisterProperty<int>(typeof(Fund), new PropertyInfo<int>("FundID"));
        private static PropertyInfo<string> FundCodeProperty = RegisterProperty<string>(typeof(Fund), new PropertyInfo<string>("FundCode"));
        private static PropertyInfo<string> FundNameProperty = RegisterProperty<string>(typeof(Fund), new PropertyInfo<string>("FundName"));
        private static PropertyInfo<string> FundTypeProperty = RegisterProperty<string>(typeof(Fund), new PropertyInfo<string>("FundType"));
        private static PropertyInfo<string> FundCodePrefixProperty = RegisterProperty<string>(typeof(Fund), new PropertyInfo<string>("FundCodePrefix"));

        public int FundID
        {
            get { return GetProperty<int>(FundIDProperty); }
            set { SetProperty<int>(FundIDProperty, value); }
        }

        public string FundCode
        {
            get { return GetProperty<string>(FundCodeProperty); }
            set { SetProperty<string>(FundCodeProperty, value); }
        }

        public string FundName
        {
            get { return GetProperty<string>(FundNameProperty); }
            set { SetProperty<string>(FundNameProperty, value); }
        }

        public string FundType
        {
            get { return GetProperty<string>(FundTypeProperty); }
            set { SetProperty<string>(FundTypeProperty, value); }
        }

        public string FundCodePrefix
        {
            get { return GetProperty<string>(FundCodePrefixProperty); }
            set { SetProperty<string>(FundCodePrefixProperty, value); }
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

        #region Factory Methods

        public static Fund NewFund()
        {
            return DataPortal.Create<Fund>();
        }

        public static Fund GetFund(int FundID)
        {
            return DataPortal.Fetch<Fund>(new SingleCriteria<Fund, int>(FundID));
        }

        public static List<Fund> GetFunds()
        {
            List<Fund> list = new List<Fund>();

            using (var mgr = MyContextManager<Portfolio.Data.DataDataContext>.GetManager("PortfolioConnectionString"))
            {
                
                list.AddRange(
                    from row in mgr.DataContext.usp_SelectFundsAll()
                    select new Fund(row.Id, row.FundCode, row.FundName, row.FundType, row.FundCodePrefix)
                    );                
            }
            return list;
        }

        public static Fund UpdateFund(Fund Fund)
        {
            return DataPortal.Update<Fund>(Fund);
        }

        public static void DeleteFund(int FundID)
        {
            DataPortal.Delete<Fund>(new SingleCriteria<Fund, int>(FundID));
        }

        public override Fund Save()
        {
            return base.Save();
        }

        private Fund()
        { /* require use of factory method */ }

        private Fund(int Id, string FundCode, string FundName, string FundType, string FundCodePrefix)
        {
            this.FundID = Id;
            this.FundCode = FundCode; 
            this.FundName = FundName;
            this.FundType = FundType;
            this.FundCodePrefix = FundCodePrefix;
        }

        #endregion //Factory Methods

        #region Data Access

        [RunLocal]
        protected override void DataPortal_Create()
        {
            BusinessRules.CheckRules();
        }

        private void DataPortal_Fetch(SingleCriteria<Fund, int> criteria)
        {
            using (var mgr = MyContextManager<Portfolio.Data.DataDataContext>.GetManager("PortfolioConnectionString"))
            {
                var entities = mgr.DataContext.usp_SelectFund(criteria.Value);
                if (entities.Count() == 0)
                {
                    return;
                }
                var Fund = (from d in mgr.DataContext.usp_SelectFund(criteria.Value)
                            where d.Id == criteria.Value
                            select d).Single();

                LoadProperty(FundIDProperty, Fund.Id);
                LoadProperty(FundCodeProperty, Fund.FundCode);
                LoadProperty(FundNameProperty, Fund.FundName);
                LoadProperty(FundTypeProperty, Fund.FundType);
                LoadProperty(FundCodePrefixProperty, Fund.FundCodePrefix);

                BusinessRules.CheckRules();
            } //using
        }

        protected override void DataPortal_Insert()
        {
            using (var mgr = MyContextManager<Portfolio.Data.DataDataContext>.GetManager("PortfolioConnectionString"))
            {
                int? FundID = 0;
                mgr.DataContext.usp_InsertFund(
                    ReadProperty<string>(FundCodeProperty),
                    ReadProperty<string>(FundNameProperty),
                    ReadProperty<string>(FundTypeProperty),
                    ReadProperty<string>(FundCodePrefixProperty),
                    ref FundID);
            } //using
        }

        protected override void DataPortal_Update()
        {
            using (var mgr = MyContextManager<Portfolio.Data.DataDataContext>.GetManager("PortfolioConnectionString"))
            {
                if (IsSelfDirty)
                {
                    mgr.DataContext.usp_UpdateFund(
                        ReadProperty<int>(FundIDProperty),
                        ReadProperty<string>(FundCodeProperty),
                        ReadProperty<string>(FundNameProperty),
                        ReadProperty<string>(FundTypeProperty),
                        ReadProperty<string>(FundCodePrefixProperty)
                        );
                }
            } //using
        }

        private void DataPortal_Delete(SingleCriteria<Fund, int> criteria)
        {
            using (var mgr = MyContextManager<Portfolio.Data.DataDataContext>.GetManager("PortfolioConnectionString"))
            {
                mgr.DataContext.usp_DeleteFund(criteria.Value);
            }
        }

        #endregion //Data Access
    }
}
