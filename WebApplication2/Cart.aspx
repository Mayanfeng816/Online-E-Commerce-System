<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="WebApplication2.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .gridviewTitle{
            background:linear-gradient(to right,rgba(155,183,234,1),rgba(169,193,237,0.5),rgba(227,197,235,1));
        }
        .count{
            border-radius:5px;
            background-color:rgb(240,240,240);
        }
        .picture{
            border-radius:10px;
        }
        .btnblue {
             border:none;
             background-color:#a9c1ed;
             /*background:linear-gradient(-200deg,rgba(131,165,228,1),#e3c5eb);*/
             color:#fff;
             font-weight:bold;
             cursor:pointer;
             border-radius:5px;
             transition:0.5s;/*动画过渡*/
         }
        .btnblue2 {
             width:170px;
             height:30px;
             margin:3px auto 4px auto;
             border:none;
             background-color:rgba(131,165,228,1);
             /*background:linear-gradient(-200deg,rgba(131,165,228,1),#e3c5eb);*/
             color:#fff;
             font-weight:bold;
             cursor:pointer;
             transition:0.5s;/*动画过渡*/
             border-radius:20px;
             box-shadow: 0 5px 25px rgba(140,172,232,1),0 0 0 10px rgba(140,172,232,0.1);
         }
        .btnblueselect {
             width:170px;
             height:30px;
             margin:3px auto 4px auto;
             border:none;
             background-color:rgba(86,133,220,1);
             /*background:linear-gradient(-200deg,rgba(131,165,228,1),#e3c5eb);*/
             color:#fff;
             font-weight:bold;
             cursor:pointer;
             transition:0.5s;/*动画过渡*/
             border-radius:20px;
             box-shadow: 0 5px 25px rgba(140,172,232,1),0 0 0 10px rgba(140,172,232,0.1);
         }
        .btnblue2:hover{
             background: linear-gradient(-225deg,rgb(190,237,235) 0%, #C5C1FF 56%, #FFBAC3 100%);
             background-position-x:-170px;
         }
         .btnblueselect:hover{
             background: linear-gradient(-225deg,rgb(190,237,235) 0%, #C5C1FF 56%, #FFBAC3 100%);
             background-position-x:-170px;
         }
        .btnbook {
             width:70px;
             height:30px;
             border:none;
             background-color:#a9c1ed;
             /*background:linear-gradient(-200deg,rgba(131,165,228,1),#e3c5eb);*/
             color:#fff;
             font-weight:bold;
             cursor:pointer;
             border-radius:5px;
             transition:0.5s;/*动画过渡*/
         }
        .btnbook:hover{
             background: linear-gradient(-225deg,rgb(190,237,235) 0%, #C5C1FF 56%, #FFBAC3 100%);
             background-position-x:-70px;
         }
        .btnblue:hover{
             background: linear-gradient(-225deg,rgb(190,237,235) 0%, #C5C1FF 56%, #FFBAC3 100%);
         }
        .table
         {
           height:109px;
	       width:100%; 
           border:none; 
           background-image:linear-gradient(to right,rgba(169,193,237,1),rgba(169,193,237,0.5),rgba(227,197,235,1)),url('img/7777.jpg');
           /*border-radius:15px;*/

           /*background-color:#53adeb;*/
         }
        .font2{
             font-family:YouYuan,'幼圆',sans-serif;
             font-weight:800;
             color:#375d9a;
             text-shadow:#fff 1px 0 0,#fff 0 1px 0, #fff -1px 0 0,#fff 0 -1px 0;
         }
        .btndelete {
             width:70px;
             height:30px;
             border:none;
             background-color:#a9c1ed;
             /*background:linear-gradient(-200deg,rgba(131,165,228,1),#e3c5eb);*/
             color:#fff;
             font-weight:bold;
             cursor:pointer;
             border-radius:5px;
             transition:0.5s;/*动画过渡*/
         }
        .btndelete:hover{
             background-image: linear-gradient(-225deg, #30cfd0 0%, #330867 100%);
             background-position-x:-70px;
         }
        .txtaddress{
        border:none;
        background-color:#ffffff;
        border-radius:5px;
        outline:none;
        }
        .btnaddress{
            border:solid 1px;
            background-color:#ffffff;
            border-color:#f5f5f5;
            border-radius:5px;
        }
    </style>
    <script type="text/javascript">
        function HideBlock() {
            document.getElementById("divNewBlock").style.display = "none";
            return false;
        }
 
 
        function ShowBlock() {
            var set = SetBlock();
            document.getElementById("divNewBlock").style.display = "";
            return false;
        }
 
 
        function SetBlock() {
            var top = document.body.scrollTop;
            var left = document.body.scrollLeft;
            var height = document.body.clientHeight;
            var width = document.body.clientWidth;
 
 
            if (top == 0 && left == 0 && height == 0 && width == 0) {
                top = document.documentElement.scrollTop;
                left = document.documentElement.scrollLeft;
                height = document.documentElement.clientHeight;
                width = document.documentElement.clientWidth;
            }
            return { top: top, left: left, height: height, width: width };
        }
 
 

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table">
       <tr>
            <td>
                <asp:Button ID="btnCart" runat="server" Text="购物车" CssClass="btnblueselect" OnClick="btnCart_Click" />
                <asp:Button ID="btnBook" runat="server" Text="我的订单" CssClass="btnblue2" OnClick="btnBook_Click"/>
            </td>
        </tr>
    </table>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" ShowHeader="False" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="5" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDeleting="GridView1_RowDeleting" Width="100%">
        <AlternatingRowStyle CssClass="gridviewTitle" />
        <Columns>
            <asp:TemplateField HeaderText="商品ID">
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
            <asp:TemplateField HeaderText="类别">
                <ItemTemplate>
                    <asp:Label ID="labkind" runat="server" Text='<%# Bind("kind") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="价格">
                <ItemTemplate>
                    <asp:Label ID="labprice" runat="server" Text='<%# Bind("price") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="数量">
                <ItemTemplate>
                    <asp:Button ID="btnplus" runat="server" Height="20px" OnClick="btnplus_Click" Text="+" Width="20px" CssClass="btnblue" CommandArgument='<%# Eval("count") %>'/>  
                    <asp:Label ID="labcount"  CssClass="count" Width="30px" Height="20px" runat="server" Text='<%# Eval("count") %>' ></asp:Label>
                    <asp:Button ID="btnreduce" runat="server" Height="20px" OnClick="btnreduce_Click" Text="-" Width="20px"  CssClass="btnblue" CommandArgument='<%# Eval("count") %>' />
                </ItemTemplate>
             </asp:TemplateField>
            <asp:TemplateField HeaderText="购买" ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btnbuy" runat="server" OnClick="btnbuy_Click" Text="购买" CssClass="btnbook"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="删除" ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="删除" CssClass="btndelete"></asp:Button>
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
    <asp:Label ID="hidegoodId" runat="server" Text="Label" Visible="False"></asp:Label>
    <asp:Label ID="hidecount" runat="server" Text="Label" Visible="False"></asp:Label>
    <!--弹出层，-->   
    <div id="divNewBlock" style="display:none; border:none;height:130px;width:300px;background-color:rgba(83,103,134,0.8);position:absolute;top:40%;left:40%;border-radius:10px;">
            <div style="padding:3px 15px 3px 15px;text-align:left;vertical-align:middle;" >
                <div style="text-align:center;color:white;">
                   <br/>请输入地址
                </div>
                <div style="text-align:center;"><br/>
                    <asp:TextBox ID="TxtAddress1" runat ="server" CssClass="txtaddress"></asp:TextBox>
                </div>
                <div style="text-align:center;">  
                    <br/>
                    <asp:Button ID="BtnOperation" runat="server" Text="确定" CssClass="btnaddress" OnClick="BtnOperation_Click"/> 
                    &nbsp;
                    <asp:Button ID="BttCancel"  runat="server" Text="关闭" CssClass="btnaddress" OnClick="BttCancel_Click"/>
                    
                </div>
            </div>
      </div> 
</asp:Content>
