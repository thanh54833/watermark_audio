using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class controls_WebUserControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
            
        if ((bool)Session["Dadangnhap"] == true)
        {
            Label2.Text = (String)Session["Tendangnhap"];
        }
    }
}