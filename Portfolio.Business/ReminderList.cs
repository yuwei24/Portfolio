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
    public class ReminderList : ReadOnlyListBase<ReminderList, ReminderInfo>
    {
        #region Authorization Rules

        protected static void AddObjectAuthorizationRules()
        {
        }

        #endregion //Authorization Rules

        #region Factory Methods
        public static ReminderList GetReminderList(DateTime asOfDate)
        {
            return DataPortal.Fetch<ReminderList>(new SingleCriteria<DateTime>(asOfDate));
        }
       
        #endregion //Factory Methods


        private ReminderList()
        { /* require use of factory method */ }

        #region Data Access

        private void DataPortal_Fetch(SingleCriteria<DateTime> criteria)
        {
            using (var mgr = MyContextManager<Portfolio.Data.DataDataContext>.GetManager("PortfolioConnectionString"))
            {
                RaiseListChangedEvents = false;
                IsReadOnly = false;

                this.AddRange(
                    from row in mgr.DataContext.usp_SelectRemindersByDate(criteria.Value)
                    select new ReminderInfo(row.Id, row.Remarks, row.Due)
                    );

                IsReadOnly = true;
                RaiseListChangedEvents = true;
            }
        }        

        #endregion
    }
}
