using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for XuLiDB
/// </summary>
public class XuLiDB
{
    String chuoiketnoi = ConfigurationManager.ConnectionStrings["wtm"].ConnectionString;
    SqlConnection ketnoi;
    public XuLiDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    
    
    public void MoKetNoi()
    {
        ketnoi = new SqlConnection(chuoiketnoi);
        ketnoi.Open();
 
    }
    public void NgatKetNoi()
    {
        ketnoi.Close();
    }
    public bool Kiemdangnhap(String s1, String s2)
    {
        MoKetNoi();
        SqlCommand command = new SqlCommand("Select * from [User] where Username = @s1 and Password =@s2", ketnoi);
        command.Parameters.AddWithValue("s1", s1);
        command.Parameters.AddWithValue("s2", s2);
        SqlDataReader reader = command.ExecuteReader();
        bool ok = false;
        if (reader.HasRows == true) ok = true;
        NgatKetNoi();
        return ok;
    }

    public String GetIDdrive(String texID)
    {
        int x = Convert.ToInt32(texID);
        String IDget;
        MoKetNoi();
        SqlCommand command = new SqlCommand("Select IDdrive from Music where MusicID = '"+x+"'", ketnoi);

        IDget = command.ExecuteScalar().ToString();

        NgatKetNoi();
        return IDget;
    }

    public DataTable Laydsbh()
    {
        DataTable bangtrave = new DataTable();
        MoKetNoi();
        SqlCommand command = new SqlCommand("Select* from Music", ketnoi);
        SqlDataReader reader = command.ExecuteReader();
        bangtrave.Load(reader);
        NgatKetNoi();
        return bangtrave;
    }


  
    public bool Checkusername(String s1)
    {
        MoKetNoi();
        SqlCommand command = new SqlCommand("Select * from [User] where Username=@s1", ketnoi);
        command.Parameters.AddWithValue("s1", s1);
        SqlDataReader reader = command.ExecuteReader();
        bool ok = false;
        if (reader.HasRows == true) ok = true;
        NgatKetNoi();
        return ok;
    }
    public bool ThemUser(string name, string pass)
    {
        bool ok;
        MoKetNoi();
        SqlCommand command = new SqlCommand("insert into [User] (Username,Password) values(@name,@pass)", ketnoi);
        command.Parameters.AddWithValue("name", name);
        command.Parameters.AddWithValue("pass", pass);

        try
        {
            command.ExecuteNonQuery();
            ok = true;
        }
        catch
        {
            ok = false;
        }
        NgatKetNoi();
        return ok;
    }
  

    public bool Checkmabh(String s1)
    {
        MoKetNoi();
        SqlCommand command = new SqlCommand("Select * from TTHS where MSHS= @s1 ", ketnoi);
        command.Parameters.AddWithValue("s1", s1);
        SqlDataReader reader = command.ExecuteReader();
        bool ok = false;
        if (reader.HasRows == true) ok = true;
        NgatKetNoi();
        return ok;
    }
}
