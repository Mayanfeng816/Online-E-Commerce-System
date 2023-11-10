using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//网页第一次加载出来不是postback
            {
                if (Session["Username"].ToString() == "")
                {
                    Session["Username"] = "";
                    Session["Password"] = "";
                    Response.Redirect("Login.aspx");
                }
                Label1.Text = Session["Username"].ToString() + "，您好！";
            }
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Session["Username"] = "";
            Session["Password"] = "";
            Response.Redirect("Login.aspx");
        }
    }
}