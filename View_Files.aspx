<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="View_Files.aspx.cs" Inherits="View_Files" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .hiddencol {
            display: none;
        }

        .head {
            color: black;
            background-color: cornflowerblue;
            ba
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <table>
        <tr>
            <td colspan="2" align="left" style="">
                <asp:Label ID="Label6" runat="server" CssClass="auto-style6" Text="Manage Files" Style="font-size: xx-large; color: steelblue; font-weight: bold; margin-left: 346px" Font-Names="Century Schoolbook" Font-Bold="True"></asp:Label>
            </td>
            <td>
                <asp:ImageButton ID="ImageButton3" OnClick="ImageButton3_Click1" ButtonType="Button" ImageUrl="~/images/addrow.jfif" runat="server" Style="border-radius: 50%; width: 8%; margin-left: 312px" />
            </td>

        </tr>
    </table>
    <br />
    <div style="width: 100%; text-align: center">
        <br />
        <br />

        <asp:Label ID="Label1" runat="server" Text="File Name / File Category :"></asp:Label>
        <asp:TextBox ID="TextBox1" CssClass="auto-style4" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;


    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Style="width: 150px; background-color: cornflowerblue; color: black; border-radius: 32px; height: 30px; font-weight: bold;" Text="Search" />
        <br />
    </div>
    <br />
    <br />
    <asp:GridView ID="GridView2" HeaderStyle-CssClass="head" CssClass="table table-bordered" OnRowDataBound="GridView2_RowDataBound" OnRowCommand="GridView2_RowCommand" runat="server" AutoGenerateColumns="False"
        CellPadding="4" BackColor="White" Width="90%" GridLines="Horizontal">
        <Columns>
            <asp:BoundField DataField="fid" HeaderText=" fid" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" ItemStyle-HorizontalAlign="Center" />

            <%--<asp:BoundField DataField="path" HeaderText="File Name" ItemStyle-HorizontalAlign="Center" />--%>
            <asp:BoundField DataField="filename" HeaderText="File Name" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="description" HeaderText="Description" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="type" HeaderText="Type" ItemStyle-HorizontalAlign="Center" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Eval("fid") %>' ImageUrl="~/images/editblue.png" OnClick="ImageButton1_Click" runat="server" Style="border-radius: 50%; width: 37px; height: 34px;" />
                </ItemTemplate>

            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButton2" CommandArgument='<%#Eval("fid") %>' ImageUrl="~/images/viewdata.png" OnClick="ImageButton2_Click1" runat="server" Style="border-radius: 50%; width: 37px; height: 34px;" />
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButton3" OnClick="ImageButton3_Click" ButtonType="Button" CommandName="Delete" CommandArgument='<%#Eval("fid") %>' ImageUrl="~/images/delete.png" runat="server" Style="border-radius: 50%; width: 37px; height: 34px;" />
                </ItemTemplate>

            </asp:TemplateField>
            <asp:TemplateField HeaderText="Allow">
                <ItemTemplate>
                    <asp:Button ID="lnkDownload" runat="server" Text="Allow Access" Style="width: 150px; background-color: green; color: white; border-radius: 32px; height: 30px;" OnClick="lnkDownload_Click"
                        CommandArgument='<%# Eval("fid")%>'></asp:Button>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Revoke">
                <ItemTemplate>
                    <asp:Button ID="lnkrevoke" runat="server" Text="Revoke Access" Style="width: 150px; background-color: red; color: white; border-radius: 32px; height: 30px;" OnClick="lnkrevoke_Click"
                        CommandArgument='<%#Eval("fid")%>'></asp:Button>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Download">
                <ItemTemplate>
                    <asp:Button ID="lnkDownload1" runat="server" Text="Download" Style="width: 150px; background-color: cornflowerblue; color: white; border-radius: 32px; height: 30px;" OnClick="DownloadFile"
                        CommandArgument='<%# Eval("path")%>'></asp:Button>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="isManupilated" HeaderText="IsManupilated" ItemStyle-HorizontalAlign="Center">
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:HiddenField ID="HiddenField1" runat="server" />
</asp:Content>

