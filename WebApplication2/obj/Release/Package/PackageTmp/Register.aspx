<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication2.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <style>
        table
         {
	        margin:0px auto;   
	        width:500px;   
    	    height:200px; 
    	    position:absolute;
    	    top:50%;
    	    left: 50%;
    	    margin-left: -250px;
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
                    <td><asp:TextBox ID="txtUserId" runat="server"></asp:TextBox></td>                       
                </tr>
                <tr>
                    <td style="text-align: right">密&nbsp;码:</td>
                    <td ><asp:TextBox ID="txtPassword" runat="server" ></asp:TextBox></td>                        
                </tr>
                <tr>
                    <td style="text-align: right">确认密码:</td>
                    <td><asp:TextBox ID="txtPassword1" runat="server"></asp:TextBox></td>                        
                </tr>
                <tr>
            	    <td ></td>
           	        <td >
       	                <asp:Button ID="btnOK" runat="server" Text="注册" OnClick="btnOK_Click" />&nbsp;
      	                <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" />
                    </td>            
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
