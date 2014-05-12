using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Csla;
using Csla.Data;

namespace Portfolio.Business
{
    [Serializable()]
    public class JobEventLog : BusinessBase<JobEventLog>
    {
        #region Properties

        private static PropertyInfo<int> JobEventLogIDProperty = RegisterProperty<int>(typeof(JobEventLog), new PropertyInfo<int>("JobEventLogID"));
        private static PropertyInfo<string> JobProperty = RegisterProperty<string>(typeof(JobEventLog), new PropertyInfo<string>("Job"));        
        private static PropertyInfo<DateTime> RunDateProperty = RegisterProperty<DateTime>(typeof(JobEventLog), new PropertyInfo<DateTime>("RunDate"));
        private static PropertyInfo<short> StatusProperty = RegisterProperty<short>(typeof(JobEventLog), new PropertyInfo<short>("Status"));
        private static PropertyInfo<DateTime> LastRunOnProperty = RegisterProperty<DateTime>(typeof(JobEventLog), new PropertyInfo<DateTime>("LastRunOn"));

        public int JobEventLogID
        {
            get { return GetProperty<int>(JobEventLogIDProperty); }
            set { SetProperty<int>(JobEventLogIDProperty, value); }
        }

        public string Job
        {
            get { return GetProperty<string>(JobProperty); }
            set { SetProperty<string>(JobProperty, value); }
        }

        public short Status
        {
            get { return GetProperty<short>(StatusProperty); }
            set { SetProperty<short>(StatusProperty, value); }
        }

        public DateTime RunDate
        {
            get { return GetProperty<DateTime>(RunDateProperty); }
            set { SetProperty<DateTime>(RunDateProperty, value); }
        }

        public DateTime LastRunOn
        {
            get { return GetProperty<DateTime>(LastRunOnProperty); }
            set { SetProperty<DateTime>(LastRunOnProperty, value); }
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
        private class CriteriaJobDate
        {
            string _job;
            DateTime _asOfDate;

            public string Job
            {
                get { return _job; }
                set { _job = value; }
            }

            public DateTime AsOfDate
            {
                get { return _asOfDate; }
                set { _asOfDate = value; }
            }

            public CriteriaJobDate(string job, DateTime asOfDate)
            {
                _job = job;
                _asOfDate = asOfDate;
            }
        }
        #endregion

        #region Factory Methods

        public static JobEventLog NewJobEventLog()
        {
            return DataPortal.Create<JobEventLog>();
        }

        public static JobEventLog GetJobEventLog(int JobEventLogID)
        {
            return DataPortal.Fetch<JobEventLog>(new SingleCriteria<JobEventLog, int>(JobEventLogID));
        }

        public static JobEventLog GetJobEventLog(string job, DateTime asOfDate)
        {
            return DataPortal.Fetch<JobEventLog>(new CriteriaJobDate(job, asOfDate));
        }

        public static JobEventLog UpdateJobEventLog(JobEventLog JobEventLog)
        {
            return DataPortal.Update<JobEventLog>(JobEventLog);
        }

        public static void DeleteJobEventLog(int JobEventLogID)
        {
            DataPortal.Delete<JobEventLog>(new SingleCriteria<JobEventLog, int>(JobEventLogID));
        }

        public static bool HasJobRun(string job, DateTime date)
        {
            using (var mgr = ContextManager<Portfolio.Data.DataDataContext>.GetManager("PortfolioConnectionString"))
            {
                var entities = mgr.DataContext.usp_SelectJobEventLogLastSuccessfulRun(job, date);
                
                if (entities.Count() == 0)           
                    return false;              
                else
                    return true;
              
            } //using
        }

        public override JobEventLog Save()
        {
            return base.Save();
        }

        private JobEventLog()
        { /* require use of factory method */ }

        #endregion //Factory Methods

        #region Data Access

        [RunLocal]
        protected override void DataPortal_Create()
        {
            BusinessRules.CheckRules();
        }

        private void DataPortal_Fetch(SingleCriteria<JobEventLog, int> criteria)
        {            
        }

        private void DataPortal_Fetch(CriteriaJobDate criteria)
        {            
        }

        protected override void DataPortal_Insert()
        {
            using (var mgr = ContextManager<Portfolio.Data.DataDataContext>.GetManager("PortfolioConnectionString"))
            {
                int? JobEventLogID = 0;
                mgr.DataContext.usp_InsertJobEventLog(
                    ReadProperty<string>(JobProperty),
                    ReadProperty<DateTime>(RunDateProperty),
                    ReadProperty<short>(StatusProperty),
                    ReadProperty<DateTime>(LastRunOnProperty),
                    ref JobEventLogID);
            } //using
        }

        protected override void DataPortal_Update()
        {         
        }

        private void DataPortal_Delete(SingleCriteria<JobEventLog, int> criteria)
        {           
        }

        #endregion //Data Access
    }
}
