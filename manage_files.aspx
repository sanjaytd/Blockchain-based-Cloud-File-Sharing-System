<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableEventValidation="false"  CodeFile="manage_files.aspx.cs" Inherits="manage_files" %>

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
                <asp:Label ID="Label6" runat="server" CssClass="auto-style6" Text="View Files" style=" font-size: xx-large;color:steelblue;font-weight:bold" Font-Names="Century Schoolbook" Font-Bold="True"></asp:Label>
            </td>
        </tr></table><br/><asp:Label ID="Label1" runat="server" Text="File Name / File Category :"></asp:Label>
    <asp:TextBox ID="TextBox1" CssClass="auto-style4" runat="server"></asp:TextBox>
&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click"  style="width:150px;background-color:green;color:white;border-radius:32px;height:30px;" Text="Search" />
    <br /></div><br/> <br />&nbsp;&nbsp;&nbsp;

     <asp:GridView ID="GridView2" HeaderStyle-CssClass="head"   CssClass="table table-bordered" OnRowDataBound="GridView2_RowDataBound" OnRowCommand="GridView2_RowCommand" runat="server" AutoGenerateColumns="False"
                        CellPadding="4" BackColor="White" Width="90%" GridLines="Horizontal" >
             <Columns>
                 <asp:BoundField DataField="fid" HeaderText=" fid" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" ItemStyle-HorizontalAlign="Center"/> 
                 
                           <asp:BoundField DataField="path" HeaderText="File Name" ItemStyle-HorizontalAlign="Center" /> 
                    <asp:BoundField DataField="description" HeaderText="Description" ItemStyle-HorizontalAlign="Center" /> 
                       <asp:BoundField DataField="type"  HeaderText="Type" ItemStyle-HorizontalAlign="Center" />  
                     <asp:BoundField DataField="size"  HeaderText="File Size" ItemStyle-HorizontalAlign="Center" />  
                 <%--  <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Eval("fid") %>'  ImageUrl="~/images/editblue.png" OnClick="ImageButton1_Click" runat="server"  Style="border-radius:50%; width:37px; height:34px;"/>
                                    </ItemTemplate>
                          
                            </asp:TemplateField>    
                   <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton2" CommandArgument='<%#Eval("fid") %>'  ImageUrl="~/images/viewdata.png" OnClick="ImageButton2_Click1" runat="server"  Style="border-radius:50%; width:37px; height:34px;"/>
                                    </ItemTemplate>
                        </asp:TemplateField>    
                         
                           
                        <asp:TemplateField>
                                <ItemTemplate>
                                          <asp:ImageButton ID="ImageButton3" OnClick="ImageButton3_Click" ButtonType="Button"  CommandName="Delete" CommandArgument='<%#Eval("fid") %>'  ImageUrl="~/images/delete.png" runat="server"  Style="border-radius:50%; width:37px; height:34px;"/>
                                    </ItemTemplate>
                          
                            </asp:TemplateField>  --%>
           
                  <asp:BoundField DataField="isManupilated"  HeaderText="IsManupilated" ItemStyle-HorizontalAlign="Center" >  
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                       </Columns>  
                </asp:GridView>
</asp:Content>


