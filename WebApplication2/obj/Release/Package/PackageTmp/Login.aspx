<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style>
         table
         {
	        margin:0px auto;   
	        width:600px;   
    	    height:200px; 
    	    position:absolute;
    	    top:50%;
    	    left: 50%;
    	    margin-left: -300px;
    	    margin-top: -100px;
         }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td style="text-align: right">用户名:</td>
                    <td><asp:TextBox ID="txtUserId" runat="server" ValidationGroup="login"></asp:TextBox></td>
                    <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserId" ErrorMessage="必须输入用户名" SetFocusOnError="True" ValidationGroup="login"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">密&nbsp;码:</td>  
                    <td><asp:TextBox ID="txtPassword" runat="server" ValidationGroup="login" ></asp:TextBox> </td>
                    <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="必须输入密码" SetFocusOnError="True" ValidationGroup="login"> </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnLogin" runat="server" Text="登录" OnClick="btnLogin_Click" ValidationGroup="login"  />&nbsp;&nbsp;
                        <asp:Button ID="btnRegister" runat="server" Text="注册" OnClick="btnRegister_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
