using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
       if(((User)Session["user"]).IsLog == true)
       {
           string name = ((User)Session["user"]).UserName;
           Lb1.Text = name;
           Btn_Log.Text = "退出登录";
       }
    }
    protected void Btn_Log_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Login/Login.aspx");
    }
    protected void Btn_register_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Login/Register.aspx");
    }
    protected void Btn_ShopCart_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ShopCart/ShopCart.aspx");
    }
}
