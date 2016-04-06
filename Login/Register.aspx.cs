using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyClass;
public partial class Login_Regist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["formpage"] = HttpContext.Current.Request.UrlReferrer.ToString();
        }
    }

    protected void Btn_Register_Click(object sender, EventArgs e)
    {
        DB database = new DB();
        database.getConnection();
        database.open();
        string name=Tb_name.Text;
        string str_cmd = "select * from T_USER where user_name = '" + name + "'";
        int i=Convert.ToInt32(database.executeScalar(str_cmd));
        if(i>0)
        {
            Lb1.Text = "用户名已被注册";
        }
        else
        {
            string passwd=Tb_passwd.Text;
            str_cmd = "insert into T_USER (user_name,passwd) values ('" + name + "','" + passwd + "')";
            database.executeNonQuery(str_cmd);
            ((User)Session["user"]).UserName = name;
            ((User)Session["user"]).PassWd = passwd;
            ((User)Session["user"]).tryLog();
            Response.Redirect(ViewState["formpage"].ToString());
        }
    }
}