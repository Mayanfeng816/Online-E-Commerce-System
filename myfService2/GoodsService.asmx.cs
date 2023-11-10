using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

namespace myfService2
{
    /// <summary>
    /// Summary description for GoodsService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/GoodsService")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class GoodsService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public List<string> GetGoodById(string id)
        {
            string sql = "select price,goodName,shopName from Good where goodId='" + id + "'";
            DataTable dt = OperatorDB.GetDataTable(sql);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                list.Add(dt.Rows[0]["price"].ToString());
                list.Add(dt.Rows[0]["goodName"].ToString());
                list.Add(dt.Rows[0]["shopName"].ToString());
                return list;
            }
            return null;
        }

        [WebMethod]
        public List<string> GetGoodPhotoById(string id)
        {
            string sql = "select photo from Good where goodId='" + id + "'";
            DataTable dt = OperatorDB.GetDataTable(sql);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                list.Add(dt.Rows[0]["photo"].ToString());
                return list;
            }
            return null;
        }

        [WebMethod]
        public List<string> GetGoodKindById(string id)
        {
            string sql = "select kind from Good where goodId='" + id + "'";
            DataTable dt = OperatorDB.GetDataTable(sql);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                list.Add(dt.Rows[0]["kind"].ToString());
                return list;
            }
            return null;
        }

        [WebMethod]
        public bool InsertFavShop(string shopName, string userId)
        {
            string sqlstr = "insert into FavoriteShop values('" + shopName + "','" + userId + "')";
            return OperatorDB.ExecCmd(sqlstr);
        }

        [WebMethod]
        public bool DeleteFavShop(string shopName, string userId)
        {
            string sqlstr = "delete from FavoriteShop where favoriteShopName='" + shopName + "' and userId ='" + userId + "'";
            return OperatorDB.ExecCmd(sqlstr);
        }

        [WebMethod]
        public bool isFavShop(string shopName, string userId)
        {
            string sqlstr = "select * from FavoriteShop where favoriteShopName='" + shopName + "' and userId ='" + userId + "'";
            DataTable dt = OperatorDB.GetDataTable(sqlstr);
            if (dt.Rows.Count > 0) return true;
            return false;

        }

        [WebMethod]
        public List<string> GetUserInfoByUserId(string userId)//登录用
        {
            string sql = "select * from [Login] where userId='" + userId + "'";
            DataTable dt = OperatorDB.GetDataTable(sql);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                list.Add(dt.Rows[0]["userId"].ToString());
                list.Add(dt.Rows[0]["password"].ToString());
                return list;
            }
            return null;
        }

        [WebMethod]
        public bool InsertFavGood(string goodId, string userId)
        {
            string sqlstr = "insert into FavoriteGood values('" + goodId + "','" + userId + "')";
            return OperatorDB.ExecCmd(sqlstr);
        }

        [WebMethod]
        public bool DeleteFavGood(string goodId, string userId)
        {
            string sqlstr = "delete from FavoriteGood where favoriteGoodId='" + goodId + "' and userId ='" + userId + "'";
            return OperatorDB.ExecCmd(sqlstr);
        }

        [WebMethod]
        public bool isFavGood(string goodId, string userId)
        {
            string sqlstr = "select * from FavoriteGood where favoriteGoodId='" + goodId + "' and userId ='" + userId + "'";
            DataTable dt = OperatorDB.GetDataTable(sqlstr);
            if (dt.Rows.Count > 0) return true;
            return false;

        }

        [WebMethod]
        public bool InsertCart(string goodId, string userId, string count)
        {
            string sqlstr = "insert into Cart values('" + userId + "','" + goodId + "','" + count + "')";
            return OperatorDB.ExecCmd(sqlstr);
        }

        [WebMethod]
        public bool DeleteCart(string goodId, string userId)
        {
            string sqlstr = "delete from Cart where userId='" + userId + "' and goodId ='" + goodId + "'";
            return OperatorDB.ExecCmd(sqlstr);
        }

        [WebMethod]
        public bool isOnCart(string goodId, string userId)
        {
            string sqlstr = "select * from Cart where goodId='" + goodId + "' and userId ='" + userId + "'";
            DataTable dt = OperatorDB.GetDataTable(sqlstr);
            if (dt.Rows.Count > 0) return true;
            return false;

        }

        [WebMethod]
        public bool InsertBookInfo(string bookId, string goodId, string count, string status, string userId, string address, string time)
        {
            string sqlstr = "insert into Book values('" + bookId + "','" + goodId + "','" + count + "','" + status + "','" + userId + "','" + address + "','" + time + "')";
            return OperatorDB.ExecCmd(sqlstr);

        }

        [WebMethod]
        public List<String> GetSomeGoodInfoByParam(string param)
        {
            string sqlstr = "select TOP 100 goodId,price,goodName from Good";
            if (param.Equals("相机"))
                sqlstr += (" where kind = '" + param + "'");
            else if (param.Equals("手机"))
                sqlstr += (" where kind = '" + param + "'");
            else if (param.Equals("平板"))
                sqlstr += (" where kind = '" + param + "'");
            else if (param.Equals("电脑"))
                sqlstr += (" where kind = '" + param + "'");
            DataTable dt = OperatorDB.GetDataTable(sqlstr);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["goodId"].ToString());
                    list.Add(dt.Rows[i]["price"].ToString());
                    list.Add(dt.Rows[i]["goodName"].ToString());
                }
                return list;
            }
            return null;
        }

        [WebMethod]
        public bool isSale(string goodId)
        {
            string sqlstr = "select * from GoodCondition where goodId='" + goodId + "' and condition = '在售'";
            DataTable dt = OperatorDB.GetDataTable(sqlstr);
            if (dt.Rows.Count > 0) return true;
            return false;

        }
    
    }
}
