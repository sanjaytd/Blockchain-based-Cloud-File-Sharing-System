<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Rejected.aspx.cs" Inherits="Rejected" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
   
 <div  style="background-color:white;border-radius:50px;align-content: center;width:70%;align-self:center;"> <br/><br/> <asp:ImageButton ID="Button1" runat="server" OnClick="Button1_Click1" ImageUrl="~/images/back.png" Width="3%" 
        style=" border-radius:12px;margin-left:-174px;position:absolute;" />  <asp:Label ID="Label2" runat="server" Font-Bold="False" 
        style="font-family: Calibri; font-size: 32pt" Text="Rejected Projects"></asp:Label>
     <br/><br/>    <br/><br/>
   <asp:GridView ID="GridView1" HeaderStyle-CssClass="head"   CssClass="table table-bordered"  runat="server" AutoGenerateColumns="False"
                        CellPadding="4" BackColor="White" Width="90%" GridLines="Horizontal"  >   <Columns>
                            <asp:BoundField DataField="pid" HeaderText="Project id" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" ItemStyle-HorizontalAlign="Center"> 
<HeaderStyle CssClass="hiddencol"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" CssClass="hiddencol"></ItemStyle>
                            </asp:BoundField>
                 <asp:BoundField DataField="category" HeaderText="Category"  ItemStyle-HorizontalAlign="Center" >  
                        
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                        
                      <asp:BoundField DataField="title" HeaderText="Project Title" ItemStyle-HorizontalAlign="Center" > 
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                         <asp:BoundField DataField="description" HeaderText="Description" ItemStyle-HorizontalAlign="Center" >  
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                        <asp:BoundField DataField="companyname" HeaderText="Company Name" ItemStyle-HorizontalAlign="Center" >  
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                         <asp:BoundField DataField="com_contact" HeaderText="Company Contact" ItemStyle-HorizontalAlign="Center" >  
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                       <asp:TemplateField ItemStyle-Width="100px">
                                <ItemTemplate  >
                                    <asp:ImageButton ID="Button3" CommandArgument='<%#Eval("pid") %>' OnClick="Button3_Click" ImageUrl="~/Images/approve1.jpg"  runat="server"   style=" background-color:forestgreen;color:white;font-weight:bold;width:100%"/>
                               
                                    </ItemTemplate>
                            
                            </asp:TemplateField>    
                            
                   
          
                       </Columns>  
                  <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
        </asp:GridView>    <br/><br/>
  </div>
</asp:Content>
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