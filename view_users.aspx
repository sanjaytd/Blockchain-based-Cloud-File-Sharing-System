<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="view_users.aspx.cs" Inherits="view_users" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <link href="style.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    .style1
    {
        font-family: Calibri;
        font-size: large;
    }
     .hiddencol{
            display:none
        }
        .head{
          color:white;
          background:#40B5AD;
        
        }
        .grid{
            overflow-y:scroll;
        }
</style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div  style="background-color:white;border-radius:50px;align-content: center;width:70%;align-self:center;"> <br/><br/>   
        <asp:Label ID="Label2" runat="server" Font-Bold="False"  style="font-family: Calibri; font-size: 32pt" Text="Users"/>
     <br/><br/>    <br/><br/>
   <asp:GridView ID="GridView1" HeaderStyle-CssClass="head"   CssClass="table table-bordered"  runat="server" AutoGenerateColumns="False"
                        CellPadding="4" BackColor="White" Width="90%" GridLines="Horizontal"  >   <Columns>
                            <asp:BoundField DataField="uid" HeaderText="User Id" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" ItemStyle-HorizontalAlign="Center"> 
<HeaderStyle CssClass="hiddencol"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" CssClass="hiddencol"></ItemStyle>
                            </asp:BoundField>
                 <asp:BoundField DataField="uname" HeaderText="User Name"  ItemStyle-HorizontalAlign="Center" >  
                        
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                        
                      <asp:BoundField DataField="Address" HeaderText="Address" ItemStyle-HorizontalAlign="Center" > 
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                         <asp:BoundField DataField="emailid" HeaderText="Email Id" ItemStyle-HorizontalAlign="Center" >  
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                        <asp:BoundField DataField="contact" HeaderText="Contact No." ItemStyle-HorizontalAlign="Center" >  
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                        
                       </Columns>  
                  <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
        </asp:GridView>    <br/><br/>
  </div>
</asp:Content>

