using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class ShopRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            //获取输入数据
            string userId = txtUserId.Text;
            string password = txtPassword.Text;
            //调用服务保存到数据库
            EleServiceReference.EleServiceSoapClient ws1 = new EleServiceReference.EleServiceSoapClient("EleServiceSoap");
            if (ws1.InsertShopInfo(userId, password))
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s2", "alert('保存成功！');", true);
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s2", "alert('保存失败！');", true);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtUserId.Text = "";
            txtPassword.Text = "";
            txtPassword1.Text = "";
            Response.Redirect("ShopLogin.aspx");
        }
    }
}