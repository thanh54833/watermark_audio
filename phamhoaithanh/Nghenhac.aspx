<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Nghenhac.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <p>
    <asp:Label ID="Label1" runat="server" Text="nhap ma bai nhac de nghe"></asp:Label>
    <br />
    <asp:TextBox ID="TextBox1" runat="server" Height="30px" Width="210px"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Nghe bai nhac" />
</p>
    <div class="play_">
    <div class="left_play">
    <div id="Play__" runat="server" >
        <p>
            &nbsp;</p>
    <p>
        <asp:GridView ID="GridView1" runat="server" style="margin-left: 262px" Width="808px">
        </asp:GridView>
</p>
<p>
    &nbsp;</p>
        </div>
    <div class="menu_play"><p></p>
</asp:Content>

