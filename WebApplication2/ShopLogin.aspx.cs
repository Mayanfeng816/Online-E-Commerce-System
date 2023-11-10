using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class ShopLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String shopId = txtUserId.Text;
            String password = txtPassword.Text;
            //调用服务获取用户信息   
            EleServiceReference.EleServiceSoapClient ws1 = new EleServiceReference.EleServiceSoapClient("EleServiceSoap");

            if (ws1.GetShopInfoByShopId(shopId) != null)
            {
                string[] userlist = ws1.GetShopInfoByShopId(shopId).ToArray();
                String password1 = userlist[1].ToString();
                if (password == password1)//&& usertype1 == usertype)
                {
                    Session["shopId"] = shopId;
                    Session["Password"] = password;
                    //Session["Usertype"] = usertype;
                    Response.Redirect("GoodCondition.aspx");
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "s2", "alert('登录成功！');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "s2", "alert('密码错误！');", true);
                }
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s2", "alert('商家不存在，请注册！');", true);
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShopRegister.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}