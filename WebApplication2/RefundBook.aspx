<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RefundBook.aspx.cs" Inherits="WebApplication2.RefundBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdn.staticfile.org/font-awesome/4.7.0/css/font-awesome.css"> 
    <style>
        .Menu3{
            font-weight:normal;
        }
        *{
            outline:none;
            padding:0;
            margin:0;
            text-decoration:none;
        }
        .body{
            display:flex;
            justify-content:center;
            align-items:center;
            height:100vh;
        }
        .shell {
            margin: 0px 1000px 0px;
            width: 15%;
            padding: 5px;
            border-radius: 20px;
        }

        .shell input {
            width: 70%;
            height: 30px;
            color: #fff;
            border: 0;
        } 
        .shell input::placeholder {
            color: black;
        } 
        .shell a {
            display: flex;
            font-size: 12px;
            position: absolute;
            right: 60px;
            top: 10px;
            color: white;
            width: 20px;
            height: 30px;
        }

        .shell a .fa {
            margin: 10px 28px;
            transition: .3s;
        }

        .shell a .fa-search {
            transform: translateX(-80px);
            opacity: 1;
        }

        .shell a:hover .fa-search {
            transform: translateX(0);
            opacity: 0;
        }

        .shell a:hover::before{
            top: -115px;
            opacity: 1;
        }
        .auto-style1 {
            height: 30px;
            width: 20%;
        }
        .auto-style2 {
            text-align:right;
            background-image:url('img/7777.jpg');
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Menu ID="Menu3" runat="server" Orientation="Horizontal" ShowLines="True" Height="45px" Width="100%" BackColor="#265890" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="1.5em" ForeColor="#FFFFFF" >
                    <Items>
                        <asp:MenuItem Text=" &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Value="所有订单" NavigateUrl="AllBook.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="所有订单 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Value="所有订单" NavigateUrl="AllBook.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="待付款 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Value="待付款" NavigateUrl="NotPay.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="待发货 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Value="待发货" NavigateUrl="NotDeliver.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="待收货 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Value="待收货" NavigateUrl="NotReceive.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="待评价 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Value="待评价" NavigateUrl="NotAssess.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="已退款" Value="已退款" NavigateUrl="RefundBook.aspx"></asp:MenuItem>
                     </Items>
    </asp:Menu>
        <div class="auto-style2">
        <input type="text" id="txtInput" placeholder="输入订单号或商品名字进行搜索" class="auto-style1" value="" runat="server">
        <a href="#">
            <i class="fa fa-search" style="width: 39px; height: 29px; background-color :#fff" >
            <asp:Button ID="btnSearch" runat="server" BorderStyle="None" Height="16px" Width="16px"  OnClick="btnSearch_Click"/>
            </i>
        </a>
        </div>
    
    <div></div>
    <asp:GridView ID="GridView1" runat="server" style="margin-right: auto; margin-bottom: 10px;" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" Width="100%" CssClass="auto-style6" Height="318px" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" OnPageIndexChanging="GridView1_PageIndexChanging" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField HeaderText="订单号">
                <EditItemTemplate>
                    <asp:TextBox ID="txtBookId" runat="server" Enabled="False" Text='<%# Bind("bookId") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtBookId" runat="server" Text='<%# Bind("bookId") %>'></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="labBookId" runat="server" Text='<%# Bind("bookId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="商品号">
                <EditItemTemplate>
                    <asp:TextBox ID="txtGoodId" runat="server" Enabled="False" Text='<%# Bind("goodId") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtGoodId" runat="server" Text='<%# Bind("goodId") %>'></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="labGoodId" runat="server" Text='<%# Bind("goodId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="商品照片">
                <EditItemTemplate>
                    <asp:FileUpload ID="uploadPhoto" runat="server" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:FileUpload ID="uploadPhoto" runat="server" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Image ID="imgPhoto" runat="server" Height="50px" Width="50px" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="商品名字">
                <EditItemTemplate>
                    <asp:TextBox ID="txtName" runat="server" Enabled="False" Text='<%# Bind("goodName") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("goodName") %>'></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="labName" runat="server" Text='<%# Bind("goodName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="商品品牌">
                <EditItemTemplate>
                    <asp:TextBox ID="txtShopName" runat="server" Text='<%# Bind("shopName") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtShopName" runat="server" Text='<%# Bind("shopName") %>'></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="labShopName" runat="server" Text='<%# Bind("shopName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="商品类别">
                <EditItemTemplate>
                    <asp:TextBox ID="txtKind" runat="server" Text='<%# Bind("kind") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtKind" runat="server" Text='<%# Bind("kind") %>'></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="labKind" runat="server" Text='<%# Bind("kind") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="商品价格">
                <EditItemTemplate>
                    <asp:TextBox ID="txtPrice" runat="server" Text='<%# Bind("price") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtPrice" runat="server" Text='<%# Bind("price") %>'></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="labPrice" runat="server" Text='<%# Bind("price") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="购买数量">
                <EditItemTemplate>
                    <asp:TextBox ID="txtCount" runat="server" Text='<%# Bind("count") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtCount" runat="server" Text='<%# Bind("count") %>'></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="labCount" runat="server" Text='<%# Bind("count") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="总价">
                <EditItemTemplate>
                    <asp:TextBox ID="txtTotalPrice" runat="server" Text='<%# Bind("totalprice") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtTotalPrice" runat="server" Text='<%# Bind("totalprice") %>'></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="labTotalPrice" runat="server" Text='<%# Bind("totalprice") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="下单时间">
                <EditItemTemplate>
                    <asp:TextBox ID="txtTime" runat="server" Text='<%# Bind("time") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtTime" runat="server" Text='<%# Bind("time") %>'></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="labTime" runat="server" Text='<%# Bind("time") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="配送地址">
                <EditItemTemplate>
                    <asp:TextBox ID="txtAddress" runat="server" Text='<%# Bind("address") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtAddress" runat="server" Text='<%# Bind("address") %>'></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="labAddress" runat="server" Text='<%# Bind("address") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="物流状态">
                <EditItemTemplate>
                    <asp:TextBox ID="txtStatus" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtStatus" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="labStatus" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#265890" ForeColor="White" Font-Bold="True" />
        <HeaderStyle BackColor="#265890" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#265890" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
</asp:Content>
