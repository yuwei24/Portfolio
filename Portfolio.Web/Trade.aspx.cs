using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Portfolio.Business;

namespace Portfolio.Web
{
    public partial class Trade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateFormData();
            }
        }

        private void PopulateFormData()
        {
            this.ddlFund.DataSource = Fund.GetFunds();
            
            this.ddlFund.DataTextField = "FundName";
            this.ddlFund.DataValueField = "FundID";

            this.ddlFund.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {            
        }
    }
}