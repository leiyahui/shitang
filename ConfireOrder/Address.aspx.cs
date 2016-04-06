using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyClass;


public partial class ConfireOrder_Address : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Btn_save_Click(object sender, EventArgs e)
    {
        string username=((User)Session["user"]).UserName.ToString();
        string building=Dl_building.SelectedItem.Text;
        string floor=Dl_floor.SelectedItem.Text;
        string room=Tb_detail.Text;
        string number = Lb_phone.Text;
        DB database = new DB();
        database.getConnection();
        database.open();  
        string str_cmd;
        str_cmd = "insert T_DELIVERY (delivery_user_name,delivery_building,delivery_floor,delivery_room,delivery_number) values ('" + username + "','" + building + "','" + floor + "','" + room + "','" + number + "')";
        database.executeNonQuery(str_cmd);
        database.close();
    }
}