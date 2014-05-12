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

namespace Portfolio.TestWin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            EventLog log = EventLog.NewEventLog();
            log.EventType = "Event";
            log.Message = "Test";
            log.LogTimestamp = DateTime.Now;
            log.Save();
        }
    }
}
