using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class GoodCondition : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind0();
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bind();
        }

        protected void bind0()
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            Good good = new Good();
            GoodConditionInfo goodCon = new GoodConditionInfo();
            good.goodName = txtName.Text;
            good.kind = ddlKind.Text;
            goodCon.condition = ddlCondition.Text;

            DataTable dt = GetDataSource0(good, goodCon);
            if (dt.Rows.Count > 0)
            {

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        public DataTable GetDataSource0(Good good, GoodConditionInfo goodCon)
        {
            //get
            {
                string id = Session["shopId"].ToString();
                DataTable dt = new DataTable();
                dt.Columns.Add("goodId", typeof(string));
                dt.Columns.Add("shopName", typeof(string));
                dt.Columns.Add("goodName", typeof(string));
                dt.Columns.Add("kind", typeof(string));
                dt.Columns.Add("price", typeof(string));
                dt.Columns.Add("condition", typeof(string));
                //调用服务获取用户信息   
                EleServiceReference.EleServiceSoapClient ws1 = new EleServiceReference.EleServiceSoapClient("EleServiceSoap");
                if (ws1.GetAllGoodInfo(id) != null)
                {
                    string[] goodlist = ws1.GetAllGoodInfo(id).ToArray();
                    for (int i = 0; i < goodlist.Length; i += 6)//6个信息是一个记录
                    {
                        dt.Rows.Add(goodlist[i], goodlist[i + 1], goodlist[i + 2], goodlist[i + 3], goodlist[i + 4], goodlist[i + 5]);

                    }
                }
                else ScriptManager.RegisterStartupScript(this, this.GetType(), "s2", "alert('您搜索的商品信息不存在！');", true);
                return dt;
            }
        }

        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            bind();
        }

        protected void bind()
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            Good good = new Good();
            GoodConditionInfo goodCon = new GoodConditionInfo();
            good.goodName = txtName.Text;
            good.kind = ddlKind.Text;
            goodCon.condition = ddlCondition.Text;

            DataTable dt = GetDataSource(good, goodCon);
            if (dt.Rows.Count > 0)
            {

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        public DataTable GetDataSource(Good good, GoodConditionInfo goodCon)
        {
            //get
            {
                string id = Session["shopId"].ToString();
                DataTable dt = new DataTable();
                dt.Columns.Add("goodId", typeof(string));
                dt.Columns.Add("shopName", typeof(string));
                dt.Columns.Add("goodName", typeof(string));
                dt.Columns.Add("kind", typeof(string));
                dt.Columns.Add("price", typeof(string));
                dt.Columns.Add("condition", typeof(string));
                //调用服务获取用户信息   
                EleServiceReference.EleServiceSoapClient ws1 = new EleServiceReference.EleServiceSoapClient("EleServiceSoap");
                if (ws1.GetGoodInfoByCondition(good.goodName, good.kind, goodCon.condition, id) != null)
                {
                    string[] goodlist = ws1.GetGoodInfoByCondition(good.goodName, good.kind, goodCon.condition, id).ToArray();
                    for (int i = 0; i < goodlist.Length; i += 6)//6个信息是一个记录
                    {
                        dt.Rows.Add(goodlist[i], goodlist[i + 1], goodlist[i + 2], goodlist[i + 3], goodlist[i + 4], goodlist[i + 5]);

                    }
                }
                else ScriptManager.RegisterStartupScript(this, this.GetType(), "s2", "alert('您搜索的商品信息不存在！');", true);
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
                    Label labId = e.Row.FindControl("labId") as Label;
                    string goodId = labId.Text.Trim();
                    string url = "Showimage.aspx?goodId=" + goodId;
                    imgPhoto.ImageUrl = url;
                }
                //先设置当鼠标上去的时候他的背景色改变
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#83A5CA'");
                //再设置当鼠标离开后背景色再还原
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
            }
        }
        //进入编辑初始化程序
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Label labPrice = GridView1.Rows[e.NewEditIndex].FindControl("labPrice") as Label;
            Label labCondition = GridView1.Rows[e.NewEditIndex].FindControl("labCondition") as Label;
            Label labKind = GridView1.Rows[e.NewEditIndex].FindControl("labKind") as Label;
            GridView1.EditIndex = e.NewEditIndex;
            labRowIndex.Text = e.NewEditIndex.ToString();//保存修改的行号
            bind0();//刷新
            //状态绑定
            DropDownList ddlCondition1 = GridView1.Rows[e.NewEditIndex].FindControl("ddlCondition1") as DropDownList;
            ddlCondition1.Items.Clear();
            ddlCondition1.Items.Add("在售");
            ddlCondition1.Items.Add("缺货");
            ddlCondition1.Text = labCondition.Text;
            DropDownList ddlKind1 = GridView1.Rows[e.NewEditIndex].FindControl("ddlKind1") as DropDownList;
            ddlKind1.Items.Clear();
            ddlKind1.Items.Add("手机");
            ddlKind1.Items.Add("平板");
            ddlKind1.Items.Add("电脑");
            ddlKind1.Items.Add("相机");
            ddlKind1.Text = labKind.Text;
        }
        //更新程序
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //获取所有修改值
            TextBox txtId1 = GridView1.Rows[e.RowIndex].FindControl("txtId") as TextBox;
            TextBox txtShopName1 = GridView1.Rows[e.RowIndex].FindControl("txtShopName") as TextBox;
            TextBox txtName1 = GridView1.Rows[e.RowIndex].FindControl("txtName") as TextBox;
            DropDownList ddlKind1 = GridView1.Rows[e.RowIndex].FindControl("ddlKind1") as DropDownList;
            TextBox txtPrice1 = GridView1.Rows[e.RowIndex].FindControl("txtPrice") as TextBox;
            DropDownList ddlCondition1 = GridView1.Rows[e.RowIndex].FindControl("ddlCondition1") as DropDownList;
            FileUpload UploadPhoto1 = GridView1.Rows[e.RowIndex].FindControl("uploadPhoto") as FileUpload;

            Good good = new Good();
            GoodConditionInfo goodCon = new GoodConditionInfo();
            good.goodId = txtId1.Text;
            good.shopName = txtShopName1.Text;
            good.goodName = txtName1.Text;
            good.kind = ddlKind1.Text;
            good.price = txtPrice1.Text;
            goodCon.condition = ddlCondition1.Text;
            good.photo = Convert.ToBase64String(UploadPhoto1.FileBytes);//将图片字节转换成图片字符串;

            EleServiceReference.EleServiceSoapClient ws1 = new EleServiceReference.EleServiceSoapClient("EleServiceSoap");
            if (ws1.UpdateGoodInfoByGoodId(good.goodId, good.price, good.photo) && ws1.UpdateGoodConditionInfoByGoodId(good.goodId, goodCon.condition))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s1", "alert('修改成功！');", true);
                GridView1.EditIndex = -1;//取消编辑
                bind0();
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s1", "alert('修改失败！');", true);

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;//取消编辑
            bind0();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            if (btnNew.Text == "新增")
            {
                GridView1.ShowFooter = true;
                GridView1.PageIndex = GridView1.PageCount;
                bind();
                btnNew.Text = "取消新增";
                DropDownList ddlKind2 = GridView1.FooterRow.FindControl("ddlKind2") as DropDownList;
                DropDownList ddlCondition2 = GridView1.FooterRow.FindControl("ddlCondition2") as DropDownList;
            }
            else
            {
                btnNew.Text = "新增";
                GridView1.ShowFooter = false;
                bind0();
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string id = Session["shopId"].ToString();
            //获取所有修改值
            TextBox txtId2 = GridView1.FooterRow.FindControl("txtId") as TextBox;
            TextBox txtShopName2 = GridView1.FooterRow.FindControl("txtShopName") as TextBox;
            TextBox txtName2 = GridView1.FooterRow.FindControl("txtName") as TextBox;
            DropDownList ddlKind2 = GridView1.FooterRow.FindControl("ddlKind2") as DropDownList;
            TextBox txtPrice2 = GridView1.FooterRow.FindControl("txtPrice") as TextBox;
            DropDownList ddlCondition2 = GridView1.FooterRow.FindControl("ddlCondition2") as DropDownList;
            FileUpload UploadPhoto2 = GridView1.FooterRow.FindControl("uploadPhoto") as FileUpload;

            Good good = new Good();
            GoodConditionInfo goodCon = new GoodConditionInfo();

            txtShopName2.Text = id;
            good.shopName = txtShopName2.Text;
            good.goodName = txtName2.Text;
            good.kind = ddlKind2.Text;
            good.price = txtPrice2.Text;
            goodCon.condition = ddlCondition2.Text;
            good.photo = Convert.ToBase64String(UploadPhoto2.FileBytes);//将图片字节转换成图片字符串;

            EleServiceReference.EleServiceSoapClient ws1 = new EleServiceReference.EleServiceSoapClient("EleServiceSoap");


            Random ra = new Random(unchecked((int)DateTime.Now.Ticks));
            int[] goodIdlist = ws1.GetAllGoodId().ToArray();
            int tmp = 0;
            int minValue = 100;
            int maxValue = 999;
            int goodId1 = 0;
            for (int i = 0; i < 900; i++)
            {
                tmp = ra.Next(minValue, maxValue); //随机取数
                goodId1 = getNum(goodIdlist, tmp, minValue, maxValue, ra); //取出值赋到数组中
            }

            txtId2.Text = Convert.ToString(goodId1);
            good.goodId = txtId2.Text;

            if ((ws1.InsertGoodInfo(good.goodId, good.price, good.goodName, good.kind, good.shopName, good.photo)) && (ws1.InsertGoodConditionInfo(good.goodId, goodCon.condition)))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s1", "alert('保存成功！');", true);
                bind0();
                ddlKind2 = GridView1.FooterRow.FindControl("ddlKind2") as DropDownList;
                ddlCondition2 = GridView1.FooterRow.FindControl("ddlCondition2") as DropDownList;
                /*ddlCondition2.Items.Add("在售");
                ddlCondition2.Items.Add("缺货");
                ddlKind2.Items.Add("手机");
                ddlKind2.Items.Add("平板");
                ddlKind2.Items.Add("电脑");
                ddlKind2.Items.Add("相机");*/
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s1", "alert('保存失败！');", true);

        }
        public int getNum(int[] goodIdlist, int tmp, int minValue, int maxValue, Random ra)
        {
            int n = 0;
            while (n <= goodIdlist.Length - 1)
            {
                if (goodIdlist[n] == tmp) //利用循环判断是否有重复
                {
                    tmp = ra.Next(minValue, maxValue); //重新随机获取。
                    getNum(goodIdlist, tmp, minValue, maxValue, ra);//递归:如果取出来的数字和已取得的数字有重复就重新随机获取。
                }
                n++;
            }
            return tmp;
        }
    }
}