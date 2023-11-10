<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="GoodCondition.aspx.cs" Inherits="WebApplication2.GoodCondition" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
        width: 124px;
        color:white;
    }
        .auto-style5 {
            width: 236px;
            color:white;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="margin:0px auto 10px auto; width:100%; background-color: #265886; background-image:url('img/7777.jpg')">
        <tr>
            <td class="auto-style2" style="text-align: right" >商品名字：</td>
            <td class="auto-style5" style="text-align:left">
                <asp:TextBox ID="txtName" runat="server" Height="26px" Width="200px"></asp:TextBox>
               </td>  
            <td class="auto-style2" style="text-align: right">商品种类：</td>
            <td style="text-align:left" class="auto-style5">
                 <asp:DropDownList ID="ddlKind" runat="server" Height="33px" Width="200px">
                     <asp:ListItem></asp:ListItem>
                     <asp:ListItem>手机</asp:ListItem>
                     <asp:ListItem>平板</asp:ListItem>
                     <asp:ListItem>电脑</asp:ListItem>
                     <asp:ListItem>相机</asp:ListItem>
                </asp:DropDownList>
             </td>   
            <td class="auto-style2" style="text-align: right">商品状态：</td>
            <td style="text-align:left" class="auto-style5">
                 <asp:DropDownList ID="ddlCondition" runat="server" Height="33px" Width="200px">
                     <asp:ListItem></asp:ListItem>
                     <asp:ListItem>在售</asp:ListItem>
                     <asp:ListItem>缺货</asp:ListItem>
                </asp:DropDownList>
             </td>
            <td class="auto-style16" style="text-align: right"> 
              <asp:Button ID="btnDisplay" runat="server" Text="查询" OnClick="btnDisplay_Click" Width="75px"  />
                &nbsp;
              <asp:Button ID="btnNew" runat="server" OnClick="btnNew_Click" Text="新增" Width="75px" />
                &nbsp;
            </td>
        </tr>
        </table>
    <asp:GridView ID="GridView1" runat="server" style="margin:0px auto 10px auto; width:100%;" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="GridView1_RowDataBound" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField HeaderText="商品号">
                <EditItemTemplate>
                    <asp:TextBox ID="txtId" runat="server" Enabled="False" Text='<%# Bind("goodId") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtId" runat="server" Text='<%# Bind("goodId") %>' Enabled="False"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="labId" runat="server" Text='<%# Bind("goodId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="店铺名字">
                <EditItemTemplate>
                    <asp:TextBox ID="txtShopName" runat="server" Text='<%# Bind("shopName") %>' Enabled="False"></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtShopName" runat="server" Text='<%# Bind("shopName") %>' Enabled="False"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="labShopName" runat="server" Text='<%# Bind("shopName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="商品名字">
                <EditItemTemplate>
                    <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("goodName") %>' Enabled="False"></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("goodName") %>'></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="labName" runat="server" Text='<%# Bind("goodName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="商品类别">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlKind1" runat="server" AutoPostBack="True" Enabled="False">
                        <asp:ListItem></asp:ListItem>
                     <asp:ListItem>手机</asp:ListItem>
                     <asp:ListItem>平板</asp:ListItem>
                     <asp:ListItem>电脑</asp:ListItem>
                     <asp:ListItem>相机</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="ddlKind2" runat="server" AutoPostBack="True">
                        <asp:ListItem></asp:ListItem>
                     <asp:ListItem>手机</asp:ListItem>
                     <asp:ListItem>平板</asp:ListItem>
                     <asp:ListItem>电脑</asp:ListItem>
                     <asp:ListItem>相机</asp:ListItem>
                    </asp:DropDownList>
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
            <asp:TemplateField HeaderText="商品状态">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlCondition1" runat="server" AutoPostBack="True">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>在售</asp:ListItem>
                        <asp:ListItem>缺货</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="ddlCondition2" runat="server" AutoPostBack="True">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>在售</asp:ListItem>
                        <asp:ListItem>缺货</asp:ListItem>
                    </asp:DropDownList>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="labCondition" runat="server" Text='<%# Bind("condition") %>'></asp:Label>
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
            <asp:TemplateField HeaderText="编辑" ShowHeader="False">
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="更新"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消"></asp:LinkButton>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="保存" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Edit" Text="编辑"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
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
    <asp:Label ID="labRowIndex" runat="server" Text="Label" Visible="False"></asp:Label>
    </asp:Content>
