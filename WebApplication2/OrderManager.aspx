<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="OrderManager.aspx.cs" Inherits="WebApplication2.OrderManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .btn{
            background-color:#D6D385;
            width:80px;
            height:40px;
            border-radius:10px;
        }
        .btn:hover{
            background-color:#9c9a65;
            border-radius:10px;
        }
        .btn1{
            background-color:#D6D385;
            width:40px;
            height:30px;
            border-radius:10px;
        }
        .btn1:hover{
            background-color:#9c9a65;
            border-radius:10px;
        }
        .gridviewTitle{
            background:linear-gradient(to right,rgba(155,183,234,1),rgba(169,193,237,0.5),rgba(227,197,235,1));
        }
        .gridview{
            margin:auto;
            border:3px solid gray;
            
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;background-color:#5D7B9D">
        <tr>
            <td ><div style="text-align:right;font-weight:bold">日期：</div></td>
            <td>
                <asp:DropDownList ID="ddlTime" runat="server">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>今日内</asp:ListItem>
                    <asp:ListItem>一周内</asp:ListItem>
                    <asp:ListItem>一月内</asp:ListItem>
                    <asp:ListItem>半年内</asp:ListItem>
            </asp:DropDownList>
            </td>
            <td ><div style="text-align:right;font-weight:bold">商品：</div></td>
            <td>
                <asp:DropDownList ID="ddlGood" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="BtnDisplay" runat="server" Text="查询" CssClass="btn" BorderWidth="2px" Font-Bold="True" OnClick="BtnDisplay_Click" />
            </td>
        </tr>
    </table>
    <asp:gridview id="GridView1" runat="server" autogeneratecolumns="False" width="100%" onpageindexchanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound" CssClass="gridview"  HeaderStyle-BackColor="#C4AA7B">
        <AlternatingRowStyle CssClass="gridviewTitle" BackColor="#86728D" />
        <Columns>
            <asp:TemplateField HeaderText="订单编号" ItemStyle-Width="15%">
                <ItemTemplate>
                    <asp:Label ID="LabNo" runat="server" Text='<%# Eval("bookId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="用户名">
                <ItemTemplate>
                    <asp:Label ID="LabUserName" runat="server" Text='<%# Eval("userId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="商品" ItemStyle-Width="15%">
                <ItemTemplate>
                    <asp:Label ID="LabGood" runat="server" Text='<%# Eval("goodName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="数量">
                <ItemTemplate>
                    <asp:Label ID="LabCount" runat="server" Text='<%# Eval("count") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="总价">
                <ItemTemplate>
                    <asp:Label ID="LabPrice" runat="server" Text='<%# Eval("price") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="地址">
                <ItemTemplate>
                    <asp:Label ID="LabAddress" runat="server" Text='<%# Eval("address") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="下单时间">
                <ItemTemplate>
                    <asp:Label ID="LabTime" runat="server" Text='<%# Eval("time") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="操作" ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="BtnConfirm" runat="server" Text="发货" OnClick="BtnConfirm_Click" CssClass="btn1" />
                    <asp:Button ID="BtnRefund" runat="server" Text="退款" OnClick="BtnRefund_Click" CssClass="btn1"/>
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
     
    </asp:gridview>

</asp:Content>
