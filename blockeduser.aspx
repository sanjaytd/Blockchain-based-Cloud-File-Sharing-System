<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="blockeduser.aspx.cs" Inherits="blockeduser" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <meta name="viewport" content="width=device-width, initial-scale=1.0" />  
    <link href="Content/bootstrap.cosmo.min.css" rel="stylesheet" />  
    <link href="Content/StyleSheet.css" rel="stylesheet" />  
    <style type="text/css">
    .style1
    {
        font-size: x-large;
        text-decoration: underline;
            color: #FFFFFF;
            font-family: Candara;
            background-color: #000000;
        }
        </style>
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" OnRowCommand="GridView1_RowCommand" Font-Names="Century Gothic" style="font-size: large">
        <Columns>
            <asp:BoundField DataField="uid" HeaderText="id" SortExpression="id" />
            <asp:BoundField DataField="fname" HeaderText="name" SortExpression="name" />
            <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
            <asp:BoundField DataField="contact" HeaderText="contact" SortExpression="contact" />
           
            <asp:TemplateField HeaderText="Unblock" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="unblock" CommandArgument='<%#Eval("uid") %>'  Text="UNBLOCK"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#487575" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#275353" />
    </asp:GridView>
    <br />

    <asp:Label ID="Label1" runat="server" Text="no data" CssClass="style1" Visible="true"></asp:Label>
    </asp:Content>
