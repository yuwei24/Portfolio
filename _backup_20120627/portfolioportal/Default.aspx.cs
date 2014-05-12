using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_InitComplete(object sender, EventArgs e)
    {
        
    }

    protected override void OnPreLoad(EventArgs e)
    {
        string[] datasource = new string[3];
        datasource[0] = "1";
        datasource[1] = "2";
        datasource[2] = "3";

        this.DropDownList1.DataSource = datasource;
        this.DropDownList1.DataBind();    
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Trace.Write("Event", "Page Load");        
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Trace.Write("Event", "ImageButton1_Click");
    }
}
