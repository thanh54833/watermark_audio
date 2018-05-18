using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    string link = "https://drive.google.com/uc?export=download&id=";
    string song_url = "";
    XuLiDB db = new XuLiDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        playnhac();
    }
    public void playnhac()
    {
        
        
        Play__.InnerHtml = "<audio preload='auto' controls><source src='" + song_url + "'></audio>	";
        Play__.InnerHtml += "<script src='../MusicWeb/AudioPlayer/js/jquery.js'></script>";
        Play__.InnerHtml += "<script src='../MusicWeb/AudioPlayer/js/audioplayer.js'></script>";
        Play__.InnerHtml += "<script>$(function () { $('audio').audioPlayer(); });</script>";
        //Download source code tai Sharecode.vn

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string song_url = link + db.GetIDdrive(TextBox1.Text);
    }
}