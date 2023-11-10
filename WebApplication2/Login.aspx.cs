using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String userId = txtUserId.Text;
            String password = txtPassword.Text;
            //调用服务获取用户信息   
            EleServiceReference.EleServiceSoapClient ws1 = new EleServiceReference.EleServiceSoapClient("EleServiceSoap");
            
            if (ws1.GetUserInfoByUserId(userId) != null)
            {
                string[] userlist = ws1.GetUserInfoByUserId(userId).ToArray();
                String password1 = userlist[1].ToString();
                if (password == password1)//&& usertype1 == usertype)
                {
                    Session["Username"] = userId;
                    Session["Password"] = password;
                    //Session["Usertype"] = usertype;
                    //Response.Redirect("FavoriteShop.aspx");
                    Response.Redirect("Recommend.aspx?op=");
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "s2", "alert('登录成功！');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "s2", "alert('密码错误！');", true);
                }
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s2", "alert('用户不存在，请注册！');", true);
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void btnShopLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShopLogin.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");
        }
    }
}