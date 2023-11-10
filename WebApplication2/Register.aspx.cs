using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.EleServiceReference;
using System.Data;

namespace WebApplication2
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            //获取输入数据
            string shopId = txtUserId.Text;
            string password = txtPassword.Text;
            string password2 = txtPassword1.Text;
            if (password != password2)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s2", "alert('确认密码与密码不一致！');", true);

            //调用服务保存到数据库
            EleServiceReference.EleServiceSoapClient ws1 = new EleServiceReference.EleServiceSoapClient("EleServiceSoap");
            if (ws1.InsertUserInfo(shopId, password))
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s2", "alert('保存成功！');", true);
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s2", "alert('保存失败！');", true);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtUserId.Text = "";
            txtPassword.Text = "";
            txtPassword1.Text = "";
            Response.Redirect("Login.aspx");
        }

    }
}