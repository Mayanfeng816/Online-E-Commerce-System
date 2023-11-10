using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace myfService2
{
    /// <summary>
    /// Summary description for EleService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EleService : System.Web.Services.WebService
    {

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
        public List<string> GetShopInfoByShopId(string shopId)//商家登录用
        {
            string sql = "select * from [ShopLogin] where shopId='" + shopId + "'";
            DataTable dt = OperatorDB.GetDataTable(sql);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                list.Add(dt.Rows[0]["shopId"].ToString());
                list.Add(dt.Rows[0]["password"].ToString());
                return list;
            }
            return null;
        }
        [WebMethod]
        public List<string> GetAdminInfoByAdminId(string AdminId)//Admin登录用
        {
            string sql = "select * from [AdminLogin] where AdminId='" + AdminId + "'";
            DataTable dt = OperatorDB.GetDataTable(sql);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                list.Add(dt.Rows[0]["AdminId"].ToString());
                list.Add(dt.Rows[0]["password"].ToString());
                return list;
            }
            return null;
        }
        [WebMethod]
        public bool DeleteUserInfo(string userId)
        {
            string sqlstr = "DELETE FROM [Login]  WHERE userId = '" + userId + "'";

            return OperatorDB.ExecCmd(sqlstr);
        }
        [WebMethod]//用户遍历，测试用
        public List<string> GetAllUserInfo()
        {
            string sql = "select * from [Login] ";
            DataTable dt = OperatorDB.GetDataTable(sql);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["userId"].ToString());
                    list.Add(dt.Rows[i]["password"].ToString());
                }
                return list;
            }
            return null;
        }
        [WebMethod]//注册
        public bool InsertUserInfo(string userId, string password)
        {
            string sqlstr = "INSERT INTO [Login]  (userId,password) VALUES ('" + userId + "','" + password + "')";
            return OperatorDB.ExecCmd(sqlstr);
        }
        [WebMethod]//注册
        public bool InsertShopInfo(string shopId, string password)
        {
            string sqlstr = "INSERT INTO [ShopLogin]  (shopId,password) VALUES ('" + shopId + "','" + password + "')";
            return OperatorDB.ExecCmd(sqlstr);
        }
        [WebMethod]//得到收藏的商品
        public List<string> GetAllFavoriteGoodInfo(string userId)
        {
            string sql = "select goodId,goodName,shopName,price,kind from [Good],[FavoriteGood] WHERE goodId = favoriteGoodId AND FavoriteGood.userId = "+"'"+userId+"'";
            DataTable dt = OperatorDB.GetDataTable(sql);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["goodId"].ToString());
                    list.Add(dt.Rows[i]["goodName"].ToString());
                    list.Add(dt.Rows[i]["shopName"].ToString());
                    list.Add(dt.Rows[i]["price"].ToString());
                    list.Add(dt.Rows[i]["kind"].ToString());
                }
                return list;
            }
            return null;
        }
        [WebMethod]//得到购物车的商品
        public List<string> GetCartInfo(string userId)
        {
            string sql = "select Cart.goodId,goodName,shopName,price,kind,count from [Good],[Cart] WHERE Good.goodId = Cart.GoodId AND Cart.userId = " + "'" + userId + "'";
            DataTable dt = OperatorDB.GetDataTable(sql);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["goodId"].ToString());
                    list.Add(dt.Rows[i]["goodName"].ToString());
                    list.Add(dt.Rows[i]["shopName"].ToString());
                    list.Add(dt.Rows[i]["price"].ToString());
                    list.Add(dt.Rows[i]["kind"].ToString());
                    list.Add(dt.Rows[i]["count"].ToString());
                }
                return list;
            }
            return null;
        }
        //增加购物车商品数量
        [WebMethod]
        public bool pluscount(string userId, string GoodId, string count)
        {
            int newcount = int.Parse(count)+1;
            string sql = "UPDATE [Cart] SET count = '"+ newcount + "' WHERE userId='" + userId + "' AND GoodId='" + GoodId + "'";

            return OperatorDB.ExecCmd(sql);
        }
        //减少购物车商品数量
        [WebMethod]
        public bool reducecount(string userId, string GoodId, string count)
        {
            int newcount = int.Parse(count);
            if (newcount == 1)
            {
                string sql = "DELETE FROM  [dbo].[Cart]  WHERE userId='" + userId + "' AND GoodId='" + GoodId + "'";

                return OperatorDB.ExecCmd(sql);
            }
            else
            {
                newcount = newcount - 1;
                string sql = "UPDATE [Cart] SET count = '" + newcount + "' WHERE userId='" + userId + "' AND GoodId='" + GoodId + "'";
                return OperatorDB.ExecCmd(sql);
            }
        }
        [WebMethod]//得到商品图像
        public List<string> GetGoodPhotoInfo(string GoodId)
        {

            string sqlstr = "select photo from [Good] where goodId='" + GoodId + "'";
            DataTable dt = OperatorDB.GetDataTable(sqlstr);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["photo"].ToString());
                }
                return list;
            }
            return null;
        }
        //删除收藏商品
        [WebMethod]
        public bool DeleteFavoriteGood(string userId, string favoriteGoodId)
        {
            string sql = "DELETE FROM  [dbo].[FavoriteGood]  WHERE userId='" + userId + "' AND favoriteGoodId='"+ favoriteGoodId +"'";

            return OperatorDB.ExecCmd(sql);
        }
        //删除购物车商品
        [WebMethod]
        public bool DeleteCart(string userId, string GoodId)
        {
            string sql = "DELETE FROM  [dbo].[Cart]  WHERE userId='" + userId + "' AND GoodId='" + GoodId + "'";

            return OperatorDB.ExecCmd(sql);
        }
        [WebMethod]//得到收藏的店铺
        public List<string> GetAllFavoriteShopInfo(string userId)
        {
            string sql = "select favoriteShopName from [FavoriteShop] WHERE userId = " + "'" + userId + "'";
            DataTable dt = OperatorDB.GetDataTable(sql);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["favoriteShopName"].ToString());
                }
                return list;
            }
            return null;
        }
        //删除收藏店铺
        [WebMethod]
        public bool DeleteFavoriteShop(string userId, string favoriteShopName)
        {
            string sql = "DELETE FROM  [dbo].[FavoriteShop]  WHERE userId='" + userId + "' AND favoriteShopName='" + favoriteShopName + "'";

            return OperatorDB.ExecCmd(sql);
        }

        [WebMethod]//查收藏的店铺
        public List<string> GetShopByCondition(string userId, string input)
        {
            string sqlstr = "";
            if (userId != "")
                sqlstr = "userId ='" + userId + "' AND favoriteShopName LIKE '%" + input + "%'";
            if (sqlstr != "")
            {
                sqlstr = "SELECT favoriteShopName FROM [FavoriteShop]  WHERE " + sqlstr;
            }
            else
                sqlstr = "select favoriteShopName from [FavoriteShop] WHERE userId = " + "'" + userId + "'";
            DataTable dt = OperatorDB.GetDataTable(sqlstr);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["favoriteShopName"].ToString());
                }
                return list;
            }
            return null;
        }

        [WebMethod]//查收藏的商品
        public List<string> GetGoodByCondition(string userId, string input)
        {
            string sqlstr = "";
            if (userId != "")
                sqlstr = "userId ='" + userId + "' AND goodId = favoriteGoodId AND ( goodId LIKE '%" + input  + "%' OR goodName LIKE '%" + input + "%' OR kind LIKE '%" + input + "%' OR shopName LIKE '%" + input + "%')";
            if (sqlstr != "")
            {
                sqlstr = "SELECT goodId,goodName,shopName,price,kind FROM [Good],[FavoriteGood]  WHERE " + sqlstr;
            }
            else 
                sqlstr = "select goodId,goodName,shopName,price,kind from [Good],[FavoriteGood] WHERE goodId = favoriteGoodId AND FavoriteGood.userId = '"  + userId + "'";
            DataTable dt = OperatorDB.GetDataTable(sqlstr);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["goodId"].ToString());
                    list.Add(dt.Rows[i]["goodName"].ToString());
                    list.Add(dt.Rows[i]["shopName"].ToString());
                    list.Add(dt.Rows[i]["price"].ToString());
                    list.Add(dt.Rows[i]["kind"].ToString());
                }
                return list;
            }
            return null;
        }

        [WebMethod]//收藏夹加购物车
        public bool FavoriteGoodtoCart(string userId, string goodId)
        {
            string sql = "";
            sql = "IF EXISTS (SELECT * FROM [Cart] WHERE userId = '"+ userId +"' AND goodId = '"+ goodId + "' ) UPDATE [Cart] SET count = count+1 WHERE userId = '"+userId + "' AND goodId= '"+ goodId  + "' ELSE INSERT INTO [Cart] (goodId, userId, count) VALUES ('" + goodId + "','" + userId+ "', '1')";
            return OperatorDB.ExecCmd(sql);
        }

        [WebMethod]//商品状态查询
        public List<string> GoodCondition(string goodId)
        {
            string sql = "SELECT condition FROM [GoodCondition] WHERE goodId='" + goodId + "'";
            DataTable dt = OperatorDB.GetDataTable(sql);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["condition"].ToString());
                }
                return list;
            }
            return null;
        }

        [WebMethod]//购物车下单
        public bool Buy(string userId, string goodId, string count, string address)
        {            
            string sql = "INSERT INTO [Book] (bookId,goodId, userId, count,status,address,time) VALUES (newid(),'" + goodId + "','" + userId + "', '"+count+ "','待付款','"+address+"',getdate()) DELETE FROM Cart WHERE userId = '"+userId+"' AND goodId='"+goodId+"'";
            return OperatorDB.ExecCmd(sql);
        }


        //----------------------Book
        //根据商品Id查询商品图片
        [WebMethod]
        public List<string> GetPhotoInfoByGoodId(string goodId)
        {

            string sqlstr = "select photo from Good where goodId='" + goodId + "'";
            DataTable dt = OperatorDB.GetDataTable(sqlstr);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["photo"].ToString());
                }
                return list;
            }
            return null;
        }
        //根据输入查询订单信息
        [WebMethod]
        public List<string> GetAllBookinfoByInput(string input, string userId)
        {

            string sqlstr = "select distinct Book.bookId,Good.goodId,Good.goodName,Good.shopName,Good.kind,Good.price,Book.count,totalprice=CAST(Good.price AS DECIMAL(10,2))*CAST(Book.count AS DECIMAL(10,2)),Book.status,Book.time,Book.address FROM Book,Good,Login WHERE Book.goodId = Good.goodId And Book.userId = Login.userId And ( Book.bookId like '%" + input + "%' OR Good.goodName like '%" + input + "%' ) And Login.userId='" + userId + "'";
            DataTable dt = OperatorDB.GetDataTable(sqlstr);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["bookId"].ToString());
                    list.Add(dt.Rows[i]["goodId"].ToString());
                    list.Add(dt.Rows[i]["goodName"].ToString());
                    list.Add(dt.Rows[i]["shopName"].ToString());
                    list.Add(dt.Rows[i]["kind"].ToString());
                    list.Add(dt.Rows[i]["price"].ToString());
                    list.Add(dt.Rows[i]["count"].ToString());
                    list.Add(dt.Rows[i]["totalprice"].ToString());
                    list.Add(dt.Rows[i]["status"].ToString());
                    list.Add(dt.Rows[i]["time"].ToString());
                    list.Add(dt.Rows[i]["address"].ToString());
                }
                return list;
            }
            return null;
        }
        //根据输入查询待付款订单信息
        [WebMethod]
        public List<string> GetNotPayBookinfoByInput(string input, string userId)
        {

            string sqlstr = "select distinct Book.bookId,Good.goodId,Good.goodName,Good.shopName,Good.kind,Good.price ,Book.count,totalprice=CAST(Good.price AS DECIMAL(10,2))*CAST(Book.count AS DECIMAL(10,2)),Book.status,Book.time,Book.address from Book, Good, Login where Book.goodId = Good.goodId And Book.userId = Login.userId And Book.status='待付款' And (Book.bookId  like'%" + input + "%' OR Good.goodName like'%" + input + "%' ) And Login.userId='" + userId + "'";
            DataTable dt = OperatorDB.GetDataTable(sqlstr);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["bookId"].ToString());
                    list.Add(dt.Rows[i]["goodId"].ToString());
                    list.Add(dt.Rows[i]["goodName"].ToString());
                    list.Add(dt.Rows[i]["shopName"].ToString());
                    list.Add(dt.Rows[i]["kind"].ToString());
                    list.Add(dt.Rows[i]["price"].ToString());
                    list.Add(dt.Rows[i]["count"].ToString());
                    list.Add(dt.Rows[i]["totalprice"].ToString());
                    list.Add(dt.Rows[i]["status"].ToString());
                    list.Add(dt.Rows[i]["time"].ToString());
                    list.Add(dt.Rows[i]["address"].ToString());
                }
                return list;
            }
            return null;
        }
        //根据输入查询待发货订单信息
        [WebMethod]
        public List<string> GetNotDeliverBookinfoByInput(string input, string userId)
        {

            string sqlstr = "select distinct Book.bookId,Good.goodId,Good.goodName,Good.shopName,Good.kind,Good.price ,Book.count,totalprice=CAST(Good.price AS DECIMAL(10,2))*CAST(Book.count AS DECIMAL(10,2)),Book.status,Book.time,Book.address from Book, Good, Login where Book.goodId = Good.goodId And Book.userId = Login.userId  And Book.status='待发货' And (Book.bookId  like'%" + input + "%' OR Good.goodName like'%" + input + "%' ) And Login.userId='" + userId + "'";
            DataTable dt = OperatorDB.GetDataTable(sqlstr);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["bookId"].ToString());
                    list.Add(dt.Rows[i]["goodId"].ToString());
                    list.Add(dt.Rows[i]["goodName"].ToString());
                    list.Add(dt.Rows[i]["shopName"].ToString());
                    list.Add(dt.Rows[i]["kind"].ToString());
                    list.Add(dt.Rows[i]["price"].ToString());
                    list.Add(dt.Rows[i]["count"].ToString());
                    list.Add(dt.Rows[i]["totalprice"].ToString());
                    list.Add(dt.Rows[i]["status"].ToString());
                    list.Add(dt.Rows[i]["time"].ToString());
                    list.Add(dt.Rows[i]["address"].ToString());
                }
                return list;
            }
            return null;
        }
        //根据输入查询待收货订单信息
        [WebMethod]
        public List<string> GetNotReceiveBookinfoByInput(string input, string userId)
        {

            string sqlstr = "select distinct Book.bookId,Good.goodId,Good.goodName,Good.shopName,Good.kind,Good.price ,Book.count,totalprice=CAST(Good.price AS DECIMAL(10,2))*CAST(Book.count AS DECIMAL(10,2)),Book.status,Book.time,Book.address from Book, Good, Login where Book.goodId = Good.goodId And Book.userId = Login.userId And Book.status='待收货' And (Book.bookId  like'%" + input + "%' OR Good.goodName like'%" + input + "%' ) And Login.userId='" + userId + "'";
            DataTable dt = OperatorDB.GetDataTable(sqlstr);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["bookId"].ToString());
                    list.Add(dt.Rows[i]["goodId"].ToString());
                    list.Add(dt.Rows[i]["goodName"].ToString());
                    list.Add(dt.Rows[i]["shopName"].ToString());
                    list.Add(dt.Rows[i]["kind"].ToString());
                    list.Add(dt.Rows[i]["price"].ToString());
                    list.Add(dt.Rows[i]["count"].ToString());
                    list.Add(dt.Rows[i]["totalprice"].ToString());
                    list.Add(dt.Rows[i]["status"].ToString());
                    list.Add(dt.Rows[i]["time"].ToString());
                    list.Add(dt.Rows[i]["address"].ToString());
                }
                return list;
            }
            return null;
        }
        //根据输入查询待评价订单信息
        [WebMethod]
        public List<string> GetNotAssessBookinfoByInput(string input, string userId)
        {

            string sqlstr = "select distinct Book.bookId,Good.goodId,Good.goodName,Good.shopName,Good.kind,Good.price ,Book.count,totalprice=CAST(Good.price AS DECIMAL(10,2))*CAST(Book.count AS DECIMAL(10,2)),Book.status,Book.time,Book.address from Book, Good, Login where Book.goodId = Good.goodId And Book.userId = Login.userId And Book.status='待评价' And (Book.bookId  like'%" + input + "%' OR Good.goodName like'%" + input + "%' ) And Login.userId='" + userId + "'";
            DataTable dt = OperatorDB.GetDataTable(sqlstr);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["bookId"].ToString());
                    list.Add(dt.Rows[i]["goodId"].ToString());
                    list.Add(dt.Rows[i]["goodName"].ToString());
                    list.Add(dt.Rows[i]["shopName"].ToString());
                    list.Add(dt.Rows[i]["kind"].ToString());
                    list.Add(dt.Rows[i]["price"].ToString());
                    list.Add(dt.Rows[i]["count"].ToString());
                    list.Add(dt.Rows[i]["totalprice"].ToString());
                    list.Add(dt.Rows[i]["status"].ToString());
                    list.Add(dt.Rows[i]["time"].ToString());
                    list.Add(dt.Rows[i]["address"].ToString());
                }
                return list;
            }
            return null;
        }
        //根据输入查询已退款订单信息
        [WebMethod]
        public List<string> GetRefundBookinfoByInput(string input, string userId)
        {

            string sqlstr = "select distinct Book.bookId,Good.goodId,Good.goodName,Good.shopName,Good.kind,Good.price ,Book.count,totalprice=CAST(Good.price AS DECIMAL(10,2))*CAST(Book.count AS DECIMAL(10,2)),Book.status,Book.time,Book.address from Book, Good, Login where Book.goodId = Good.goodId And Book.userId = Login.userId And Book.status='已退款' And (Book.bookId  like'%" + input + "%' OR Good.goodName like'%" + input + "%' ) And Login.userId='" + userId + "'";
            DataTable dt = OperatorDB.GetDataTable(sqlstr);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["bookId"].ToString());
                    list.Add(dt.Rows[i]["goodId"].ToString());
                    list.Add(dt.Rows[i]["goodName"].ToString());
                    list.Add(dt.Rows[i]["shopName"].ToString());
                    list.Add(dt.Rows[i]["kind"].ToString());
                    list.Add(dt.Rows[i]["price"].ToString());
                    list.Add(dt.Rows[i]["count"].ToString());
                    list.Add(dt.Rows[i]["totalprice"].ToString());
                    list.Add(dt.Rows[i]["status"].ToString());
                    list.Add(dt.Rows[i]["time"].ToString());
                    list.Add(dt.Rows[i]["address"].ToString());
                }
                return list;
            }
            return null;
        }
        //获取所有订单信息服务
        [WebMethod]
        public List<string> GetAllBookinfo(string userId)
        {
            string sql = "select distinct Book.bookId,Good.goodId,Good.goodName,Good.shopName,Good.kind,Good.price ,Book.count,totalprice=CAST(Good.price AS DECIMAL(10,2))*CAST(Book.count AS DECIMAL(10,2)),Book.status,Book.time,Book.address from Book, Good, Login where Book.goodId = Good.goodId And Book.userId='" + userId + "'";
            DataTable dt = OperatorDB.GetDataTable(sql);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["bookId"].ToString());
                    list.Add(dt.Rows[i]["goodId"].ToString());
                    list.Add(dt.Rows[i]["goodName"].ToString());
                    list.Add(dt.Rows[i]["shopName"].ToString());
                    list.Add(dt.Rows[i]["kind"].ToString());
                    list.Add(dt.Rows[i]["price"].ToString());
                    list.Add(dt.Rows[i]["count"].ToString());
                    list.Add(dt.Rows[i]["totalprice"].ToString());
                    list.Add(dt.Rows[i]["status"].ToString());
                    list.Add(dt.Rows[i]["time"].ToString());
                    list.Add(dt.Rows[i]["address"].ToString());
                }
                return list;
            }
            return null;
        }
        //获取待付款订单信息服务
        [WebMethod]
        public List<string> GetNotPayBookinfo(string userId)
        {
            string sql = "select distinct Book.bookId,Good.goodId,Good.goodName,Good.shopName,Good.kind,Good.price ,Book.count,totalprice=CAST(Good.price AS DECIMAL(10,2))*CAST(Book.count AS DECIMAL(10,2)),Book.status,Book.time,Book.address from Book, Good, Login where Book.goodId = Good.goodId And Book.status='待付款' And Book.userId='" + userId + "'";
            DataTable dt = OperatorDB.GetDataTable(sql);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["bookId"].ToString());
                    list.Add(dt.Rows[i]["goodId"].ToString());
                    list.Add(dt.Rows[i]["goodName"].ToString());
                    list.Add(dt.Rows[i]["shopName"].ToString());
                    list.Add(dt.Rows[i]["kind"].ToString());
                    list.Add(dt.Rows[i]["price"].ToString());
                    list.Add(dt.Rows[i]["count"].ToString());
                    list.Add(dt.Rows[i]["totalprice"].ToString());
                    list.Add(dt.Rows[i]["status"].ToString());
                    list.Add(dt.Rows[i]["time"].ToString());
                    list.Add(dt.Rows[i]["address"].ToString());
                }
                return list;
            }
            return null;
        }
        //获取待发货订单信息服务
        [WebMethod]
        public List<string> GetNotDeliverBookinfo(string userId)
        {
            string sql = "select distinct Book.bookId,Good.goodId,Good.goodName,Good.shopName,Good.kind,Good.price ,Book.count,totalprice=CAST(Good.price AS DECIMAL(10,2))*CAST(Book.count AS DECIMAL(10,2)),Book.status,Book.time,Book.address from Book, Good, Login where Book.goodId = Good.goodId And Book.status='待发货' And Book.userId='" + userId + "'";
            DataTable dt = OperatorDB.GetDataTable(sql);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["bookId"].ToString());
                    list.Add(dt.Rows[i]["goodId"].ToString());
                    list.Add(dt.Rows[i]["goodName"].ToString());
                    list.Add(dt.Rows[i]["shopName"].ToString());
                    list.Add(dt.Rows[i]["kind"].ToString());
                    list.Add(dt.Rows[i]["price"].ToString());
                    list.Add(dt.Rows[i]["count"].ToString());
                    list.Add(dt.Rows[i]["totalprice"].ToString());
                    list.Add(dt.Rows[i]["status"].ToString());
                    list.Add(dt.Rows[i]["time"].ToString());
                    list.Add(dt.Rows[i]["address"].ToString());
                }
                return list;
            }
            return null;
        }
        //获取待收货订单信息服务
        [WebMethod]
        public List<string> GetNotReceiveBookinfo(string userId)
        {
            string sql = "select distinct Book.bookId,Good.goodId,Good.goodName,Good.shopName,Good.kind,Good.price ,Book.count,totalprice=CAST(Good.price AS DECIMAL(10,2))*CAST(Book.count AS DECIMAL(10,2)),Book.status,Book.time,Book.address from Book, Good, Login where Book.goodId = Good.goodId And Book.status='待收货' And Book.userId='" + userId + "'";
            DataTable dt = OperatorDB.GetDataTable(sql);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["bookId"].ToString());
                    list.Add(dt.Rows[i]["goodId"].ToString());
                    list.Add(dt.Rows[i]["goodName"].ToString());
                    list.Add(dt.Rows[i]["shopName"].ToString());
                    list.Add(dt.Rows[i]["kind"].ToString());
                    list.Add(dt.Rows[i]["price"].ToString());
                    list.Add(dt.Rows[i]["count"].ToString());
                    list.Add(dt.Rows[i]["totalprice"].ToString());
                    list.Add(dt.Rows[i]["status"].ToString());
                    list.Add(dt.Rows[i]["time"].ToString());
                    list.Add(dt.Rows[i]["address"].ToString());
                }
                return list;
            }
            return null;
        }
        //获取待评价订单信息服务
        [WebMethod]
        public List<string> GetNotAssessBookinfo(string userId)
        {
            string sql = "select distinct Book.bookId,Good.goodId,Good.goodName,Good.shopName,Good.kind,Good.price ,Book.count,totalprice=CAST(Good.price AS DECIMAL(10,2))*CAST(Book.count AS DECIMAL(10,2)),Book.status,Book.time,Book.address from Book, Good, Login where Book.goodId = Good.goodId And Book.status='待评价' And Book.userId='" + userId + "'";
            DataTable dt = OperatorDB.GetDataTable(sql);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["bookId"].ToString());
                    list.Add(dt.Rows[i]["goodId"].ToString());
                    list.Add(dt.Rows[i]["goodName"].ToString());
                    list.Add(dt.Rows[i]["shopName"].ToString());
                    list.Add(dt.Rows[i]["kind"].ToString());
                    list.Add(dt.Rows[i]["price"].ToString());
                    list.Add(dt.Rows[i]["count"].ToString());
                    list.Add(dt.Rows[i]["totalprice"].ToString());
                    list.Add(dt.Rows[i]["status"].ToString());
                    list.Add(dt.Rows[i]["time"].ToString());
                    list.Add(dt.Rows[i]["address"].ToString());
                }
                return list;
            }
            return null;
        }
        //获取已退款订单信息服务
        [WebMethod]
        public List<string> GetRefundBookinfo(string userId)
        {
            string sql = "select distinct Book.bookId,Good.goodId,Good.goodName,Good.shopName,Good.kind,Good.price ,Book.count,totalprice=CAST(Good.price AS DECIMAL(10,2))*CAST(Book.count AS DECIMAL(10,2)),Book.status,Book.time,Book.address from Book, Good, Login where Book.goodId = Good.goodId And Book.status='已退款' And Book.userId='" + userId + "'";
            DataTable dt = OperatorDB.GetDataTable(sql);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["bookId"].ToString());
                    list.Add(dt.Rows[i]["goodId"].ToString());
                    list.Add(dt.Rows[i]["goodName"].ToString());
                    list.Add(dt.Rows[i]["shopName"].ToString());
                    list.Add(dt.Rows[i]["kind"].ToString());
                    list.Add(dt.Rows[i]["price"].ToString());
                    list.Add(dt.Rows[i]["count"].ToString());
                    list.Add(dt.Rows[i]["totalprice"].ToString());
                    list.Add(dt.Rows[i]["status"].ToString());
                    list.Add(dt.Rows[i]["time"].ToString());
                    list.Add(dt.Rows[i]["address"].ToString());
                }
                return list;
            }
            return null;
        }
        //删除订单信息服务
        [WebMethod]
        public bool DeleteBookinfoByBookId(string bookId)
        {
            string sql = "DELETE FROM  [dbo].[Book] WHERE bookId='" + bookId + "'";

            return OperatorDB.ExecCmd(sql);
        }

        [WebMethod]
        public List<String> GoodSearchGetSomeGoodInfo()
        {
            string sqlstr = "select TOP 100 goodId,price,goodName from Good";
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
        public List<String> GoodSearchGetSomeGoodByInput(string input)
        {
            string sqlstr = "select TOP 100 goodId,price,goodName from Good where (Good.kind like'%" + input + "%' OR Good.goodName like'%" + input + "%' OR Good.price like'%" + input + "%')";
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

        //--------------------------------------GoodCondition
        //根据登录id获取所有商品信息
        [WebMethod]
        public List<string> GetAllGoodInfo(string shopid)
        {
            string sql = "select Good.goodId,Good.shopName,Good.goodName,Good.kind,Good.price,GoodCondition.condition from Good,GoodCondition,ShopLogin where Good.goodId = GoodCondition.goodId and Good.shopName = ShopLogin.shopId and ShopLogin.shopId = '" + shopid + "'";
            DataTable dt = OperatorDB.GetDataTable(sql);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["goodId"].ToString());
                    list.Add(dt.Rows[i]["shopName"].ToString());
                    list.Add(dt.Rows[i]["goodName"].ToString());
                    list.Add(dt.Rows[i]["kind"].ToString());
                    list.Add(dt.Rows[i]["price"].ToString());
                    list.Add(dt.Rows[i]["condition"].ToString());
                }
                return list;
            }
            return null;
        }
        //根据条件获取信商品息
        [WebMethod]
        public List<string> GetGoodInfoByCondition(string goodName, string kind, string condition, string shopid)
        {
            string sqlstr = "";
            if (goodName != "")
                sqlstr += "Good.goodName like'%" + goodName + "%' and ";
            if (kind != "")
                sqlstr += "Good.kind='" + kind + "' and ";
            if (condition != "")
                sqlstr += "GoodCondition.condition='" + condition + "' and ";
            if (sqlstr != "")
            {
                sqlstr = sqlstr.Substring(0, sqlstr.Length - 4);
                sqlstr = "select Good.goodId,Good.shopName,Good.goodName,Good.kind,Good.price,GoodCondition.condition from Good,GoodCondition,ShopLogin where Good.goodId=GoodCondition.goodId and Good.shopName=ShopLogin.shopId and ShopLogin.shopId='" + shopid + "' and " + sqlstr;
            }
            else
                sqlstr = "select Good.goodId,Good.shopName,Good.goodName,Good.kind,Good.price,GoodCondition.condition from Good,GoodCondition,ShopLogin where Good.goodId=GoodCondition.goodId and Good.shopName=ShopLogin.shopId and ShopLogin.shopId='" + shopid + "'";
            DataTable dt = OperatorDB.GetDataTable(sqlstr);
            List<string> list = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["goodId"].ToString());
                    list.Add(dt.Rows[i]["shopName"].ToString());
                    list.Add(dt.Rows[i]["goodName"].ToString());
                    list.Add(dt.Rows[i]["kind"].ToString());
                    list.Add(dt.Rows[i]["price"].ToString());
                    list.Add(dt.Rows[i]["condition"].ToString());
                }
                return list;
            }
            return null;
        }
        //修改商品信息服务
        [WebMethod]
        public bool UpdateGoodInfoByGoodId(string goodId, string price, string photo)
        {
            string sql = "";//good.goodId, good.goodName, good.kind, good.price, goodCon.condition, good.photo
            if (photo == "")
            {
                sql = "UPDATE Good SET price='" + price + "'"
                              + " where goodId='" + goodId + "'";
            }
            else
            {
                sql = "UPDATE Good SET price='" + price + "'"
                               + "photo='" + photo + "'"
                               + " where goodId='" + goodId + "'";
            }
            return OperatorDB.ExecCmd(sql);
        }
        //修改商品信息服务
        [WebMethod]
        public bool UpdateGoodConditionInfoByGoodId(string goodId, string condition)
        {
            //good.goodId, good.goodName, good.kind, good.price, goodCon.condition, good.photo
            string sql = "UPDATE GoodCondition SET condition='" + condition + "'"
                              + " where goodId='" + goodId + "'";
            return OperatorDB.ExecCmd(sql);
        }
        //插入商品信息服务
        [WebMethod]
        public bool InsertGoodInfo(string goodId, string price, string goodName, string kind, string shopName, string photo)
        {
            //good.goodId, good.shopName, good.goodName, good.kind, good.price, goodCon.condition, good.photo
            string sql = "INSERT INTO Good VALUES  ('"
                        + goodId + "','"
                        + price + "','"
                        + goodName + "','"
                        + kind + "','"
                        + shopName + "','"
                        + photo + "')";
            return OperatorDB.ExecCmd(sql);
        }//插入商品状态信息服务
        [WebMethod]
        public bool InsertGoodConditionInfo(string goodId, string condition)
        {
            //good.goodId, good.shopName, good.goodName, good.kind, good.price, goodCon.condition, good.photo
            string sql = "INSERT INTO GoodCondition VALUES  ('"
                        + goodId + "','"
                        + condition + "')";
            return OperatorDB.ExecCmd(sql);
        }
        //获取所有商品Id
        [WebMethod]
        public List<int> GetAllGoodId()
        {
            string sql = "select Id=convert(int,goodId) from Good ";
            DataTable dt = OperatorDB.GetDataTable(sql);
            List<int> list = new List<int>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(int.Parse(dt.Rows[i]["Id"].ToString()));
                }
                return list;
            }
            return null;
        }
        //------------------------------------
    }
}
