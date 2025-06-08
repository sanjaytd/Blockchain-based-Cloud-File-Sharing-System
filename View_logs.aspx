
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="View_logs.aspx.cs" Inherits="View_logs" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .hiddencol{
            display: none;
        }
          .head{
          color:black;
          background-color:cornflowerblue;
        
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table > <tr>
            <td colspan="2" align="left" style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #808080">
                <asp:Label ID="Label6" runat="server" CssClass="auto-style6" Text="Log History" style=" font-size: xx-large;color:steelblue;font-weight:bold" Font-Names="Century Schoolbook" Font-Bold="True"></asp:Label>
            </td>
        </tr></table> <br />
    <div style="width:100%; text-align:center">
    <br />
         <asp:Label ID="Label2" runat="server" Text="From :"></asp:Label>
    <asp:TextBox ID="TextBox2" CssClass="auto-style4" type="date" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;

         <asp:Label ID="Label3" runat="server" Text="To :"></asp:Label>
    <asp:TextBox ID="TextBox3" CssClass="auto-style4" type="date" runat="server"></asp:TextBox>
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<asp:Label ID="Label1" runat="server" Text="File Name / File Category :"></asp:Label>
    <asp:TextBox ID="TextBox1" CssClass="auto-style4" runat="server"></asp:TextBox>
&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click"  style="width:150px;background-color:green;color:white;border-radius:32px;height:30px;" Text="Search" />
    <br /></div><br/> <br />&nbsp;&nbsp;&nbsp;


     <asp:GridView ID="GridView2" HeaderStyle-CssClass="head"   CssClass="table table-bordered"  runat="server" AutoGenerateColumns="False"
                        CellPadding="4" BackColor="White" Width="90%" GridLines="Horizontal" >
             <Columns>
                 <asp:BoundField DataField="lid" HeaderText=" id" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" ItemStyle-HorizontalAlign="Center"/> 
                      <asp:BoundField DataField="name" HeaderText="User Name" ItemStyle-HorizontalAlign="Center" />  
                 <asp:BoundField DataField="fileacess"  HeaderText="File Name" ItemStyle-HorizontalAlign="Center" />  
                           <asp:BoundField DataField="title" HeaderText="Action" ItemStyle-HorizontalAlign="Center" /> 
                        <asp:BoundField DataField="date" HeaderText="Date" ItemStyle-HorizontalAlign="Center" />  
                           <asp:BoundField DataField="time" HeaderText="Time" ItemStyle-HorizontalAlign="Center" /> 
                   
              
                       </Columns>  
                </asp:GridView>
    <asp:HiddenField ID="HiddenField1" runat="server" />
</asp:Content>