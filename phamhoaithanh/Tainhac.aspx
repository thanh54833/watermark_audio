<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Tainhac.aspx.cs" Inherits="Trangtainhac" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
    <asp:Label ID="Label1" runat="server" Text="nhap ma bai nhac de tai"></asp:Label>
    <br />
    <asp:TextBox ID="TextBox1" runat="server" Height="30px" Width="210px"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="tai xuong bai nhac" />
</p>
    <p>
        <asp:GridView ID="GridView1" runat="server" style="margin-left: 262px" Width="808px">
        </asp:GridView>
</p>
<p>
    &nbsp;</p>
<p>
    <asp:TextBox ID="txtMessage" runat="server" Visible="False">banquyenkhanh</asp:TextBox>
</p>
</asp:Content>

