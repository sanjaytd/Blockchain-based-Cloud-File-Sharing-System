<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Viewfeedback.aspx.cs" Inherits="Viewfeedback" %>

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
                <asp:Label ID="Label6" runat="server" CssClass="auto-style6" Text="View FeedBack" style=" font-size: xx-large;color:steelblue;font-weight:bold" Font-Names="Century Schoolbook" Font-Bold="True"></asp:Label>
            </td>
        </tr></table> <br />
 <br />
     <asp:GridView ID="GridView2" HeaderStyle-CssClass="head"   CssClass="table table-bordered"  runat="server" AutoGenerateColumns="False"
                        CellPadding="4" BackColor="White" Width="90%" GridLines="Horizontal" >
             <Columns>
                 <asp:BoundField DataField="fid" HeaderText=" id" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" ItemStyle-HorizontalAlign="Center"/> 
                      <asp:BoundField DataField="feedback" HeaderText="FeedBack" ItemStyle-HorizontalAlign="Center" />  
                 <asp:BoundField DataField="name"  HeaderText="User Name" ItemStyle-HorizontalAlign="Center" />  
                              <asp:BoundField DataField="datetime"  HeaderText="Date" ItemStyle-HorizontalAlign="Center" />  
                   
              
                       </Columns>  
                </asp:GridView>
    <asp:HiddenField ID="HiddenField1" runat="server" />
</asp:Content>

