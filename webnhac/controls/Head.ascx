<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Head.ascx.cs" Inherits="controls_WebUserControl" %>
<style type="text/css">
    .style1
    {
        width: 100%;
        height: 80px;
    }
    .style2
    {
        text-align: center;
        font-size: medium;
    }
    .auto-style1 {
        text-align: center;
        font-size: xx-large;
    }
</style>

<table cellpadding="0" cellspacing="0" class="style1">
    <tr>
        <td class="auto-style1" style="background-color: #b6ff00">
            <strong>WELCOME TO OUR WEBSITE </strong></td>
    </tr>
    <tr>
        <td class="style2" style="background-color: #b6ff00; height: 30px;">
            <asp:Label ID="Label1" runat="server" Text="hi"></asp:Label>
            &nbsp;<asp:Label ID="Label2" runat="server" style="text-align: right" Text="Khách"></asp:Label>
        </td>
    </tr>
</table>

