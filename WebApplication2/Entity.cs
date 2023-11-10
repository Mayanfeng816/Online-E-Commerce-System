using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class GoodInfo
    {
        public string goodId;
        public string price;
        public string goodName;
        public string shopName; 
        public string kind;
    }

    public class FavoriteGoodInfo
    {
        public string favoriteGoodId;
        public string userId;
    }

    public class FavoriteShopInfo
    {
        public string favoriteShopName;
        public string userId;
    }

    public class CartInfo
    {
        public string userId;
        public string goodId;
        public string count;
    }
    //---------------------
    public class Good
    {
        public string goodId;
        public string price;
        public string goodName;
        public string kind;
        public string shopName;
        public string photo;
    }
    public class Book
    {
        public string bookId;
        public string goodId;
        public string count;
        public string status;
        public string userId;
        public string time;
        public string address;
    }
    public class login
    {
        public string password;
        public string userId;
    }
    public class GoodConditionInfo
    {
        public string goodId;
        public string condition;
    }
    public class ShopLoginInfo
    {
        public string shopId;
        public string password;
    }

}