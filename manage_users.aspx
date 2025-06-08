<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="manage_users.aspx.cs" EnableEventValidation="false" Inherits="manage_users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .hiddencol{
            display: none;
        }
          .head{
          color:black;
          background-color:cornflowerblue;
          background:cornflowerblue;
        
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
  
    <table > <tr>
            <td colspan="2" align="left" style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #808080">
                <asp:Label ID="Label6" runat="server" CssClass="auto-style6" Text="Manage Users" style=" font-size: xx-large;color:steelblue;font-weight:bold" Font-Names="Century Schoolbook" Font-Bold="True"></asp:Label>
            </td>
<%--          <td>  <asp:ImageButton ID="ImageButton3" OnClick="ImageButton3_Click1" ButtonType="Button"   ImageUrl="~/images/addrow.png" runat="server"  Style="border-radius:50%; width:37px; height:34px;margin-left:118px"/></td>--%>
        </tr></table><br/>
     <asp:GridView ID="GridView2" HeaderStyle-CssClass="head"   CssClass="table table-bordered" OnRowDataBound="GridView2_RowDataBound" OnRowCommand="GridView2_RowCommand" runat="server" AutoGenerateColumns="False"
                        CellPadding="4" BackColor="White" Width="90%" GridLines="Horizontal" >
             <Columns>
                            <asp:BoundField DataField="uid" HeaderText=" id" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" ItemStyle-HorizontalAlign="Center"/> 
                 <asp:BoundField DataField="name" HeaderText="User Name" ItemStyle-HorizontalAlign="Center" /> 
                        <asp:BoundField DataField="address" HeaderText="Address" ItemStyle-HorizontalAlign="Center" />  
                
                 <asp:BoundField DataField="address"  HeaderText="Address" ItemStyle-HorizontalAlign="Center" />  
                        <asp:BoundField DataField="contact" HeaderText="Contact" ItemStyle-HorizontalAlign="Center" />  
                        <asp:BoundField DataField="emailid" HeaderText="Email ID" ItemStyle-HorizontalAlign="Center" />  
              <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Eval("uid") %>'  ImageUrl="~/images/editblue.png" OnClick="ImageButton1_Click" runat="server"  Style="border-radius:50%; width:37px; height:34px;"/>
                                    </ItemTemplate>
                          
                            </asp:TemplateField>    
                   <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton2" CommandArgument='<%#Eval("uid") %>'  ImageUrl="~/images/viewdata.png" OnClick="ImageButton2_Click1" runat="server"  Style="border-radius:50%; width:37px; height:34px;"/>
                                    </ItemTemplate>
                          
                            </asp:TemplateField>    
                        <asp:TemplateField>
                                <ItemTemplate>
                                          <asp:ImageButton ID="ImageButton3" OnClick="ImageButton3_Click" ButtonType="Button"  CommandName="Delete" CommandArgument='<%#Eval("uid") %>'  ImageUrl="~/images/delete.png" runat="server"  Style="border-radius:50%; width:37px; height:34px;"/>
                                    </ItemTemplate>
                          
                            </asp:TemplateField>   
          
                       </Columns>  
                </asp:GridView>
</asp:Content>




