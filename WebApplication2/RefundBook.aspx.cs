using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class RefundBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.Columns[1].Visible = false;
            if (!IsPostBack)
            {
                bind1();
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bind1();
        }

        protected void bind1()
        {
            GridView1.Columns[1].Visible = false;
            GridView1.DataSource = null;
            GridView1.DataBind();
            Good good = new Good();
            Book book = new Book();

            DataTable dt = GetDataSource1(book, good);
            if (dt.Rows.Count > 0)
            {

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        public DataTable GetDataSource1(Book book, Good good)
        {
            //get
            {
                string id = Session["Username"].ToString();
                DataTable dt = new DataTable();
                dt.Columns.Add("bookId", typeof(string));
                dt.Columns.Add("GoodId", typeof(string));
                dt.Columns.Add("GoodName", typeof(string));
                dt.Columns.Add("shopName", typeof(string));
                dt.Columns.Add("kind", typeof(string));
                dt.Columns.Add("price", typeof(string));
                dt.Columns.Add("count", typeof(string));
                dt.Columns.Add("totalprice", typeof(string));
                dt.Columns.Add("status", typeof(string));
                dt.Columns.Add("time", typeof(string));
                dt.Columns.Add("address", typeof(string));
                //调用服务获取用户信息   
                EleServiceReference.EleServiceSoapClient ws1 = new EleServiceReference.EleServiceSoapClient("EleServiceSoap");

                if (ws1.GetRefundBookinfo(id) != null)
                {
                    string[] goodlist = ws1.GetRefundBookinfo(id).ToArray();
                    for (int i = 0; i < goodlist.Length; i += 11)//6个信息是一个记录
                    {
                        dt.Rows.Add(goodlist[i], goodlist[i + 1], goodlist[i + 2], goodlist[i + 3], goodlist[i + 4], goodlist[i + 5], goodlist[i + 6], goodlist[i + 7], goodlist[i + 8], goodlist[i + 9], goodlist[i + 10]);

                    }
                }
                else ScriptManager.RegisterStartupScript(this, this.GetType(), "s2", "alert('您搜索的订单信息不存在！');", true);
                return dt;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bind2();
        }
        protected void bind2()
        {
            GridView1.Columns[1].Visible = false;
            GridView1.DataSource = null;
            GridView1.DataBind();
            Good good = new Good();
            Book book = new Book();
            string input = txtInput.Value;
            DataTable dt = GetDataSource2(book, good);
            if (dt.Rows.Count > 0)
            {

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        public DataTable GetDataSource2(Book book, Good good)
        {
            //get
            {
                string id = Session["Username"].ToString();
                string input = txtInput.Value;
                DataTable dt = new DataTable();
                dt.Columns.Add("bookId", typeof(string));
                dt.Columns.Add("GoodId", typeof(string));
                dt.Columns.Add("GoodName", typeof(string));
                dt.Columns.Add("shopName", typeof(string));
                dt.Columns.Add("kind", typeof(string));
                dt.Columns.Add("price", typeof(string));
                dt.Columns.Add("count", typeof(string));
                dt.Columns.Add("totalprice", typeof(string));
                dt.Columns.Add("status", typeof(string));
                dt.Columns.Add("time", typeof(string));
                dt.Columns.Add("address", typeof(string));
                //调用服务获取用户信息   
                EleServiceReference.EleServiceSoapClient ws1 = new EleServiceReference.EleServiceSoapClient("EleServiceSoap");

                if (ws1.GetRefundBookinfoByInput(input, id) != null)
                {
                    string[] goodlist = ws1.GetRefundBookinfoByInput(input, id).ToArray();
                    for (int i = 0; i < goodlist.Length; i += 11)//6个信息是一个记录
                    {
                        dt.Rows.Add(goodlist[i], goodlist[i + 1], goodlist[i + 2], goodlist[i + 3], goodlist[i + 4], goodlist[i + 5], goodlist[i + 6], goodlist[i + 7], goodlist[i + 8], goodlist[i + 9], goodlist[i + 10]);

                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "s2", "alert('您搜索的订单信息不存在！');", true);
                    bind1();
                }
                return dt;
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    Image imgPhoto = e.Row.FindControl("imgPhoto") as Image;
                    Label labGoodId = e.Row.FindControl("labGoodId") as Label;
                    string goodId = labGoodId.Text.Trim();
                    Label labName = e.Row.FindControl("labName") as Label;
                    string goodName = labGoodId.Text.Trim();
                    string url = "Showimage.aspx?goodid=" + goodId;
                    imgPhoto.ImageUrl = url;
                    string str = "javascript:return confirm('你确认要删除" + goodName + "的记录吗?')";
                    e.Row.Cells[9].Attributes.Add("onclick", str);//第7列是删除（从0开始计数）
                }
                //先设置当鼠标上去的时候他的背景色改变
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#83A5CA'");
                //再设置当鼠标离开后背景色再还原
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label labBookId = GridView1.Rows[e.RowIndex].FindControl("labBookId") as Label;
            string bookId = labBookId.Text;
            EleServiceReference.EleServiceSoapClient ws1 = new EleServiceReference.EleServiceSoapClient("EleServiceSoap");
            if (ws1.DeleteBookinfoByBookId(bookId))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s1", "alert('删除成功！');", true);
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s1", "alert('删除失败！');", true);
        }
    }
}