using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// MyClass 的摘要说明
/// </summary>
/// 
namespace MyClass
{
    
    public class DB
    {
        private SqlConnection cnn;
        public DB()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #region getConnection()
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <returns></returns>
        public void getConnection()
        {
            string myStr = ConfigurationManager.AppSettings["cnn"].ToString();
            cnn = new SqlConnection(myStr);
        }
        #endregion
        #region open()
        /// <summary>
        /// 打开数据库
        /// </summary>
        /// <param name="cnn"></param>
        public void open()
        {
            cnn.Open();
        }
        #endregion
        #region close()
        /// <summary>
        /// 关闭数据库
        /// </summary>
        /// <param name="cnn"></param>
        public void close()
        {
            cnn.Close();
        }

        #endregion
        #region void executeNonQuery(string str)
        /// <summary>
        /// 执行Sql语句
        /// </summary>
        /// <param name="str"></param>
        public void executeNonQuery(string str)
        {
            SqlCommand cmd = new SqlCommand(str, cnn);
            cmd.ExecuteNonQuery();
        }
        #endregion
        #region getDataReader(string str)
        /// <summary>
        /// 得到DataReader对象
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public SqlDataReader getDataReader(string str)
        {
            SqlCommand cmd = new SqlCommand(str, cnn);
            SqlDataReader Dr = cmd.ExecuteReader();
            return Dr;
        }
        #endregion 
        #region getDataSet(string str)
        /// <summary>
        /// 返回DataSet
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public DataSet getDataSet(string str)
        {
            SqlDataAdapter Da = new SqlDataAdapter(str, cnn);
            DataSet Ds = new DataSet();
            Da.Fill(Ds);
            return Ds;
        }
        #endregion
        #region executeScalar(string str)
        /// <summary>
        /// 执行executeScalar
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public object executeScalar(string str)
        {
            SqlCommand cmd = new SqlCommand(str, cnn);
            object obj=cmd.ExecuteScalar();
            return obj;
        }
        #endregion

    }
}