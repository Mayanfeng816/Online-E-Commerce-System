using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebApplication2.OrderService;
namespace WebApplication2
{
    public partial class OrderManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string shopname = Session["shopId"].ToString();
            
           
            if (!IsPostBack)
            {
                OrderServiceSoapClient ws1 = new OrderServiceSoapClient("OrderServiceSoap");
                string[] goodslist = ws1.GetGoodByShop(shopname).ToArray();
                ddlGood.Items.Clear();
                ddlGood.Items.Add("");
                for (int i = 0; i < goodslist.Length; i++)
                {
                    ddlGood.Items.Add(goodslist[i]);
                }
                ddlGood.Text = "";
                ddlTime.Text = "半年内";
                bind(shopname);
            }


        }

        //绑定数据
        protected void bind(string shopName)
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            string goodName = ddlGood.Text;
            string time = ddlTime.Text;
            DateTime time1;
            if (time.Equals("一周内"))
                time1 = DateTime.Now.AddDays(-7);
            else if (time.Equals("一月内"))
                time1 = DateTime.Now.AddMonths(-1);
            else if (time.Equals("半年内"))
                time1 = DateTime.Now.AddMonths(-6);
            else
                time1 = DateTime.Now;
            time = time1.ToString("yyyy-MM-dd");
            DataTable dt = GetDataSource(shopName,goodName,time);
            if (dt.Rows.Count > 0)
            {

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

        }

        public DataTable GetDataSource(string shopName,string goodName,string time)
        {
            //get
            DataTable dt = new DataTable();
            dt.Columns.Add("bookId", typeof(string));
            dt.Columns.Add("userId", typeof(string));
            dt.Columns.Add("goodName", typeof(string));
            dt.Columns.Add("count", typeof(string));
            dt.Columns.Add("price", typeof(string));
            dt.Columns.Add("address", typeof(string));
            dt.Columns.Add("time", typeof(string));
            //调用服务获取用户信息   
            OrderServiceSoapClient ws1 = new OrderServiceSoapClient("OrderServiceSoap");

            
            if (ws1.GetAllBookInfoByCondition(shopName, time, goodName) == null)
            {
                return dt;
            }
            String[] booklist = ws1.GetAllBookInfoByCondition(shopName, time, goodName).ToArray();
            for (int i = 0; i < booklist.Length; i += 7)
            {
                double count = double.Parse(booklist[i + 3]);
                double price = double.Parse(booklist[i + 4]);
                string totalprice = Convert.ToString(count*price);
                string ordertime = booklist[i + 6];
                int index = ordertime.IndexOf(" 0:00:00");
                ordertime = ordertime.Substring(0,index);
                dt.Rows.Add(booklist[i], booklist[i + 1], booklist[i + 2], booklist[i + 3],totalprice , booklist[i + 5], ordertime);

            }
            return dt;

        }

        protected void BtnDisplay_Click(object sender, EventArgs e)
        {
            bind(Session["shopId"].ToString()); //TODO 修改成Session的shopname!!!!
        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
            Label labNo = GridView1.Rows[rowindex].FindControl("LabNo") as Label;
            string bookId = labNo.Text;
            OrderServiceSoapClient ws1 = new OrderServiceSoapClient("OrderServiceSoap");
            if (ws1.UpdateBookInfo(bookId, "已发货"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s1", "alert('发货成功！');", true);
                bind(Session["shopId"].ToString());//TODO修改
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s1", "alert('发货失败！');", true);
                bind(Session["shopId"].ToString());//TODO修改
            }
        }

        protected void BtnRefund_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
            Label labNo = GridView1.Rows[rowindex].FindControl("LabNo") as Label;
            string bookId = labNo.Text;
            OrderServiceSoapClient ws1 = new OrderServiceSoapClient("OrderServiceSoap");
            if(ws1.UpdateBookInfo(bookId, "已退款"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s1", "alert('退款成功！');", true);
                bind(Session["shopId"].ToString());//TODO修改
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s1", "alert('退款成功！');", true);
                bind(Session["shopId"].ToString());//TODO修改
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    Button btn_Confirm = e.Row.FindControl("BtnConfirm") as Button;
                    Button btn_Refund = e.Row.FindControl("BtnRefund") as Button;
                    btn_Confirm.Attributes.Add("onclick", "javascript:return confirm('你确认要发货该商品吗?')");
                    btn_Refund.Attributes.Add("onclick", "javascript:return confirm('你确认要退款吗?')");
                }
                //先设置当鼠标上去的时候他的背景色改变
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#41566e'");
                //再设置当鼠标离开后背景色再还原
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bind(Session["shopId"].ToString());//TODO 修改！！！
        }


    }
}