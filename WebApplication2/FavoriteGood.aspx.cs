using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebApplication2
{
    public partial class FavoriteGood : System.Web.UI.Page
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
            //调用服务获取用户信息   
            EleServiceReference.EleServiceSoapClient ws1 = new EleServiceReference.EleServiceSoapClient("EleServiceSoap");
            if (ws1.GetAllFavoriteGoodInfo(id) == null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s1", "alert('信息不存在！');", true);
            }
            else
            {
                string[] favoriteGoodList = ws1.GetAllFavoriteGoodInfo(id).ToArray();
                for (int i = 0; i < favoriteGoodList.Length; i += 5)
                {
                    dt.Rows.Add(favoriteGoodList[i], favoriteGoodList[i + 1], favoriteGoodList[i + 2], favoriteGoodList[i + 3], favoriteGoodList[i + 4]);
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
                    string str = "javascript:return confirm('你确认要移除收藏的商品 “ " + goodName + " ” 吗?')";
                    e.Row.Cells[7].Attributes.Add("onclick", str);
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
            if (ws1.DeleteFavoriteGood(id, goodId))
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

        protected void btnFavoriteGood_Click(object sender, EventArgs e)
        {
            Response.Redirect("FavoriteGood.aspx");
        }

        protected void btnFavoriteShop_Click(object sender, EventArgs e)
        {
            Response.Redirect("FavoriteShop.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Search()
        {
            GridView1.DataSource = null;
            GridView1.DataBind();

            DataTable dt = GetSearchSource();
            if (dt.Rows.Count > 0)
            {

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        public DataTable GetSearchSource()
        {
            string id = Session["Username"].ToString();
            //get
            DataTable dt = new DataTable();
            dt.Columns.Add("goodId", typeof(string));
            dt.Columns.Add("goodName", typeof(string));
            dt.Columns.Add("shopName", typeof(string));
            dt.Columns.Add("price", typeof(string));
            dt.Columns.Add("kind", typeof(string));
            //调用服务获取用户信息   
            EleServiceReference.EleServiceSoapClient ws1 = new EleServiceReference.EleServiceSoapClient("EleServiceSoap");

            if (ws1.GetGoodByCondition(id, txtSearch.Text.ToString()) != null)
            {
                string[] favoriteGoodList = ws1.GetGoodByCondition(id, txtSearch.Text.ToString()).ToArray();
                for (int i = 0; i < favoriteGoodList.Length; i += 5)
                {
                    dt.Rows.Add(favoriteGoodList[i], favoriteGoodList[i + 1], favoriteGoodList[i + 2], favoriteGoodList[i + 3], favoriteGoodList[i + 4]);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s2", "alert('您搜索的商品信息不存在！');", true);
                Bind();
            }
            return dt;
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        protected void btnaddCart_Click(object sender, EventArgs e)
        {
            string id = Session["Username"].ToString();
            EleServiceReference.EleServiceSoapClient ws1 = new EleServiceReference.EleServiceSoapClient("EleServiceSoap");
            Button btn = sender as Button;
            if (btn != null)
            {
                //两个Parent就可以得到GridviewRow对象 
                GridViewRow row = btn.Parent.Parent as GridViewRow;

                Label labgoodId = row.FindControl("labGoodId") as Label;
                string goodId = labgoodId.Text.ToString();
                ws1.FavoriteGoodtoCart(id, goodId);
            }
            Bind();
        }
    }
}