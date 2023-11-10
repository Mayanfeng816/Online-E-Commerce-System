using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.OrderService;
namespace WebApplication2
{
    public partial class DataStatistics : System.Web.UI.Page
    {
        public string title;
        public string legend;
        public string x_title;
        public string y_title;
        public int x_count;
        public int y_count;
        public String[] x_values = new String[] { "1月", "2月", "3月", "4月", "5月" };//获取X轴的值;
        public double [] y_values = new double[] { 0, 0, 0, 0, 0 };//获取Y轴的值;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlCondition1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string condition1 = ddlCondition1.Text;
            ddlCondition2.Items.Clear();
            switch (condition1)
            {
                case "热销商品":
                    ddlCondition2.Items.Add("今日内");
                    ddlCondition2.Items.Add("一周内");
                    ddlCondition2.Items.Add("一月内");
                    ddlCondition2.Items.Add("一季度内");
                    ddlCondition2.Items.Add("半年内");
                    break;
                case "商品销量":
                    OrderServiceSoapClient ws1 = new OrderServiceSoapClient("OrderServiceSoap");
                    string[] goodlist = ws1.GetGoodByShop(Session["shopId"].ToString()).ToArray();//TODO修改成session
                    for(int i = 0; i < goodlist.Length; i++)
                    {
                        ddlCondition2.Items.Add(goodlist[i]);
                    }
                    break;
                case "销售额":
                    ddlCondition2.Items.Add("一周内");
                    ddlCondition2.Items.Add("半年内");
                    break;
            }
                
        }

        protected void BtnDisplay_Click(object sender, EventArgs e)
        {
            string condition1 = ddlCondition1.Text;
            string shopname = Session["shopId"].ToString();//TODO修改成session
            OrderServiceSoapClient ws1 = new OrderServiceSoapClient("OrderServiceSoap");
            switch (condition1)
            {
                case "热销商品":
                    title = "热销商品图";
                    DateTime now = DateTime.Now;
                    string time = "";
                    switch (ddlCondition2.Text)
                    {
                        case "今日内":
                            time = now.ToString("yyyy-MM-dd");
                            break;
                        case "一周内":
                            time = now.AddDays(-7).ToString("yyyy-MM-dd");
                            break;
                        case "一月内":
                            time = now.AddMonths(-1).ToString("yyyy-MM-dd");
                            break;
                        case "一季度内":
                            time = now.AddMonths(-3).ToString("yyyy-MM-dd");
                            break;
                        case "半年内":
                            time = now.AddMonths(-6).ToString("yyyy-MM-dd");
                            break;
                    }
                    if(ws1.GetHotGoodByShop(shopname,time)!=null)
                    {
                        string[] goodInfo = ws1.GetHotGoodByShop(shopname, time).ToArray();
                        int size = goodInfo.Length / 2;
                        x_values = new string[size];
                        y_values = new double[size];
                        for (int i = 0; i < goodInfo.Length; i += 2)
                        {
                            x_values[i / 2] = goodInfo[i];
                            y_values[i / 2] = double.Parse(goodInfo[i + 1]);
                        }
                        x_count = size;
                        x_title = "商品";
                        y_title = "销量";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "s2", "barChart()", true);

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "s2", "alert('当前暂无数据！');", true);
                    }
                    break;
                case "商品销量":
                    string[] goodlist = ws1.GetGoodInfoByShop(shopname).ToArray();
                    string goodName = ddlCondition2.Text;
                    string goodId = "";
                    for (int i = 0; i < goodlist.Length; i+=2)
                    {
                        if (goodName.Equals(goodlist[i + 1]))
                        {
                            goodId = goodlist[i];
                            break;
                        }      
                    }
                    if(ws1.GetBookTrendByGood(DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd"), goodId) != null)
                    {
                        DateTime startTime = DateTime.Now.AddMonths(-1);
                        string[] bookInfolist = ws1.GetBookTrendByGood(startTime.ToString("yyyy-MM-dd"), goodId).ToArray();
                        int size = DateTime.Now.Subtract(startTime).Days + 1;
                        x_values = new string[size];
                        y_values = new double[size];
                        int j = 0;
                        //将获取到的日期和销量值装入x,y轴
                        for(int i = 0; i < size; i++)
                        {
                            string ttime = startTime.AddDays(i).ToString("yyyy-MM-dd");
                            if (j < bookInfolist.Length)
                            {
                                string[] date = bookInfolist[j].Split('/');
                                DateTime temptime = new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2]));
                                if(startTime.AddDays(i).Subtract(temptime).Days==0)
                                {
                                    x_values[i] = bookInfolist[j];
                                    y_values[i] = double.Parse(bookInfolist[j + 1]);
                                    j += 2;
                                }
                                else
                                {
                                    x_values[i] = ttime;
                                    y_values[i] = 0;
                                }
                            }
                            else
                            {
                                x_values[i] = ttime;
                                y_values[i] = 0;
                            }
                            
                        }
                        x_count = size;
                        x_title = "日期";
                        y_title = "销量";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "s2", "lineChart()", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "s2", "alert('当前暂无数据！');", true);
                    }
                    break;
                case "销售额":
                    switch (ddlCondition2.Text)
                    {
                        
                        case "一周内":
                            DateTime temp = DateTime.Now.AddDays(-6);
                            if (ws1.GetSaleByCondition(shopname, temp.ToString("yyyy-MM-dd"), "week") != null) {
                                string[] saleInfolist = ws1.GetSaleByCondition(shopname, temp.ToString("yyyy-MM-dd"), "week").ToArray();
                                title = "一周内销售额统计图";
                                int size = saleInfolist.Length / 2;
                                x_values = new string[size];
                                y_values = new double[size];
                                for(int i = 0; i < saleInfolist.Length; i+=2)
                                {
                                    x_values[i / 2] = saleInfolist[i];
                                    y_values[i / 2] = double.Parse(saleInfolist[i + 1]);
                                }
                                x_count = size;
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "s2", "pieChart()", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "s2", "alert('当前暂无数据！');", true);
                            }
                            break;
                        case "半年内":
                            DateTime temp1 = DateTime.Now.AddMonths(-6);
                            if (ws1.GetSaleByCondition(shopname, temp1.ToString("yyyy-MM-dd"), "month") != null)
                            {
                                string[] saleInfolist = ws1.GetSaleByCondition(shopname, temp1.ToString("yyyy-MM-dd"), "month").ToArray();
                                title = "半年内销售额统计图";
                                int size = saleInfolist.Length / 2;
                                x_values = new string[size];
                                y_values = new double[size];
                                for (int i = 0; i < saleInfolist.Length; i += 2)
                                {
                                    x_values[i / 2] = saleInfolist[i];
                                    y_values[i / 2] = double.Parse(saleInfolist[i + 1]);
                                }
                                x_count = size;
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "s2", "pieChart()", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "s2", "alert('当前暂无数据！');", true);
                            }
                            break;
                       
                    }
                    break;
            }
        }
    }
}