using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebApplication2
{
    public partial class Cart : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }

        public DataTable GetDataSource()
        {
            string id = Session["Username"].ToString();
            //get
            DataTable dt = new DataTable();
            dt.Columns.Add("goodId", typeof(string));
            dt.Columns.Add("goodName", typeof(string));
            dt.Columns.Add("shopName", typeof(string));
            dt.Columns.Add("price", typeof(string));
            dt.Columns.Add("kind", typeof(string));
            dt.Columns.Add("count", typeof(string));
            //调用服务获取用户信息   
            EleServiceReference.EleServiceSoapClient ws1 = new EleServiceReference.EleServiceSoapClient("EleServiceSoap");
            if (ws1.GetCartInfo(id) == null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s1", "alert('信息不存在！');", true);
            }
            else
            {
                string[] cartList = ws1.GetCartInfo(id).ToArray();
                for (int i = 0; i < cartList.Length; i += 6)
                {
                    dt.Rows.Add(cartList[i], cartList[i + 1], cartList[i + 2], cartList[i + 3], cartList[i + 4], cartList[i + 5]);
                }
            }
            return dt;
        }

        protected void Bind()
        {
            GridView1.DataSource = null;
            GridView1.DataBind();

            DataTable dt = GetDataSource();
            if (dt.Rows.Count > 0)
            {

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            GridView1.Columns[0].Visible = false;//一开始隐藏
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    Image imgphoto = e.Row.FindControl("imgphoto") as Image;
                    Label labgoodId = e.Row.FindControl("labgoodId") as Label;
                    Label labgoodName = e.Row.FindControl("labgoodName") as Label;
                    string goodId = labgoodId.Text;
                    string goodName = labgoodName.Text;
                    string url = "Showimage.aspx?goodId=" + goodId;
                    imgphoto.ImageUrl = url;
                    string str = "javascript:return confirm('你确认要删除购物车的 “ " + goodName + " ” 吗?')";
                    e.Row.Cells[8].Attributes.Add("onclick", str);
                    string str2 = "javascript:return confirm('你确认要购买 “ " + goodName + " ” 吗?')";
                    e.Row.Cells[7].Attributes.Add("onclick", str2);
                }
                //先设置当鼠标上去的时候他的背景色改变
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='rgb(140,172,232)'");
                //再设置当鼠标离开后背景色再还原
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
            }


        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label labgoodId = GridView1.Rows[e.RowIndex].FindControl("labgoodId") as Label;
            string goodId = labgoodId.Text;
            string id = Session["Username"].ToString();
            EleServiceReference.EleServiceSoapClient ws1 = new EleServiceReference.EleServiceSoapClient("EleServiceSoap");
            if (ws1.DeleteCart(id, goodId))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s1", "alert('删除成功！');", true);
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s1", "alert('删除失败！');", true);

            Bind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Bind();
        }

        protected void btnplus_Click(object sender, EventArgs e)
        {
            string id = Session["Username"].ToString();
            EleServiceReference.EleServiceSoapClient ws1 = new EleServiceReference.EleServiceSoapClient("EleServiceSoap");
            Button btn = sender as Button;
            if (btn != null)
            {
                //两个Parent就可以得到GridviewRow对象 
                GridViewRow row = btn.Parent.Parent as GridViewRow;

                Label labcount = row.FindControl("labcount") as Label;
                Label labgoodId = row.FindControl("labGoodId") as Label;
                string count = labcount.Text.ToString();
                string goodId = labgoodId.Text.ToString();
                ws1.pluscount(id, goodId, count);
            }
            Bind();
        }

        protected void btnreduce_Click(object sender, EventArgs e)
        {
            string id = Session["Username"].ToString();
            EleServiceReference.EleServiceSoapClient ws1 = new EleServiceReference.EleServiceSoapClient("EleServiceSoap");
            Button btn = sender as Button;
            if (btn != null)
            {
                //两个Parent就可以得到GridviewRow对象 
                GridViewRow row = btn.Parent.Parent as GridViewRow;

                Label labcount = row.FindControl("labcount") as Label;
                Label labgoodId = row.FindControl("labGoodId") as Label;
                string count = labcount.Text.ToString();
                string goodId = labgoodId.Text.ToString();
                ws1.reducecount(id, goodId, count);
            }
            Bind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }

        protected void btnBook_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllBook.aspx");
        }

        protected void btnbuy_Click(object sender, EventArgs e)
        {
            EleServiceReference.EleServiceSoapClient ws1 = new EleServiceReference.EleServiceSoapClient("EleServiceSoap");
            Button btn = sender as Button;
            if (btn != null)
            {
                //两个Parent就可以得到GridviewRow对象 
                GridViewRow row = btn.Parent.Parent as GridViewRow;
                Label labcount = row.FindControl("labcount") as Label;
                Label labgoodId = row.FindControl("labGoodId") as Label;
                string goodId_buy = labgoodId.Text.ToString();
                string count_buy = labcount.Text.ToString();
                hidegoodId.Text = goodId_buy;
                hidecount.Text = count_buy;
                
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "s1", "ShowBlock();", true);
        }

        protected void BttCancel_Click(object sender, EventArgs e)
        {
            TxtAddress1.Text = "";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "s1", "HideBlock();", true);
        }

        protected void BtnOperation_Click(object sender, EventArgs e)
        {
            string id = Session["Username"].ToString();
            EleServiceReference.EleServiceSoapClient ws1 = new EleServiceReference.EleServiceSoapClient("EleServiceSoap");

            string goodId_buy = hidegoodId.Text.ToString();
            string count_buy = hidecount.Text.ToString();
            string[] condition = ws1.GoodCondition(goodId_buy).ToArray();
            string goodcondition = condition[0];

            string address = TxtAddress1.Text;
            if (goodcondition == "在售" && ws1.Buy(id, goodId_buy, count_buy, address))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s1", "alert('购买成功！');", true);
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s1", "alert('购买失败，商品缺货！');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "s1", "HideBlock();", true);
            Bind();
        }
    }
}