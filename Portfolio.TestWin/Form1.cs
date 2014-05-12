using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Portfolio.Business;
using Portfolio.Loader;
using Portfolio.Common;

namespace Portfolio.TestWin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Fund f = Fund.NewFund();
            //f.FundCode = "SI";
            //f.FundCodePrefix = "hf_";

            //AbstractAssetLoader loader = new FTLoader(f);
            //loader.Load();

            AbstractExchangeLoader loader = new GoogleExchangeLoader();
            loader.Load();

            //AssetList list = AssetList.GetAssetList(new DateTime(2000, 1, 1), new DateTime(2012, 3, 17));
            //AbstractExchangeLoader loader = new GoogleExchangeLoader();
            //loader.Load();
            //Portfolio.Common.LogHelper.LogEvent("Test");

            //if (!JobEventLog.HasJobRun("ReminderCheck", DateTime.Now.Date))
            //{

            //    try
            //    {
            //        ReminderList reminders = ReminderList.GetReminderList(DateTime.Now.Date);
            //        foreach (ReminderInfo reminder in reminders)
            //        {
            //            MailHelper.SendMail("", "", "Portfolio Reminder", "You have one portfolio item maturing on " + reminder.Due.ToShortDateString() + " (" + reminder.Remark + ")");
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        LogHelper.LogException(ex);
            //        MailHelper.SendMail("", "", "Reminder check failure", ex.ToString());
            //    }              
            //}
        }
    }
}
