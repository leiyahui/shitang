using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyClass;

public partial class Login_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["formPage"] = HttpContext.Current.Request.UrlReferrer.ToString();
        }
       
           
       
        
    }
    protected void Btn_log_Click(object sender, EventArgs e)
    {
        string username = Tb_name.Text;
        string passwd = Tb_passwd.Text;
        Boolean autolog = Chk_islog.Checked;
        ((User)Session["user"]).UserName = username;
        ((User)Session["user"]).PassWd = passwd;
        ((User)Session["user"]).AutoLog = autolog;
        if (((User)Session["user"]).tryLog())
        {
            Response.Redirect(ViewState["formPage"].ToString());
        }
    }
}