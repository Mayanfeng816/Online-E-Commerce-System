<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Recommend.aspx.cs" Inherits="WebApplication2.Recommend" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .mayLike{
            width:100%;
            height:65px;
            padding-top:20px;
            padding-left:20px
        }
        .like{
            color:rgba(2,61,125,0.8);
            font-size:xx-large;
            font-weight:bolder;
        }
        .fontB{
            color:#356497
        }
        .fontB:hover{
            color:#3b38ec
        }
        .fontO{
            color:#fb8a2d
        }
        .bac{}
        .bac:hover{
            background-color:gray
        }
    </style>

    <div class="mayLike">
        <div class="like">猜你喜欢</div>
    </div>

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
                    <ItemStyle Width="18%" BorderColor="#CCCCCC" BorderWidth="3px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <div onclick="window.location.href='<%# Eval("goodDetailurl2") %>'" >
                        <div>
                        <asp:Image ID="Img2" runat="server" ImageUrl='<%# Eval("imgurl2") %>' Width="200px" Height="200px"/>
                        </div>
                        <div>
                        <asp:Label ID="LabName1" runat="server" Text='<%# Eval("name2") %>' CssClass="fontB"></asp:Label>
                        </div>
                        <div>
                        <asp:Label ID="LabPrice1" runat="server"  Text='<%# Eval("price2") %>' CssClass="fontO"></asp:Label>
                        </div>
                        </div>
                    </ItemTemplate>
                    <ItemStyle Width="18%" BorderColor="#CCCCCC" BorderWidth="3px" />
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
                    <ItemStyle Width="18%" BorderColor="#CCCCCC" BorderWidth="3px" />
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
                    <ItemStyle Width="18%" BorderColor="#CCCCCC" BorderWidth="3px" />
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
                    <ItemStyle Width="18%" BorderColor="#CCCCCC" BorderWidth="3px" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>
