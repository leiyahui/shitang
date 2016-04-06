using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyClass;

public partial class Eva_Evaluate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!((User)Session["user"]).IsLog)
        {
            Response.Redirect("~/Login/Login.aspx");
        }
    }
    protected void Btn_submit_Click(object sender, EventArgs e)
    {
        string pro_id = Request.QueryString["pro_id"].ToString();
        string username = ((User)Session["user"]).UserName.ToString();
        string sore=Rbl_sore.SelectedItem.Text;
        string text=Tb_idea.Text;
        DB database = new DB();
        database.getConnection();
        database.open();
        string str_cmd;
        str_cmd = "insert into T_EVA (eva_user_name,eva_pro_id,eva_sore,eva_text) values ('" + username + "','" + pro_id + "','" + sore + "','" + text + "')";
        database.executeNonQuery(str_cmd);
        database.close();
    }
}