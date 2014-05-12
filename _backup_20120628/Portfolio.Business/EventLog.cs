using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Csla;
using Csla.Data;

namespace Portfolio.Business
{
    [Serializable()]
    public class EventLog : BusinessBase<EventLog>
    {
        #region Properties

        private static PropertyInfo<int> EventLogIDProperty = RegisterProperty<int>(typeof(EventLog), new PropertyInfo<int>("EventLogID"));
        private static PropertyInfo<string> EventTypeProperty = RegisterProperty<string>(typeof(EventLog), new PropertyInfo<string>("EventType"));        
        private static PropertyInfo<string> MessageProperty = RegisterProperty<string>(typeof(EventLog), new PropertyInfo<string>("Message"));
        private static PropertyInfo<DateTime> LogTimestampProperty = RegisterProperty<DateTime>(typeof(EventLog), new PropertyInfo<DateTime>("LogTimestamp"));

        public int EventLogID
        {
            get { return GetProperty<int>(EventLogIDProperty); }
            set { SetProperty<int>(EventLogIDProperty, value); }
        }

        public string EventType
        {
            get { return GetProperty<string>(EventTypeProperty); }
            set { SetProperty<string>(EventTypeProperty, value); }
        }

        public string Message
        {
            get { return GetProperty<string>(MessageProperty); }
            set { SetProperty<string>(MessageProperty, value); }
        }    

        public DateTime LogTimestamp
        {
            get { return GetProperty<DateTime>(LogTimestampProperty); }
            set { SetProperty<DateTime>(LogTimestampProperty, value); }
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
        #endregion

        #region Factory Methods

        public static EventLog NewEventLog()
        {
            return DataPortal.Create<EventLog>();
        }

        public static EventLog GetEventLog(int EventLogID)
        {
            return DataPortal.Fetch<EventLog>(new SingleCriteria<EventLog, int>(EventLogID));
        }     

        public static EventLog UpdateEventLog(EventLog EventLog)
        {
            return DataPortal.Update<EventLog>(EventLog);
        }

        public static void DeleteEventLog(int EventLogID)
        {
            DataPortal.Delete<EventLog>(new SingleCriteria<EventLog, int>(EventLogID));
        }       

        public override EventLog Save()
        {
            return base.Save();
        }

        private EventLog()
        { /* require use of factory method */ }

        #endregion //Factory Methods

        #region Data Access

        [RunLocal]
        protected override void DataPortal_Create()
        {
            BusinessRules.CheckRules();
        }

        private void DataPortal_Fetch(SingleCriteria<EventLog, int> criteria)
        {            
        }

        protected override void DataPortal_Insert()
        {
            using (var mgr = MyContextManager<Portfolio.Data.DataDataContext>.GetManager("PortfolioConnectionString"))
            {
                int? EventLogID = 0;
                mgr.DataContext.usp_InsertEventLog(
                    ReadProperty<string>(EventTypeProperty),
                    ReadProperty<string>(MessageProperty),
                    ReadProperty<DateTime>(LogTimestampProperty),
                    ref EventLogID);
            } //using
        }

        protected override void DataPortal_Update()
        {         
        }

        private void DataPortal_Delete(SingleCriteria<EventLog, int> criteria)
        {           
        }

        #endregion //Data Access
    }
}
