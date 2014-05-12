using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Portfolio.Business;

namespace Portfolio.Test
{
    public partial class Form1 : Form
    {
        static void Main()
        {
            Form1 form = new Form1();
            form.Show();
        }

        public Form1()
        {
            InitializeComponent();

            Fund fund = Fund.GetFund(1);
            this.label1.Text = fund.FundName;
        }
    }
}
