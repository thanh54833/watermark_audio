using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    XuLiDB DB = new XuLiDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        Label3.Visible = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        bool ok = DB.Kiemdangnhap(TextBox1.Text, TextBox2.Text);
        if (ok)
        {
            Session["Dadangnhap"] = true;
            
            Session["Tendangnhap"] = TextBox1.Text;
            Response.Redirect("Tainhac.aspx");
        }
        else Label3.Visible = true;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
       
    }
}