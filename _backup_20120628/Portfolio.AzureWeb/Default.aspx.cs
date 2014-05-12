using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Portfolio.Business;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.WindowsAzure.ServiceRuntime;
using Portfolio.Common;

namespace Portfolio.AzureWeb
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MailHelper.SendMail("will.yu@mercer.com", "yuwei24@gmail.com", "test", "this is a test message from Windows Azure via Gmail");
        }
    }
}
