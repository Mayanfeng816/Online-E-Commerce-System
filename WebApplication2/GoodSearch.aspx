<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GoodSearch.aspx.cs" Inherits="WebApplication2.GoodSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .search{
            color:rgba(2,61,125,0.8);
            font-size:xx-large;
            font-weight:bolder;
        }
        .fontB{
            color:#356497
        }
        .fontO{
            color:#fb8a2d
        }
        *{
            outline:none;
            padding:0;
            margin:0;
            text-decoration:none;
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
        .auto-style4 {
            height: 30px;
            width: 17%;
            margin-left: 670px;
        }
        </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Panel ID="Panel2" runat="server"  BackColor="#F7F6F3" Font-Names="Verdana" Font-Size="1.5em" ForeColor="#7C6F57" Width="100%">
               <div class="search">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;商品搜索
                   <input id="txtInput" runat="server" class="auto-style4" placeholder="请输入要搜索的内容" type="text" value="" />
                   <asp:Button ID="Button2" runat="server" BorderStyle="None" Height="35px" OnClick="btnSearch_Click" Text="搜索" Width="81px" />
                </div>
        </asp:Panel>
    <asp:Panel ID="Panel1" runat="server" Width="100%">
        <asp:GridView ID="GridView1" runat="server" style="margin:auto;" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" ShowHeader="False" BorderColor="#CCCCCC" BorderWidth="3px">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <div onclick="window.location.href='<%# Eval("goodDetailurl1") %>'" >
                        <div>
                        <asp:Image ID="Img1" runat="server" ImageUrl='<%# Eval("imgurl1") %>' Width="200px" Height="200px"/>
                        </div>
                        <div>
                        <asp:Label ID="LabName1" runat="server" Text='<%# Eval("name1") %>' CssClass="fontB"></asp:Label>
                        </div>
                        <div>
                        <asp:Label ID="LabPrice1" runat="server" Text='<%# Eval("price1") %>' CssClass="fontO"></asp:Label>
                        </div>
                        </div>
                    </ItemTemplate>
                    <ItemStyle Width="20%" BorderColor="#CCCCCC" BorderWidth="3px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <div onclick="window.location.href='<%# Eval("goodDetailurl2") %>'" >
                        <div>
                        <asp:Image ID="Img2" runat="server" ImageUrl='<%# Eval("imgurl2") %>' Width="200px" Height="200px"/>
                        </div>
                        <div>
                        <asp:Label ID="LabName2" runat="server" Text='<%# Eval("name2") %>' CssClass="fontB"></asp:Label>
                        </div>
                        <div>
                        <asp:Label ID="LabPrice2" runat="server"  Text='<%# Eval("price2") %>' CssClass="fontO"></asp:Label>
                        </div>
                        </div>
                    </ItemTemplate>
                    <ItemStyle Width="20%" BorderColor="#CCCCCC" BorderWidth="3px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <div onclick="window.location.href='<%# Eval("goodDetailurl3") %>'" >
                        <div>
                        <asp:Image ID="Img3" runat="server" ImageUrl='<%# Eval("imgurl3") %>' Width="200px" Height="200px"/>
                        </div>
                        <div>
                        <asp:Label ID="LabName3" runat="server" Text='<%# Eval("name3") %>' CssClass="fontB"></asp:Label>
                        </div>
                        <div>
                        <asp:Label ID="LabPrice3" runat="server"  Text='<%# Eval("price3") %>' CssClass="fontO"></asp:Label>
                        </div>
                        </div>
                    </ItemTemplate>
                    <ItemStyle Width="20%" BorderColor="#CCCCCC" BorderWidth="3px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <div onclick="window.location.href='<%# Eval("goodDetailurl4") %>'" >
                        <div>
                        <asp:Image ID="Img4" runat="server" ImageUrl='<%# Eval("imgurl4") %>' Width="200px" Height="200px"/>
                        </div>
                        <div>
                        <asp:Label ID="LabName4" runat="server" Text='<%# Eval("name4") %>' CssClass="fontB"></asp:Label>
                        </div>
                        <div>
                        <asp:Label ID="LabPrice4" runat="server"  Text='<%# Eval("price4") %>' CssClass="fontO"></asp:Label>
                        </div>
                        </div>
                    </ItemTemplate>
                    <ItemStyle Width="20%" BorderColor="#CCCCCC" BorderWidth="3px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate >
                        <div onclick="window.location.href='<%# Eval("goodDetailurl5") %>'" >
                        <div>
                        <asp:Image ID="Img5" runat="server" ImageUrl='<%# Eval("imgurl5") %>' Width="200px" Height="200px"/>
                        </div>
                        <div>
                        <asp:Label ID="LabName5" runat="server" Text='<%# Eval("name5") %>' CssClass="fontB"></asp:Label>
                        </div>
                        <div>
                        <asp:Label ID="LabPrice5" runat="server" Text='<%# Eval("price5") %>' CssClass="fontO"></asp:Label>
                        </div>
                        </div>
                    </ItemTemplate>
                    <ItemStyle Width="20%" BorderColor="#CCCCCC" BorderWidth="3px" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>