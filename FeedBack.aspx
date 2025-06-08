<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FeedBack.aspx.cs" Inherits="FeedBack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <p>
        <br />
    <table width="60%">
        <tr>
            <td colspan="2" align="left" style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #808080">
                <asp:Label ID="Label6" runat="server" CssClass="auto-style6" Text="FeedBack" style="font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; font-size: xx-large;color:steelblue"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">

                &nbsp;&nbsp;</td>
        </tr>
       <tr>
            <td width="30%" align="right"><asp:Label ID="Label3" runat="server" CssClass="auto-style2" Text="Your FeedBack " style="font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; font-size: x-large"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td align="center" style="border-left-style: solid; border-left-width: 1px; border-left-color: #808080;" width="70%">
                <asp:TextBox ID="TextBox1" runat="server" RequiRed="" CssClass="auto-style4" Height="35px" TextMode="MultiLine" Placeholder="Enter Some FeedBack.... " Width="80%" style="height: 146px; width: 448px; font-size: large;resize:vertical"></asp:TextBox>
            </td>
         </tr>
            <tr>
            <td colspan="2">

                &nbsp;&nbsp;</td>
                    <tr>
            <td colspan="2">

                &nbsp;&nbsp;</td>
        </tr>
        </tr>
          <tr>
            <td width="30%" align="center" colspan="2">
                <asp:Button ID="Button1" runat="server" style="width: 160px; height: 42px;border-radius: 16px;  background-color: cornflowerblue; color: black;font-weight: bold;border-color: #faf7f0;" OnClick="Button1_Click" CssClass="auto-style12" Text="Submit"  />
            </td>
        </tr>
          <tr>
            <td>
                <br />
            </td>
            <td align="center">
                    &nbsp;</td>
        </tr>
        </table>
    </p>
</asp:Content>


