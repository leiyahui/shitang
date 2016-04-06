using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyClass;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// User 的摘要说明
/// </summary>
public class User
{
    private string userName;
    public string UserName
    {
        get { return userName; }
        set {userName=value;}
    }
    private string userPhone;
    
    private string passWd;
    public string PassWd
    {
        get { return passWd; }
        set { passWd = value; }
    }
    private Boolean isLog;
    public Boolean IsLog
    {
        get { return isLog; }
        set { isLog = value; }
    }
    private Boolean autoLog;
    public Boolean AutoLog
    {
        get { return autoLog; }
        set{autoLog=value;}
    }
    
	public User()
	{
		//
		// TODO: 在此处添加构造函数逻辑
        
		//
        userName = "";
        userPhone = "";
        isLog = false;
         
        autoLog = false;
        readCookie();
        if(autoLog==true)
        {
            tryLog();
        }
	}
    #region checkLog()
    /// <summary>
    /// 检查用户名和密码
    /// </summary>
    /// <param name="username"></param>
    /// <param name="passwd"></param>
    /// <returns></returns>
    public int checkLog()
    {
        DB dataBase = new DB();
        dataBase.getConnection();
        dataBase.open();
        int i = (int)dataBase.executeScalar("select count(*) from T_USER where user_name = '" + userName + "' and passwd = '" + passWd + "'");
        dataBase.close();
        return i;
    }
    #endregion
    #region tryLog()
    /// <summary>
    /// 登陆
    /// </summary>
    /// <param name="username"></param>
    /// <param name="passwd"></param>
    /// <returns></returns>
    public Boolean tryLog()
    {
        int i = checkLog();
        if(i>0)
        {
            
            string str_user = Convert.ToString(HttpContext.Current.Cache[userName]);
            if(str_user==string.Empty)
            {
                TimeSpan sessionTimeOut = new TimeSpan(0, 0, HttpContext.Current.Session.Timeout, 0, 0);
                HttpContext.Current.Cache.Insert(userName,userName, null, DateTime.MaxValue, sessionTimeOut);
                
                isLog = true;
                if(autoLog==true)
                {
                    setCookies();
                }
                return true;
            }
            else
            {
                HttpContext.Current.Response.Write("<script>alert('这个账号已经被登陆')</script>");
                return false;
            }
            

        }
        else
        {
            HttpContext.Current.Response.Write("<script>alert('您的用户名或密码错误')</script>");
            return false;
        }
    }
    #endregion 
    #region logOut()
    /// <summary>
    /// 注销
    /// </summary>
    public void logOut()
    {
        isLog = false;
        HttpContext.Current.Cache.Remove(userName);
    }
    #endregion
    #region setCookies(string username,string passwd,Boolean autolog)
    /// <summary>
    /// 写入Cookie
    /// </summary>
    /// <param name="usename"></param>
    /// <param name="passwd"></param>
    /// <param name="autolog"></param>
    public void setCookies()
    {
        HttpCookie ck = new HttpCookie("loginfo");

        ck.Values.Add("username", HttpContext.Current.Server.UrlEncode(userName));
        ck.Values.Add("userpasswd", HttpContext.Current.Server.UrlEncode(passWd));
        ck.Values.Add("autolog",HttpContext.Current.Server.UrlEncode((autoLog.ToString())));
        ck.Expires = DateTime.MaxValue;
        HttpContext.Current.Response.Cookies.Add(ck);
    }
    #endregion
    #region readCookie()
    /// <summary>
    /// 读取Cookie
    /// </summary>
    /// <returns></returns>
    public void readCookie()
    {
        
        HttpCookie ck = HttpContext.Current.Request.Cookies["loginfo"];
        if (ck != null)
        {
            userName = HttpContext.Current.Server.UrlDecode(Convert.ToString(ck.Values["username"]));
            passWd = HttpContext.Current.Server.UrlDecode(Convert.ToString(ck.Values["userpasswd"]));
            autoLog = Convert.ToBoolean(HttpContext.Current.Server.UrlDecode(Convert.ToString(ck.Values["autolog"])));
        }
    }
    #endregion
   
}