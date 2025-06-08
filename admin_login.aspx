<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="admin_login.aspx.cs" Inherits="_Default" %>


<asp:Content ID="body" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <img src="images/adminbanner.png" style="width: 100%; height: 580px; margin-top: -217px">
    <center>
        <div style="border-radius: 12%; margin-top: -441px;">
            <table>
                <tr>
                    <td colspan="2" align="center" style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #808080;margin-left:40px">
                        <asp:Label ID="Label6" runat="server" CssClass="auto-style6" Text="Admin Login" Style="font-size: xx-large; color: white; font-weight: bold" Font-Names="Century Schoolbook" Font-Bold="True"></asp:Label>
                    </td>
                </tr> <tr> </tr><tr> </tr><tr> </tr><tr> </tr><tr> </tr><tr> </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="User Name" Style="color: white; font-weight: bold; font-size: x-large"></asp:Label></td>

                    <td style="padding-left:25px">
                        <asp:TextBox ID="TextBox1" CssClass="auto-style4" runat="server" Style="width: 255px; border-radius: 12px; height: 22px; padding: 7px;"></asp:TextBox></td>
                </tr><tr> </tr><tr> </tr><tr> </tr><tr> </tr><tr> </tr><tr> </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Password" Style="color: white; font-weight: bold; font-size: x-large"></asp:Label></td>

                    <td style="padding-left:25px">
                        <asp:TextBox ID="TextBox2" CssClass="auto-style4 " TextMode="Password" runat="server" Style="width: 255px; border-radius: 12px; height: 22px; padding: 7px;"></asp:TextBox></td>
                </tr><tr> </tr><tr> </tr><tr> </tr><tr> </tr><tr> </tr><tr> </tr>
                <tr>
                    <td></td>
                    <td style="padding-left:90px">
                        <asp:Button ID="Button1" CssClass="btn btn-success" runat="server" Style="width: 95px; height: 42px; border-radius: 16px; background-color: darkblue; color: white; font-weight: bold; border-color: #faf7f0;" OnClick="Button1_Click" Text="Login" />
                    </td>
                </tr>

            </table>
            <br />
        </div>
    </center>
</asp:Content>
