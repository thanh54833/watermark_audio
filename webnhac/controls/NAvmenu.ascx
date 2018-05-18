<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NAvmenu.ascx.cs" Inherits="controls_WebUserControl" %>
<style type="text/css">
    .style1
    {
        width: 100%;
        height: 127px;
    }
</style>

<table cellpadding="0" cellspacing="0" class="style1">
    <tr>
        <td style="background-image: none; text-align: center; background-color: #6978b8; height: 40px;">
&nbsp; &nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/login.aspx" Font-Bold="True" Height="40px">Đăng nhập   </asp:HyperLink>
            &nbsp; &nbsp;<asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/profile.aspx" Font-Bold="True" Height="40px">Đăng kí</asp:HyperLink>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Trangtainhac.aspx" Font-Bold="True" Height="40px">Tải nhạc</asp:HyperLink>
&nbsp; &nbsp;
            &nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Nghenhac.aspx" Font-Bold="True" Height="40px">Nghe nhạc</asp:HyperLink>
        </td>
    </tr>
</table>

