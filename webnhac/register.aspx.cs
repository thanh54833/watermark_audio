using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    XuLiDB DB = new XuLiDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        Label3.Visible = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if(DB.Checkusername(TextBox1.Text) == true)
        {
            Label3.Visible = true;
        } 
        else DB.ThemUser(TextBox1.Text, TextBox2.Text);
        Response.Redirect("login.aspx");


    }
}