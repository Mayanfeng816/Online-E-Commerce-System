using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebApplication2
{
    public partial class GoodSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

        //绑定数据
        protected void bind1()
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            DataTable dt = GetDataSource1();
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        public DataTable GetDataSource1()
        {
            //get
            DataTable dt = new DataTable();
            dt.Columns.Add("goodDetailurl1", typeof(string));
            dt.Columns.Add("imgurl1", typeof(string));
            dt.Columns.Add("name1", typeof(string));
            dt.Columns.Add("price1", typeof(string));
            dt.Columns.Add("goodDetailurl2", typeof(string));
            dt.Columns.Add("imgurl2", typeof(string));
            dt.Columns.Add("name2", typeof(string));
            dt.Columns.Add("price2", typeof(string));
            dt.Columns.Add("goodDetailurl3", typeof(string));
            dt.Columns.Add("imgurl3", typeof(string));
            dt.Columns.Add("name3", typeof(string));
            dt.Columns.Add("price3", typeof(string));
            dt.Columns.Add("goodDetailurl4", typeof(string));
            dt.Columns.Add("imgurl4", typeof(string));
            dt.Columns.Add("name4", typeof(string));
            dt.Columns.Add("price4", typeof(string));
            dt.Columns.Add("goodDetailurl5", typeof(string));
            dt.Columns.Add("imgurl5", typeof(string));
            dt.Columns.Add("name5", typeof(string));
            dt.Columns.Add("price5", typeof(string));
            //调用服务获取商品信息   
            EleServiceReference.EleServiceSoapClient ws1 = new EleServiceReference.EleServiceSoapClient("EleServiceSoap");
            String[] goodlist = ws1.GoodSearchGetSomeGoodInfo().ToArray();
            if (goodlist == null)
            {
                return dt;
            }
            int k = goodlist.Length % 15;
            for (int i = 0; i < goodlist.Length - k; i += 15)
            {
                string goodDetail1 = "GoodDetail.aspx?goodId=" + goodlist[i];
                string goodDetail2 = "GoodDetail.aspx?goodId=" + goodlist[i + 3];
                string goodDetail3 = "GoodDetail.aspx?goodId=" + goodlist[i + 6];
                string goodDetail4 = "GoodDetail.aspx?goodId=" + goodlist[i + 9];
                string goodDetail5 = "GoodDetail.aspx?goodId=" + goodlist[i + 12];
                string imgurl1 = "showimage.aspx?goodId=" + goodlist[i];
                string imgurl2 = "showimage.aspx?goodId=" + goodlist[i + 3];
                string imgurl3 = "showimage.aspx?goodId=" + goodlist[i + 6];
                string imgurl4 = "showimage.aspx?goodId=" + goodlist[i + 9];
                string imgurl5 = "showimage.aspx?goodId=" + goodlist[i + 12];
                dt.Rows.Add(goodDetail1, imgurl1, goodlist[i + 2], goodlist[i + 1],
                            goodDetail2, imgurl2, goodlist[i + 5], goodlist[i + 4],
                            goodDetail3, imgurl3, goodlist[i + 8], goodlist[i + 7],
                            goodDetail4, imgurl4, goodlist[i + 11], goodlist[i + 10],
                            goodDetail5, imgurl5, goodlist[i + 14], goodlist[i + 13]);
            }
            return dt;

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bind2();
        }
        protected void bind2()
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            Good good = new Good();
            Book book = new Book();
            string input = txtInput.Value;
            DataTable dt = GetDataSource2(input);
            if (dt.Rows.Count > 0)
            {

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        public DataTable GetDataSource2(string input)
        {
            //get
            DataTable dt = new DataTable();
            dt.Columns.Add("goodDetailurl1", typeof(string));
            dt.Columns.Add("imgurl1", typeof(string));
            dt.Columns.Add("name1", typeof(string));
            dt.Columns.Add("price1", typeof(string));
            dt.Columns.Add("goodDetailurl2", typeof(string));
            dt.Columns.Add("imgurl2", typeof(string));
            dt.Columns.Add("name2", typeof(string));
            dt.Columns.Add("price2", typeof(string));
            dt.Columns.Add("goodDetailurl3", typeof(string));
            dt.Columns.Add("imgurl3", typeof(string));
            dt.Columns.Add("name3", typeof(string));
            dt.Columns.Add("price3", typeof(string));
            dt.Columns.Add("goodDetailurl4", typeof(string));
            dt.Columns.Add("imgurl4", typeof(string));
            dt.Columns.Add("name4", typeof(string));
            dt.Columns.Add("price4", typeof(string));
            dt.Columns.Add("goodDetailurl5", typeof(string));
            dt.Columns.Add("imgurl5", typeof(string));
            dt.Columns.Add("name5", typeof(string));
            dt.Columns.Add("price5", typeof(string));
            //调用服务获取商品信息   
            EleServiceReference.EleServiceSoapClient ws1 = new EleServiceReference.EleServiceSoapClient("EleServiceSoap");
            String[] goodlist = ws1.GoodSearchGetSomeGoodByInput(input).ToArray();
            if (goodlist == null)
            {
                return dt;
            }
            int k = goodlist.Length % 15;
            for (int i = 0; i < goodlist.Length - k; i += 15)
            {
                string goodDetail1 = "GoodDetail.aspx?goodId=" + goodlist[i];
                string goodDetail2 = "GoodDetail.aspx?goodId=" + goodlist[i + 3];
                string goodDetail3 = "GoodDetail.aspx?goodId=" + goodlist[i + 6];
                string goodDetail4 = "GoodDetail.aspx?goodId=" + goodlist[i + 9];
                string goodDetail5 = "GoodDetail.aspx?goodId=" + goodlist[i + 12];
                string imgurl1 = "showimage.aspx?goodId=" + goodlist[i];
                string imgurl2 = "showimage.aspx?goodId=" + goodlist[i + 3];
                string imgurl3 = "showimage.aspx?goodId=" + goodlist[i + 6];
                string imgurl4 = "showimage.aspx?goodId=" + goodlist[i + 9];
                string imgurl5 = "showimage.aspx?goodId=" + goodlist[i + 12];
                dt.Rows.Add(goodDetail1, imgurl1, goodlist[i + 2], goodlist[i + 1],
                            goodDetail2, imgurl2, goodlist[i + 5], goodlist[i + 4],
                            goodDetail3, imgurl3, goodlist[i + 8], goodlist[i + 7],
                            goodDetail4, imgurl4, goodlist[i + 11], goodlist[i + 10],
                            goodDetail5, imgurl5, goodlist[i + 14], goodlist[i + 13]);
            }
            return dt;
        }
    }
}