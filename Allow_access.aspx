<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Allow_access.aspx.cs" Inherits="Allow_access" %>

<asp:Content ID="body" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
        <asp:Panel ID="panel1" runat="server">
            <table width="60%">
                <tr>
                    <td colspan="2" align="left" style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #808080">
                         <asp:Button ID="Button2" runat="server" style="width: 74px;height: 42px;border-radius: 16px;background-color:green;color: white;font-weight: bold;border-color: #faf7f0;" CssClass="auto-style12" Text="Back" OnClick="Button2_Click" />
           <br/><br/>
                        <asp:Label ID="Label6" runat="server" CssClass="auto-style6" Text="Grant Access" Style="font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; font-size: xx-large"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;&nbsp;</td>
                </tr>
                <tr>
                    <td width="30%" align="right">
                        <asp:Label ID="Label1" runat="server" CssClass="auto-style2" Text=" File Name " Style="font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; font-size: x-large"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td align="center" style="border-left-style: solid; border-left-width: 1px; border-left-color: #808080;">


                        <asp:TextBox ID="TextBox2" Enabled="false" runat="server" RequiRed="" CssClass="auto-style4" Height="35px" Placeholder=" Enter file description" Width="80%" Style="font-size: large"></asp:TextBox>

                    </td>
                </tr>
          
                <tr>
                    <td colspan="2">
                        <br />
                    </td>
                </tr>
           
                
                <tr>
            <td width="30%" align="right"><asp:Label ID="Label5" runat="server" CssClass="auto-style2" Text="Select User" style="font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; font-size: x-large"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td align="center"   style="border-left-style: solid; border-left-width: 1px; border-left-color: #808080;">
               
           
            <asp:DropDownList ID="DropDownList1"  runat="server" RequiRed="" CssClass="auto-style4" Height="35px" Placeholder=" Enter Password" Width="80%" style="font-size: large">
   
  </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
            <td align="center">
                    &nbsp;</td>
        </tr>
  <tr>
            <td width="30%" align="center" colspan="2">
                <asp:Button ID="Button1" runat="server" style="width: 160px; height: 42px;border-radius: 16px;  background-color:cornflowerblue; color: black;font-weight: bold;border-color: #faf7f0;" CssClass="auto-style12" Text="Allow" OnClick="Button1_Click"  />
           
                </td>
                
        </tr>

            </table>
        </asp:Panel>

    </p>
</asp:Content>


