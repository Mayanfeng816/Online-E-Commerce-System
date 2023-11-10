using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebApplication2
{
    public partial class FavoriteShop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Bind();
        }

        public DataTable GetDataSource()
        {
            string id = Session["Username"].ToString();
            //get
            DataTable dt = new DataTable();
            dt.Columns.Add("favoriteShopName", typeof(string));
            //调用服务获取用户信息   
            EleServiceReference.EleServiceSoapClient ws1 = new EleServiceReference.EleServiceSoapClient("EleServiceSoap");
            if (ws1.GetAllFavoriteShopInfo(id) == null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s1", "alert('信息不存在！');", true);
            }
            else
            {
                string[] favoriteShopList = ws1.GetAllFavoriteShopInfo(id).ToArray();
                for (int i = 0; i < favoriteShopList.Length; i += 1)
                {
                    dt.Rows.Add(favoriteShopList[i]);
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
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    Label labfavoriteShopName = e.Row.FindControl("labfavoriteShopName") as Label;
                    string favoriteShopName = labfavoriteShopName.Text;
                    string str = "javascript:return confirm('你确认要移除收藏的店铺 “ " + favoriteShopName + " ” 吗?')";
                    e.Row.Cells[1].Attributes.Add("onclick", str);
                }
                //先设置当鼠标上去的时候他的背景色改变
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='rgb(140,172,232)'");
                //再设置当鼠标离开后背景色再还原
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
            }


        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label labfavoriteShopName = GridView1.Rows[e.RowIndex].FindControl("labfavoriteShopName") as Label;
            string favoriteShopName = labfavoriteShopName.Text;
            string id = Session["Username"].ToString();
            EleServiceReference.EleServiceSoapClient ws1 = new EleServiceReference.EleServiceSoapClient("EleServiceSoap");
            if (ws1.DeleteFavoriteShop(id, favoriteShopName))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s1", "alert('删除成功！');", true);
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s1", "alert('删除失败！');", true);

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
            dt.Columns.Add("favoriteShopName", typeof(string));
            //调用服务获取用户信息   
            EleServiceReference.EleServiceSoapClient ws1 = new EleServiceReference.EleServiceSoapClient("EleServiceSoap");

            if (ws1.GetShopByCondition(id, txtSearch.Text.ToString()) != null)
            {
                string[] favoriteShopList = ws1.GetShopByCondition(id, txtSearch.Text.ToString()).ToArray();
                for (int i = 0; i < favoriteShopList.Length; i += 1)
                {
                    dt.Rows.Add(favoriteShopList[i]);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s2", "alert('您搜索的店铺信息不存在！');", true);
                Bind();
            }
            return dt;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
    }
}