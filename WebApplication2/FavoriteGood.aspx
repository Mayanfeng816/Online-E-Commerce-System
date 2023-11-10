<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FavoriteGood.aspx.cs" Inherits="WebApplication2.FavoriteGood" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style>
        .table
         {
	       width:100%; 
           border:none; 
           background-image:linear-gradient(to right,rgba(169,193,237,1),rgba(169,193,237,0.5),rgba(227,197,235,1)),url('img/7777.jpg');
         }
        .gridviewTitle{
            background:linear-gradient(to right,rgba(155,183,234,1),rgba(169,193,237,0.5),rgba(227,197,235,1));
        }
        .btnsearchgood {
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
        .btnsearchgood:hover{
             background-color:rgb(155,183,234);
             background-position-x:-280px;
         }
        .btngood {
             width:170px;
             height:30px;
             margin:3px auto 4px auto;
             border:none;
             background-color:rgba(74,124,217,1);
             color:#fff;
             font-weight:bold;
             cursor:pointer;
             transition:0.5s;/*动画过渡*/
             border-radius:20px;
             box-shadow: 0 5px 25px rgba(140,172,232,1),0 0 0 10px rgba(140,172,232,0.1);
         }
         .btngood:hover{
             background: linear-gradient(-225deg,rgb(190,237,235) 0%, #C5C1FF 56%, #FFBAC3 100%);
             background-position-x:-170px;
         }
        .btnshop {
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
        .btnshop:hover{
             background: linear-gradient(-225deg,rgb(190,237,235) 0%, #C5C1FF 56%, #FFBAC3 100%);
             background-position-x:-170px;
         }
        .btncart {
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
        .btncart:hover{
             background: linear-gradient(-225deg,rgb(190,237,235) 0%, #C5C1FF 56%, #FFBAC3 100%);
             background-position-x:-90px;
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
         .picture{
            border-radius:10px;
        }
         
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table">
        <tr>
            <td>
                <asp:Button ID="btnFavoriteGood" runat="server" Text="宝贝收藏" CssClass="btngood" OnClick="btnFavoriteGood_Click"/>
                <asp:Button ID="btnFavoriteShop" runat="server" Text="店铺收藏" CssClass="btnshop" OnClick="btnFavoriteShop_Click"/>
            </td>
            <td >
                <div class="shell">
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="textbox" ></asp:TextBox>&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="搜索" Width="68px" CssClass="btnsearchgood" OnClick="btnSearch_Click"/>
                </div>
            </td>
        </tr>
    </table>

    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" ShowHeader="False"  AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="5" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDeleting="GridView1_RowDeleting" Width="100%">
        <AlternatingRowStyle CssClass="gridviewTitle"/>
        <Columns>
            <asp:TemplateField HeaderText="商品ID" >
                <ItemTemplate>
                    <asp:Label ID="labgoodId" runat="server" Text='<%# Bind("goodId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="照片">
                <ItemTemplate>
                    <asp:Image ID="imgphoto" runat="server" Height="100px" Width="100px" CssClass="picture"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="商品名称">
                <ItemTemplate>
                    <asp:Label ID="labgoodName" runat="server" Text='<%# Bind("goodName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="品牌">
                <ItemTemplate>
                    <asp:Label ID="labshopName" runat="server" Text='<%# Bind("shopName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="价格">
                <ItemTemplate>
                    <asp:Label ID="labprice" runat="server" Text='<%# Bind("price") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="类别">
                <ItemTemplate>
                    <asp:Label ID="labkind" runat="server" Text='<%# Bind("kind") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="加购物车" ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btnaddCart" runat="server" Text="加入购物车" CssClass="btncart" OnClick="btnaddCart_Click"/>
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
