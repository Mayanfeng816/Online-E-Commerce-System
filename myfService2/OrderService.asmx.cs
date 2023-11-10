using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
namespace myfService2
{
    /// <summary>
    /// Summary description for OrderService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/OrderService")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class OrderService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<string> GetAllBookInfoByCondition(string shopname, string time, string goodName)
        {
            string sql = "select bookId,userId,goodName,count,price,address,time from Book,Good where Good.goodId = Book.goodId and status = '待发货' and shopname=" + "'" + shopname + "'";

            if (time != null && (!time.Equals("")))
                sql += ("and time >='" + time + "'");
            if (goodName != null && (!goodName.Equals("")))
                sql += ("and goodName = '" + goodName + "'");
            DataTable dt = OperatorDB.GetDataTable(sql);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["bookId"].ToString());
                    list.Add(dt.Rows[i]["userId"].ToString());
                    list.Add(dt.Rows[i]["goodName"].ToString());
                    list.Add(dt.Rows[i]["count"].ToString());
                    list.Add(dt.Rows[i]["price"].ToString());
                    list.Add(dt.Rows[i]["address"].ToString());
                    list.Add(dt.Rows[i]["time"].ToString());
                }
                return list;
            }
            return null;
        }

        //退款
        [WebMethod]
        public bool UpdateBookInfo(string bookId, string status)
        {
            string sqlstr = "update Book set status = '" + status + "' where bookId='" + bookId + "'";
            return OperatorDB.ExecCmd(sqlstr);

        }

        [WebMethod]
        public List<string> GetGoodByShop(string shopname)
        {
            string sql = "select goodName from Good where shopname = '" + shopname + "'";
            DataTable dt = OperatorDB.GetDataTable(sql);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["goodName"].ToString());
                }
                return list;
            }
            return null;
        }

        [WebMethod]
        public List<string> GetGoodInfoByShop(string shopname)
        {
            string sql = "select goodId,goodName from Good where shopname = '" + shopname + "'";
            DataTable dt = OperatorDB.GetDataTable(sql);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["goodId"].ToString());
                    list.Add(dt.Rows[i]["goodName"].ToString());
                }
                return list;
            }
            return null;
        }

        [WebMethod]
        public List<string> GetHotGoodByShop(string shopname, string time)
        {
            string sql = "select goodName,totalcount from (select goodId, sum(cast(count as decimal)) totalcount from Book where goodId in (select goodId from Good where shopName = '" + shopname + "') and time>= '" + time + "' group by goodId) t1 left join Good t2 on t1.goodId = t2.goodId order by totalcount desc";
            DataTable dt = OperatorDB.GetDataTable(sql);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["goodName"].ToString());
                    list.Add(dt.Rows[i]["totalcount"].ToString());
                }
                return list;
            }
            return null;
        }

        [WebMethod]
        public List<string> GetBookTrendByGood(string time, string goodId)
        {
            string sql = "select CONVERT(varchar(10),time,111) time,sum(cast(count as decimal)) totalcount from Book where goodId='" + goodId + "' and time>='" + time + "' group by CONVERT(varchar(10),time,111)";
            DataTable dt = OperatorDB.GetDataTable(sql);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["time"].ToString());
                    list.Add(dt.Rows[i]["totalcount"].ToString());
                }
                return list;
            }
            return null;
        }

        [WebMethod]
        public List<string> GetSaleByCondition(string shopname, string time, string condition)
        {
            string sql = "";
            if (condition.Equals("week"))
                sql += "select CONVERT(varchar(10),time,111) time,SUM(tp) totalprice from(select time, (CAST(count as decimal) * CAST(price as decimal)) tp from Book t1 right join (select goodId, price from Good where shopName = '" + shopname + "') t2 on t1.goodId = t2.goodId where time>= '" + time + "') t3 group by CONVERT(varchar(10),time,111)";
            else if (condition.Equals("month"))
                sql += "select CONVERT(varchar(7),time,111) time,SUM(tp) totalprice from(select time, (CAST(count as decimal) * CAST(price as decimal)) tp from Book t1 right join (select goodId, price from Good where shopName = '" + shopname + "') t2 on t1.goodId = t2.goodId where time>= '" + time + "') t3 group by CONVERT(varchar(7),time,111)";
            DataTable dt = OperatorDB.GetDataTable(sql);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["time"].ToString());
                    list.Add(dt.Rows[i]["totalprice"].ToString());
                }
                return list;
            }
            return null;
        }
    }
}
