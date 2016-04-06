using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyClass;
using System.Web.UI.HtmlControls;
using System.Data;



public partial class ShopCart_ShopCart : System.Web.UI.Page
{
    private int total;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (((User)Session["user"]).IsLog == true)
        {
            if (!IsPostBack)
            {
                string name = ((User)Session["user"]).UserName.ToString();
                DB database = new DB();
                database.getConnection();
                database.open();
                string str_cmd;
                str_cmd = "select T_SHOPCART.*,T_USER.*,T_PRO.* from T_SHOPCART inner join T_PRO on T_SHOPCART.cart_pro_id =T_PRO.pro_id inner join T_USER on T_SHOPCART.cart_user_name =T_USER.user_name where T_USER.user_name = '" + name + "'";
                DataSet Ds = database.getDataSet(str_cmd);
                //为ListView添加绑定
                Lv_Cart.DataSource = Ds;
                Lv_Cart.DataBind();
                //Gd_Cart.DataSource = Ds;
                //Gd_Cart.DataBind();
                database.close();
                //添加javascript代码
            }
            
        }
        else
        {
            Response.Redirect("~/Login/Login.aspx");
        }
        //计算总价
        


        
    }
    //protected void Gd_CartDataBound(object sender,GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        e.Row.Attributes.Add("onmouseover", "b=this.style.backgroundColor;this.style.backgroundColor='#E1ECEE'");
    //        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=b");

    //        TextBox Tb = (TextBox)e.Row.FindControl("Tb_num");
    //        ((HtmlInputButton)e.Row.FindControl("input_reduce")).Attributes.Add("onclick", "Reduce(" + Tb.ClientID + ")");
    //        ((HtmlInputButton)e.Row.FindControl("input_plus")).Attributes.Add("onclick", "Plus(" + Tb.ClientID + ")");
    //    }
    //}
    protected void Lv_CartDataBound(object sender,ListViewItemEventArgs e)
    {
        if(e.Item.ItemType==ListViewItemType.DataItem)
        {
            TextBox Tb = (TextBox)e.Item.FindControl("Tb_num");
            Label Lb=(Label)e.Item.FindControl("Lb_price");
            ((HtmlInputButton)e.Item.FindControl("input_reduce")).Attributes.Add("onclick", "Reduce(" + Tb.ClientID + "," + int.Parse(Lb.Text) + ")");
            ((HtmlInputButton)e.Item.FindControl("input_plus")).Attributes.Add("onclick", "Plus(" + Tb.ClientID + "," + int.Parse(Lb.Text) + ")");
            DataRowView Drv = e.Item.DataItem as DataRowView;
            int num = int.Parse(Drv["cart_pro_num"].ToString());
            int price=int.Parse(Drv["pro_price"].ToString());
            total += num * price;
        }
        Lb_total.Text = total.ToString();
        
    }
   
    protected void OnDeleting(object sender,CommandEventArgs e)
    {
        string pro_id = e.CommandArgument.ToString();
        string name = ((User)Session["user"]).UserName.ToString();
        DB database = new DB();
        database.getConnection();
        database.open();
        string str_cmd;
        str_cmd = "delete from T_SHOPCART where cart_user_name = '" + name + "' and  cart_pro_id = '" + pro_id + "'";
        database.executeNonQuery(str_cmd);
        database.close();
        Response.Redirect("~/ShopCart/ShopCart.aspx");

    }
    protected void Btn_Submit_Click(object sender, EventArgs e)
    {
        DB database = new DB();
        database.getConnection();
        database.open();
        string username=((User)Session["user"]).UserName.ToString();
        ListViewItem item;
        for(int i=0;i<Lv_Cart.Items.Count;i++)
        {
           
             item = Lv_Cart.Items[i];
            if (item.ItemType == ListViewItemType.DataItem)
            {
                Label Lb_pro_id = (Label)item.FindControl("Lb_pro_id");
                string pro_id = Lb_pro_id.Text;
                TextBox Tb_num = (TextBox)item.FindControl("Tb_num");
                string pro_num = Tb_num.Text;
                string str_cmd = "update T_SHOPCART set cart_pro_num = '" + pro_num + "' where cart_user_name = '" + username + "' and cart_pro_id = '" + pro_id + "'";
                //string str_cmd = "insert into T_ORDER (order_user_name,order_pro_id,order_pro_num,order_money) values ('" + username + "','" + pro_id + "','" + pro_num + "','" + Total + "')";
                database.executeNonQuery(str_cmd);
            }
            
        }
        database.close();
        Response.Redirect("~/ConfireOrder/ConfireOrder.aspx");
    }
}