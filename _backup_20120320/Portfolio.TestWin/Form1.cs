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

            //AssetList list = AssetList.GetAssetList(new DateTime(2000, 1, 1), new DateTime(2012, 3, 17));
            AbstractExchangeLoader loader = new DefaultExchangeLoader();
            loader.Load();
        }
    }
}
