using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyClass;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

public partial class ConfireOrder : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        
            string username = ((User)Session["user"]).UserName.ToString();
            DB database = new DB();
            database.getConnection();
            database.open();
            string str_cmd;
            //获取商品列表
            if (!IsPostBack)
            {
                str_cmd = "select T_SHOPCART.* ,T_PRO.* from T_SHOPCART inner join T_PRO on T_SHOPCART.cart_pro_id= T_PRO.pro_id where T_SHOPCART.cart_user_name = '" + username + "'";
                DataSet Ds = database.getDataSet(str_cmd);
                Lv_info.DataSource = Ds;
                Lv_info.DataBind();
            }
            //获取用户收货地址
            str_cmd = "select T_DELIVERY.* from T_DELIVERY inner join T_USER on T_DELIVERY.delivery_user_name=T_USER.user_name where T_USER.user_name = '" + username + "'";
            SqlDataReader Dr = database.getDataReader(str_cmd);

            if (Dr.HasRows)
            {
                Rbl.Items.Clear();
                ListItem Rb;
                Label Lb1 = new Label();
                Lb1.Text = "送至";
                div_address.Controls.Add(Lb1);
                while (Dr.Read())
                {

                    Rb = new ListItem();
                    Rb.Text = Dr["delivery_building"].ToString() + " " + Dr["delivery_floor"].ToString() + "" + Dr["delivery_room"].ToString();
                    Rb.Value = Dr["delivery_id"].ToString();
                    Rbl.Items.Add(Rb);
                }
                Rbl.SelectedIndex = 0;
                Button Btn = new Button();
                Btn.Text = "新增收货地址";
                Btn.Command += new CommandEventHandler(OnAddAddress);
                Btn.OnClientClick = "AddAddress()";
                div_address.Controls.Add(Btn);
            }

            else
            {
                Button Btn = new Button();
                Btn.Text = "请添加地址";
                Btn.Command += new CommandEventHandler(OnAddAddress);
                Btn.OnClientClick = "AddAddress()";
                div_address.Controls.Add(Btn);
            }

            database.close();
            //选定默认的支付方式
            Rbl_pay.SelectedIndex = 0;
        
    }
    protected void OnAddAddress(object sender,CommandEventArgs e)
    {

    }
    protected void Btn_submit_Click(object sender, EventArgs e)
    {
        DB database = new DB();
        database.getConnection();
        database.open();
        string username = ((User)Session["user"]).UserName.ToString();
        ListViewItem item;
        for(int i=0;i<Lv_info.Items.Count;i++)
        {
            item = Lv_info.Items[i];
            if(item.ItemType==ListViewItemType.DataItem)
            {
                CheckBox Cb = (CheckBox)item.FindControl("Cb_choose");
                if(Cb.Checked)
                {
                    string pro_id = ((Label)item.FindControl("pro_id")).Text;
                    string pro_num = ((Label)item.FindControl("cart_pro_num")).Text;
                    int price=int.Parse(((Label)item.FindControl("pro_price")).Text);
                    int int_pro_num = int.Parse(pro_num);
                    string total = (price * int_pro_num).ToString();
                    string payway = Rbl_pay.SelectedItem.Text;
                    string delviery_id = Rbl.SelectedValue;
                    
                    string str_cmd;
                    str_cmd = "delete from T_SHOPCART where cart_user_name = '" + username + "' and cart_pro_id = '" + pro_id + "'";
                    database.executeNonQuery(str_cmd);
                    str_cmd = "insert into T_ORDER (order_user_name,order_pro_id,order_pro_num,order_money,order_payway,order_ispaid,order_delivery_id) values ('" + username + "','" + pro_id + "','" + pro_num + "','" + total + "','" + payway + "',0,'" + delviery_id + "')";
                    database.executeNonQuery(str_cmd);
                   
                }
            }
            
        }
        database.close();
        Response.Redirect("~/ConfireOrder/Order_finished.aspx");
        
        
    }
}