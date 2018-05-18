<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <asp:Label ID="Label1" runat="server" BorderStyle="None" Text="Tên đăng nhập" 
            Width="186px"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" 
            ToolTip="Tên đăng nhập không được để trống"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" BorderStyle="None" Text="Mật khẩu" 
            Width="184px"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
    </p>
    <p style="margin-left: 200px">
        <asp:Button ID="Button1" runat="server" Text="Đăng nhập" Width="126px" 
            onclick="Button1_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
            Text="Quên mật khẩu" />
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" ForeColor="Red" 
            Text="Tên đăng nhập hoặc mật khẩu không đúng" Visible="False"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
</asp:Content>

