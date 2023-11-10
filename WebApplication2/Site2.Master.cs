using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Site2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//网页第一次加载出来不是postback
            {
                if (Session["shopId"].ToString() == "")
                {
                    Session["shopId"] = "";
                    Session["Password"] = "";
                    Response.Redirect("ShopLogin.aspx");
                }
                Label1.Text = Session["shopId"].ToString() + "员工，您好！";
            }
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Session["shopId"] = "";
            Session["Password"] = "";
            Response.Redirect("ShopLogin.aspx");
        }
    }
}