<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="body" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <p>
        <br />
         <asp:Panel id="panel1" runat="server">
    <table width="60%">
        <tr>
            <td colspan="2" align="left" style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #808080">
                 <asp:Button ID="Button2" Visible="false" runat="server" style="width: 74px;height: 42px;border-radius: 16px;background-color:green;color: white;font-weight: bold;border-color: #faf7f0;" CssClass="auto-style12" Text="Back" OnClick="Button2_Click" />
           <br/><br/>
                <asp:Label ID="Label6" runat="server" CssClass="auto-style6" Text="Register" style="font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; font-size: xx-large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">

                &nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">

                    &nbsp;</td>
        </tr>
     <tr>
            <td width="30%" align="right"><asp:Label ID="Label3" runat="server" CssClass="auto-style2" Text="User Id" style="font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; font-size: x-large"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td align="center" style="border-left-style: solid; border-left-width: 1px; border-left-color: #808080;" width="70%">
                <asp:TextBox ID="TextBoxid" runat="server" RequiRed="" CssClass="auto-style4" Height="35px" Placeholder=" Enter id" Width="80%" style="font-size: large"></asp:TextBox>
            </td>
         </tr>
        <tr>
            <td colspan="2">
                <br />
            </td>
        </tr>
         <tr>
            <td width="30%" align="right"><asp:Label ID="Label2" runat="server" CssClass="auto-style2" Text="Name" style="font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; font-size: x-large"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td align="center" style="border-left-style: solid; border-left-width: 1px; border-left-color: #808080;" width="70%">
                <asp:TextBox ID="TextBoxname" runat="server" RequiRed="" CssClass="auto-style4" Height="35px" Placeholder=" Enter Your Name" Width="80%" style="font-size: large"></asp:TextBox>
            </td>
         </tr>
        <tr>
            <td colspan="2">
                <br />
            </td>
        </tr>
         <tr>
            <td width="30%" align="right"><asp:Label ID="Label4" runat="server" CssClass="auto-style2" Text="Address" style="font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; font-size: x-large"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td align="center" style="border-left-style: solid; border-left-width: 1px; border-left-color: #808080;" width="70%">
                <asp:TextBox ID="TextBoxadd" runat="server" RequiRed="" CssClass="auto-style4" Height="35px" Placeholder=" Enter Your  Address" Width="80%" style="font-size: large"></asp:TextBox>
            </td>
         </tr>
             <tr>
            <td colspan="2">
                <br />
            </td>
        </tr>
    
          <tr>
            <td width="30%" align="right"><asp:Label ID="Label1" runat="server" CssClass="auto-style2" Text="Contact No." style="font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; font-size: x-large"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td align="center" style="border-left-style: solid; border-left-width: 1px; border-left-color: #808080;">
                <asp:TextBox ID="TextBoxcno" runat="server" RequiRed="" CssClass="auto-style4" Height="35px" Placeholder=" Enter Your Contact Number" Width="80%" style="font-size: large"></asp:TextBox>
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
            <td width="30%" align="right"><asp:Label ID="Label5" runat="server" CssClass="auto-style2" Text="Email Id" style="font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; font-size: x-large"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td align="center" style="border-left-style: solid; border-left-width: 1px; border-left-color: #808080;">
                <asp:TextBox ID="TextBoxemail" runat="server" RequiRed="" CssClass="auto-style4" Height="35px" Placeholder=" Enter Your Emailid" Width="80%" style="font-size: large"></asp:TextBox>
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
            <td width="30%" align="right"><asp:Label ID="Label7" runat="server" CssClass="auto-style2" Text="Password" style="font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; font-size: x-large"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td align="center" style="border-left-style: solid; border-left-width: 1px; border-left-color: #808080;">
                <asp:TextBox ID="TextBoxpass"  runat="server" RequiRed="" CssClass="auto-style4" Height="35px" Placeholder=" Enter Password" Width="80%" style="font-size: large"></asp:TextBox>
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
                <asp:Button ID="Button1" runat="server" style="width: 160px; height: 42px;border-radius: 16px;  background-color:cornflowerblue; color: black;font-weight: bold;border-color: #faf7f0;" CssClass="auto-style12" Text="Add User" OnClick="Button1_Click"  />
           
                </td>
                
        </tr>
        </table></asp:Panel>
         
    </p>
</asp:Content>