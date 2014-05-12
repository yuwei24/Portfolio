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
    public class ReminderInfo : ReadOnlyBase<ReminderInfo>
    {
        public static PropertyInfo<int> ReminderIDProperty = RegisterProperty<int>(typeof(ReminderInfo), new PropertyInfo<int>("ReminderID"));
        public static PropertyInfo<string> RemarkProperty = RegisterProperty<string>(typeof(ReminderInfo), new PropertyInfo<string>("Remark"));
        public static PropertyInfo<DateTime> DueProperty = RegisterProperty<DateTime>(typeof(ReminderInfo), new PropertyInfo<DateTime>("Due"));

        public int ReminderID
        {
            get { return GetProperty<int>(ReminderIDProperty); }
            set { LoadProperty(ReminderIDProperty, value); }
        }

       
        public string Remark
        {
            get { return GetProperty<string>(RemarkProperty); }
            set { LoadProperty(RemarkProperty, value); }
        }
        
        public DateTime Due
        {
            get { return GetProperty<DateTime>(DueProperty); }
            set { LoadProperty(DueProperty, value); }
        }

        internal ReminderInfo(int _ReminderID, string _Remark, DateTime _Due)
        {
            this.ReminderID = _ReminderID;
            this.Remark = _Remark;
            this.Due = _Due;
        }

        internal ReminderInfo(int _ReminderID)
        {
            this.ReminderID = _ReminderID;
        }

        public ReminderInfo() { }
    }
}
