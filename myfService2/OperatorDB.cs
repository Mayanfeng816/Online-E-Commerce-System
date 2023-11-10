﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace myfService2
{
    public class OperatorDB
    {
        private static string conStr = "Data Source =.; Initial Catalog = EleDB; User ID = sa; Password=20020816";
        public static DataTable GetDataTable(string sql)
        {
            SqlConnection con = new SqlConnection(conStr);//ConfigurationManager.AppSettings["conStr"]);
            con.Open();
            SqlDataAdapter ada = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            con.Close();
            return dt;
        }
        public static bool ExecCmd(string sql)
        {
            SqlConnection con = new SqlConnection(conStr);//ConfigurationManager.AppSettings["conStr"]);
                                                          //启用事务实现       
            con.Open();
            SqlTransaction st = con.BeginTransaction();
            SqlCommand com = con.CreateCommand();
            com.Transaction = st;
            try
            {
                com.CommandText = sql;
                com.ExecuteNonQuery();
                st.Commit();
                con.Close();
                return true;
            }
            catch
            {
                st.Rollback();
                con.Close();
                return false;
            }
        }
    }
}