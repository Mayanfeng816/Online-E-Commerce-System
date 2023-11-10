<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GoodDetail.aspx.cs" Inherits="WebApplication2.GoodDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 50%;
            height: 500px;
        }
        .auto-style2 {
            height: 500px;
        }
        .border-radius{
            border-radius:5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="0" cellpadding="0" style="width:100%;" >
        <tr style="height:35px;background-color:gainsboro;" >
            <td style="color:#1396ee">&nbsp;&nbsp;数码 > <asp:Label ID="LabKind" runat="server" Text="相机" ForeColor="#1396ee"></asp:Label> > </td>
            <td></td>
            <td style="width:40%">
                <asp:Label ID="LabShop" runat="server" Text="悉尼旗舰店" style="text-align:right;" Width="70%" ForeColor="#1396ee"></asp:Label>
                &nbsp;
                <asp:CheckBox ID="CheckShop" runat="server" Text="收藏店铺" ForeColor="#1396ee" Border="" BorderStyle="None" AutoPostBack="True" OnCheckedChanged="CheckShop_CheckedChanged"/>
            </td>
        </tr>
    </table>

    <table style="width:100%;background-color:white">
        <tr>
            <td style="width:40%">
                <div style="float:right;border:3px solid #d2d6db;">
                    
                    <asp:Image ID="ImgGood" runat="server" Height="400px" Width="400px" ImageUrl="~/img/camera.jpg" ImageAlign="Right"  />
               
                </div>
                
            </td>
            <td >
                <asp:Panel ID="Panel1" runat="server" Height="400px">
                    <div style="margin-left:30px;margin-top:50px">
                    <asp:Label ID="LabName" runat="server" Text="DRIFT Ghost XL Pro4K30帧超高清运动相机摩托车行车记录仪自行车骑行防抖户外直播 官方标配" Font-Bold="True" Font-Size="X-Large" ></asp:Label>
                </div>
                <div style="margin-left:30px;margin-top:30px">
                    <asp:Label ID="LabPrice" runat="server" Text="￥3999" Font-Size="XX-Large" Font-Bold="True" ForeColor="Red" ></asp:Label>
                </div>
                <div style="margin-left:30px;margin-top:30px">
                    <asp:Label ID="Label1" runat="server" Text="数量" Font-Size="Large"></asp:Label>
                    <asp:Button ID="Btnsub" runat="server" Text="-" BorderWidth="0" Font-Size="Medium" OnClick="Btnsub_Click" />
                    <asp:Label ID="LabCount" runat="server" Text="1" BorderColor="#666666" BorderWidth="1px" Font-Size="Medium"></asp:Label>
                    <asp:Button ID="Btnplus" runat="server" Text="+" BorderWidth="0" Font-Size="Medium" OnClick="Btnplus_Click" />
                </div>
                <div style="margin-left:30px;margin-top:30px">
                    <asp:Label ID="Label2" runat="server" Text="配送至" Font-Size="Large" Font-Bold="True"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="TxtAdress" runat="server" Font-Size="Medium" Text="北京市房山区良乡大学城北京工商大学" Font-Bold="True" Width="233px"></asp:TextBox>
                </div>
                <div style="margin-left:30px;margin-top:30px">
                    <asp:Button ID="BtnFav" runat="server" Text="收藏商品" Width="110px" Height="50px" BorderWidth="0" BackColor="#996600" Font-Bold="True" Font-Size="Larger" CssClass="border-radius" style="color:white;" OnClick="BtnFav_Click" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BtnCart" runat="server" Text="加入购物车" Width="110px" Height="50px" BorderWidth="0" Font-Bold="True" Font-Size="Larger" CssClass="border-radius" BackColor="#336699" style="color:white;" OnClick="BtnCart_Click"/>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BtnPay" runat="server" Text="购买商品" Width="100px" Height="50px" BorderWidth="0" BackColor="#CC6600" Font-Bold="True" Font-Size="Larger" CssClass="border-radius" style="color:white;" OnClick="BtnPay_Click" />
                </div>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <hr style="width:100%;" />
    <asp:Panel ID="Panel3" runat="server" Width="100%" BackColor="#eaeaea" Height="20px"></asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Width="100%" BackColor="#eaeaea" >
        <div style="margin:auto;width:80%;height:90px">
            <table  >
                <tr >
                    <td style="width:20%">
                        <asp:Image ID="Imageduo" runat="server" ImageUrl="~/img/duo.png" ImageAlign="AbsMiddle" />
                        <asp:Label ID="LabDuo" runat="server" Text="品类齐全，轻松购物" Font-Bold="True"></asp:Label>
                    </td>
                    <td style="width:20%">
                        <asp:Image ID="Imagekuai" runat="server" ImageUrl="~/img/kuai.png" ImageAlign="AbsMiddle" />
                        <asp:Label ID="LabKuai" runat="server" Text="多仓直发，极速配送" Font-Bold="True"></asp:Label>
                    </td>
                    <td style="width:20%">
                        <asp:Image ID="Imagehao" runat="server" ImageUrl="~/img/hao.png" ImageAlign="AbsMiddle" />
                        <asp:Label ID="LabHao" runat="server" Text="正品行货，精致服务" Font-Bold="True"></asp:Label>
                    </td>
                    <td style="width:20%">
                        <asp:Image ID="Imagesheng" runat="server" ImageUrl="~/img/sheng.png" ImageAlign="AbsMiddle" />
                        <asp:Label ID="LabSheng" runat="server" Text="天天低价，畅选无忧" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
</asp:Content>
