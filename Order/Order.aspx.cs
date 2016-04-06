using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyClass;
using System.Data;

public partial class Order_Order : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string username=((User)Session["user"]).UserName.ToString();
        DB database = new DB();
        database.getConnection();
        database.open();
        string str_cmd;
        str_cmd = "select T_ORDER.order_id,T_ORDER.order_pro_num,T_ORDER.order_money,T_PRO.pro_id,T_PRO.pro_name from T_ORDER inner join T_PRO on T_ORDER.order_pro_id = T_PRO.pro_id where T_ORDER.order_user_name = '" + username + "'";
        DataSet Ds = database.getDataSet(str_cmd);
        Lv_order.DataSource = Ds;
        Lv_order.DataBind();
        database.close();
    }
    protected void OnCommandEvaluate(object sender,CommandEventArgs e)
    {
        string pro_id = e.CommandArgument.ToString();
        string url = "~/Eva/Evaluate.aspx?pro_id=" + pro_id;
        Response.Redirect(url);

    }
    protected void OnCommandBuy(object sender,CommandEventArgs e)
    {
        string pro_id = e.CommandArgument.ToString();
        Response.Redirect("~/Pro_Detailed.aspx?pro_id=" + pro_id);
    }
}