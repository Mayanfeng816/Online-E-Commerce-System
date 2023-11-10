using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.ServiceReference1;
namespace WebApplication2
{
    public partial class GoodDetail : System.Web.UI.Page
    {
        string goodId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["goodId"] == null) return;
            goodId = Request["goodId"].ToString();
            GoodsServiceSoapClient ws1 = new GoodsServiceSoapClient("GoodsServiceSoap");
            string[] kind = ws1.GetGoodKindById(goodId).ToArray();
            LabKind.Text = kind[0];
            string[] goodInfo = ws1.GetGoodById(goodId).ToArray();
            LabShop.Text = goodInfo[2];
            LabName.Text = goodInfo[1];
            LabPrice.Text = goodInfo[0];
            ImgGood.ImageUrl = "showimage.aspx?goodId=" + goodId;
            if (!IsPostBack)
            {
                CheckShop.Checked = ws1.isFavShop(LabShop.Text, Session["Username"].ToString());
                bool tem = ws1.isFavGood(goodId, Session["Username"].ToString());
                if (tem)
                    BtnFav.Text = "已收藏";
                tem = ws1.isOnCart(goodId, Session["Username"].ToString());
                if (tem)
                    BtnCart.Text = "已加购物车";
            }
            bool isSale = Convert.ToBoolean(ws1.isSale(goodId));
            if (isSale)
                BtnPay.Attributes.Add("onclick", "javascript:return confirm('你确定要购买该商品吗？')");
            else
            {
                BtnPay.Text = "缺货";
                BtnPay.Enabled = false;
            }

        }


        protected void CheckShop_CheckedChanged(object sender, EventArgs e)
        {
            GoodsServiceSoapClient ws1 = new GoodsServiceSoapClient("GoodsServiceSoap");

            if (CheckShop.Checked)
            {
                ws1.InsertFavShop(LabShop.Text, Session["Username"].ToString());

            }
            else
            {
                ws1.DeleteFavShop(LabShop.Text, Session["Username"].ToString());
            }
        }

        protected void Btnsub_Click(object sender, EventArgs e)
        {
            int count = int.Parse(LabCount.Text);
            if (count > 1)
                count--;
            LabCount.Text = "" + count;
        }

        protected void Btnplus_Click(object sender, EventArgs e)
        {
            int count = int.Parse(LabCount.Text);
            count++;
            LabCount.Text = "" + count;
        }

        protected void BtnFav_Click(object sender, EventArgs e)
        {
            GoodsServiceSoapClient ws1 = new GoodsServiceSoapClient("GoodsServiceSoap");
            if (BtnFav.Text.Equals("收藏商品"))
            {
                BtnFav.Text = "已收藏";
                bool tem = ws1.InsertFavGood(goodId, Session["Username"].ToString());
                if (!tem)
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "s2", "alert('收藏失败！');", true);

            }
            else
            {
                BtnFav.Text = "收藏商品";
                bool tem = ws1.DeleteFavGood(goodId, Session["Username"].ToString());
                if (!tem)
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "s2", "alert('操作失败！');", true);
            }
        }

        protected void BtnCart_Click(object sender, EventArgs e)
        {
            GoodsServiceSoapClient ws1 = new GoodsServiceSoapClient("GoodsServiceSoap");
            if (BtnCart.Text.Equals("加入购物车"))
            {
                BtnCart.Text = "已在购物车";
                bool tem = ws1.InsertCart(goodId, Session["Username"].ToString(), LabCount.Text);
                if (!tem)
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "s2", "alert('加入购物车失败！');", true);
            }
            else
            {
                BtnCart.Text = "加入购物车";
                bool tem = ws1.DeleteCart(goodId, Session["Username"].ToString());
                if (!tem)
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "s2", "alert('操作失败！');", true);
            }
        }

        protected void BtnPay_Click(object sender, EventArgs e)
        {
            GoodsServiceSoapClient ws1 = new GoodsServiceSoapClient("GoodsServiceSoap");
            string bookId = System.Guid.NewGuid().ToString("N");
            string nowDate = DateTime.Now.ToString("yyyy-MM-dd");
            if (ws1.InsertBookInfo(bookId, goodId, LabCount.Text, "待发货", Session["Username"].ToString(), TxtAdress.Text, nowDate))
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s2", "alert('购买成功！');", true);
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s2", "alert('操作失败！');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "s2", "HideBlock();", true);

        }
    }
}