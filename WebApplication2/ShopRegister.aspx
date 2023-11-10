<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShopRegister.aspx.cs" Inherits="WebApplication2.ShopRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="icon" href="img/1111.jfif" sizes="16x16"/>
    <title>数码产品购物网</title>
    <style>
        .bodymove{
            /* 初始化 取消内外边距 */
            margin: 0;
            padding: 0;
            /* 100%窗口高度 */
            height: 100vh;
            /* 弹性布局 水平垂直居中 */
            display: flex;
            justify-content: center;
            align-items: center;
            /* 渐变背景 */ 
            background: linear-gradient(25deg, #172d18, #50584b, #8e8684, #d1b6c2);
            /* 指定背景图像的大小 */
            background-size: 500%;
            /* 执行动画：动画名 时长 线性的 无限次播放 */
            animation: bgAnimation 10s linear infinite;
        }
        /* 定义动画 */
        @keyframes bgAnimation {
            0%{
                background-position: 0% 50%;
            }
            50%{
                background-position: 100% 50%;
            }
            100%{
                background-position: 0% 50%;
            }
        }
        .div{
             margin:0px auto;   
	         width:500px;   
    	     height:350px; 
             position:absolute;
             top:50%;
    	     left: 50%;
    	     margin-left: -250px;
    	     margin-top: -150px;
             background-color:rgba(255,255,255,0.4);
             border-radius:15px;
             box-shadow: 0 5px 20px rgba(0,0,0,0.1);
         }
        .table
         {
	        margin:0px auto;   
	        width:600px;   
    	    height:300px; 
            display:flex;
            margin-left: 124px;
    	    margin-top: 30px;
         }
        .btnregister {
             width:150px;
             height:30px;
             margin:3px auto 4px auto;
             border:none;
             background:linear-gradient(-225deg, #172d18, #50584b, #8e8684, #d1b6c2);
             color:#fff;
             font-weight:500;
             cursor:pointer;
             transition:0.5s;/*动画过渡*/
             border-radius:10px;
             font-family:YouYuan,'幼圆',sans-serif;
         }
         .btnregister:hover{
             background: linear-gradient(-225deg,rgb(190,237,235) 0%, #C5C1FF 56%, #FFBAC3 100%);
             background-position-x:-150px;
         }
         .btncancel {
             width:150px;
             height:30px;
             margin:3px auto 4px auto;
             border:none;
             background:linear-gradient(-225deg, #172d18, #50584b, #8e8684, #d1b6c2);
             color:#fff;
             font-weight:500;
             cursor:pointer;
             transition:0.5s;/*动画过渡*/
             border-radius:10px;
             font-family:YouYuan,'幼圆',sans-serif;
         }
         .btncancel:hover{
             background-image: linear-gradient(-225deg,rgba(47,207,208,0.7),rgba(51,8,103,0.7));
             background-position-x:-150px;
         }
        .input{
             background-color:rgba(255,255,255,0.4);
             border:none;
             outline:none;
             border-radius:5px;
             font-family:YouYuan,'幼圆',sans-serif;
             font-size:large;
             width:150px;
         }
        .font{
             font-family:YouYuan,'幼圆',sans-serif;
             
         }
    </style>
</head>
<body class="bodymove">
    <form id="form1" runat="server">
        <div class="div">
            <p style="text-align: center;"><font size="6" class="font"><br/>&nbsp;&nbsp;商家注册</font></p>
            <table class="table">
                <tr>
                    <td style="text-align: right" class="font">用户名:</td>
                    <td><asp:TextBox ID="txtUserId" runat="server" CssClass="input"></asp:TextBox></td>                       
                </tr>
                <tr>
                    <td style="text-align: right" class="font"><br/>密&nbsp;&nbsp;码:</td>
                    <td ><br/><asp:TextBox ID="txtPassword" runat="server" CssClass="input"></asp:TextBox></td>                        
                </tr>
                <tr>
                    <td style="text-align: right" class="font"><br/>确认密码:</td>
                    <td><br/><asp:TextBox ID="txtPassword1" runat="server" CssClass="input"></asp:TextBox></td>                        
                </tr>
                <tr>
            	    <td ></td>
           	        <td >
                        <br/>
       	                <asp:Button ID="btnOK" runat="server" Text="注册" OnClick="btnOK_Click" CssClass="btnregister"/>
                        <br/>
      	                <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" CssClass="btncancel"/>
                    </td>            
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
