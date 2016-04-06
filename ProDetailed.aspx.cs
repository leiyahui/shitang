using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyClass;
using System.Data.SqlClient;
using System.Data;

public partial class ProDetailed : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string pro_id = Request.QueryString["proid"].ToString();
        DB database = new DB();
        database.getConnection();
        database.open();
        string str_cmd;
        str_cmd = "select T_PRO.*,T_IMAGE.* from T_PRO inner join T_IMAGE on T_PRO.pro_image_id=T_IMAGE.image_id where pro_id =" + pro_id;
        SqlDataReader Dr = database.getDataReader(str_cmd);
        while(Dr.Read())
        {
            Image_pro.ImageUrl = Dr["image_url"].ToString();
            Lb_id.Text = Dr["pro_id"].ToString();
            Lb_name.Text = Dr["pro_name"].ToString();
            Lb_price.Text = Dr["pro_price"].ToString();
        }
        Dr.Close();
        str_cmd = "select * from T_EVA where eva_pro_id =" + pro_id;
        DataSet Ds = database.getDataSet(str_cmd);
        Lv_eva.DataSource = Ds;
        Lv_eva.DataBind();
        database.close();
    }
    protected void Btn_addshopCart_Click(object sender, EventArgs e)
    {
        
        if (!((User)Session["user"]).IsLog)
        {
            Response.Redirect("~/Login/Login.aspx");
        }
        else
        {
            string user = (((User)Session["user"]).UserName).ToString();
            string pro_id = Request.QueryString["proid"].ToString();
            DB database = new DB();
            database.getConnection();
            database.open();
            string cmdstr;
            cmdstr = "select count(*) from T_SHOPCART where cart_user_name = '" + user + "' and cart_pro_id = '" + pro_id + "'";
            int i = Convert.ToInt32(database.executeScalar(cmdstr));
            if (i > 0)
            {
                cmdstr = "update T_SHOPCART set cart_pro_num = cart_pro_num + 1 where cart_user_name = '" + user + "'";
                database.executeNonQuery(cmdstr);
            }
            else
            {
                cmdstr = "insert into T_SHOPCART (cart_user_name,cart_pro_id,cart_pro_num) values ('" + user + "','" + pro_id + "','1" + "')";
                database.executeNonQuery(cmdstr);
            }
            database.close();
        }
    }
}