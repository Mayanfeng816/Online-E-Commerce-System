<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FavoriteShop.aspx.cs" Inherits="WebApplication2.FavoriteShop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .gridviewTitle{
            background:linear-gradient(to right,rgba(155,183,234,1),rgba(169,193,237,0.5),rgba(227,197,235,1));
        }
        .table
         {
	       width:100%; 
           border:none; 
           background-image:linear-gradient(to right,rgba(169,193,237,1),rgba(169,193,237,0.5),rgba(227,197,235,1)),url('img/7777.jpg');
         }
        .btnsearchshop {
              width:170px;
             height:30px;
             margin:3px auto 4px auto;
             border:none;
             background-color:rgb(183,156,237);
             color:#fff;
             font-weight:bold;
             cursor:pointer;
             transition:0.5s;/*动画过渡*/
             border-radius:20px;
             box-shadow: 0 5px 25px rgba(217,176,227,1),0 0 0 10px rgba(217,176,227,0.1);
         }
        .btnsearchshop:hover{
             background-color:rgb(155,183,234);
             background-position-x:-280px;
         }
        .btnblue {
             width:170px;
             height:30px;
             margin:3px auto 4px auto;
             border:none;
             background-color:rgba(131,165,228,1);
             color:#fff;
             font-weight:bold;
             cursor:pointer;
             transition:0.5s;/*动画过渡*/
             border-radius:20px;
             box-shadow: 0 5px 25px rgba(140,172,232,1),0 0 0 10px rgba(140,172,232,0.1);
         }
        .btnblue:hover{
             background: linear-gradient(-225deg,rgb(190,237,235) 0%, #C5C1FF 56%, #FFBAC3 100%);
             background-position-x:-170px;
         }
        .btnblueselect {
             width:170px;
             height:30px;
             margin:3px auto 4px auto;
             border:none;
             background-color:rgba(86,133,220,1);
             color:#fff;
             font-weight:bold;
             cursor:pointer;
             transition:0.5s;/*动画过渡*/
             border-radius:20px;
             box-shadow: 0 5px 25px rgba(140,172,232,1),0 0 0 10px rgba(140,172,232,0.1);
         }
         .btnblueselect:hover{
             background: linear-gradient(-225deg,rgb(190,237,235) 0%, #C5C1FF 56%, #FFBAC3 100%);
             background-position-x:-170px;
         }
         .btndelete {
             width:90px;
             height:30px;
             border:none;
             background-color:#a9c1ed;
             color:#fff;
             font-weight:bold;
             cursor:pointer;
             border-radius:5px;
             transition:0.5s;/*动画过渡*/
         }
        .btndelete:hover{
             background-image: linear-gradient(-225deg, #30cfd0 0%, #330867 100%);
             background-position-x:-90px;
         }
         .shell{
             padding:33px;
             background:linear-gradient(to right,rgba(169,193,237,0),rgba(227,197,235,0.1));
             border-radius:20px;
             text-align:right ;
         }
         .textbox{
             width:100px;
             height:30px;
             color:#000;
             font-weight:600;
             font:200 80px;
             border:solid;
             border-radius:20px;
             border-color:#fff;
             background-color:transparent;
             outline:none;
         }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table">
        <tr>
            <td>
                <asp:Button ID="btnFavoriteGood" runat="server" Text="宝贝收藏" CssClass="btnblue" OnClick="btnFavoriteGood_Click"/>
                <asp:Button ID="btnFavoriteShop" runat="server" Text="店铺收藏" CssClass="btnblueselect" OnClick="btnFavoriteShop_Click"/>
            </td>
            <td>
                <div class="shell">
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="textbox" ></asp:TextBox>&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="搜索" Width="68px" CssClass="btnsearchshop" OnClick="btnSearch_Click"/>
                </div>
            </td>
        </tr>
    </table>

    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" ShowHeader="False" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="10" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDeleting="GridView1_RowDeleting" Width="100%">
        <AlternatingRowStyle CssClass="gridviewTitle" />
        <Columns>
            <asp:TemplateField HeaderText="店铺名称">
                <ItemTemplate>
                    <asp:Label ID="labfavoriteShopName" runat="server" Text='<%# Bind("favoriteShopName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="删除" ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="移除收藏" CssClass="btndelete"></asp:Button>
                </ItemTemplate>
                <ControlStyle Font-Underline="False" />
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle CssClass="gridviewTitle" />
        <PagerStyle CssClass="gridviewTitle" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFFFF" ForeColor="#333333" HorizontalAlign="Center"/>
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
</asp:Content>
