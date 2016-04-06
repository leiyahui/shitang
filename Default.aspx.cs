using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyClass;
using System.Data.SqlClient;
using System.Data;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       //创建子菜单
        if(Session["res_id"]==null)
        {
            createSubMenu("1");
        }
        else
        {
            string value = Session["res_id"].ToString();
            createSubMenu(value);
        }
        //得到食品列表的selectCommand
       string selectCmd;
       string win= Request.QueryString["win_id"];
        if(win==null)
        {
            string flo;
            flo = Request.QueryString["flo_id"];
            if(flo==null)
            {
                string res;
                if (Session["res_id"] == null)
                {
                    res = "1";
                }
                else
                {
                    res = Session["res_id"].ToString();
                }
                selectCmd = "select T_PRO.*,T_IMAGE.image_url from T_FLO inner join T_WIN on T_FLO.flo_id=T_WIN.win_flo_id inner join T_PRO on T_WIN.win_id = T_PRO.pro_win_id inner join T_IMAGE on T_PRO.pro_image_id =T_IMAGE.image_id where T_FLO.flo_res_id =" + res + "order by T_PRO.pro_eva desc";

            }
            else
            {
                selectCmd = "select T_PRO.*,T_IMAGE.image_url from T_PRO inner join T_WIN on T_PRO.pro_win_id =T_WIN.win_id inner join T_IMAGE on T_PRO.pro_image_id =T_IMAGE.image_id where T_WIN.win_flo_id = " + flo + " order by T_PRO.pro_eva desc";
            }
        }
        else
        {
            selectCmd = "select T_PRO.*,T_IMAGE.image_url from T_PRO inner join T_IMAGE on T_PRO.pro_image_id =T_IMAGE.image_id where pro_win_id =" + win;
        }
      
        DB database = new DB();
        database.getConnection();
        database.open();
        DataSet Ds = database.getDataSet(selectCmd);
        ListView1.DataSource = Ds;
        ListView1.DataBind();
        
    }
    #region createSubMenu(string i)
    /// <summary>
    /// 创建子菜单
    /// </summary>
    /// <param name="i"></param>
    protected void createSubMenu(string i)
    {
        HyperLink am_0;
        HyperLink am_1;
        Panel menuset;
        Panel submenu;
        Panel clrmenu;

        DB database = new DB();
        database.getConnection();
        database.open();
        string str="select T_FLO.*,T_WIN.* from T_FLO inner join T_WIN on T_FLO.flo_id = T_WIN.win_flo_id where T_FLO.flo_res_id = "+ i;
        SqlDataReader Datar = database.getDataReader(str);
        while(Datar.Read())
        {
            string sm_0 = Datar["flo_id"].ToString();
            menuset = (Panel)pop_menu.FindControl("div_menuset_" + sm_0);
            if(menuset==null)
            {
                menuset = new Panel();
                menuset.ID = "div_menuset_" + sm_0;
                menuset.CssClass = "menuset " +"fl";
                pop_menu.Controls.Add(menuset);
            }
            menuset=(Panel)pop_menu.FindControl("div_menuset_"+sm_0);

            am_0 = (HyperLink)menuset.FindControl("am_0" + sm_0);
            if(am_0==null)
            {
                am_0 = new HyperLink();
                am_0.NavigateUrl = "~/Default.aspx?flo_id="+ Datar["flo_id"].ToString();
                am_0.ID = "am_0" + sm_0;
                am_0.Text = Datar["flo_name"].ToString();
                am_0.CssClass = "m0";
                menuset.Controls.Add(am_0);
            }
            am_0 = (HyperLink)menuset.FindControl("am_0" + sm_0);
            if(!(Datar["win_name"] is DBNull))
            {
                submenu = (Panel)pop_menu.FindControl("div_submenu_" + sm_0);
                if (submenu == null)
                {
                    submenu = new Panel();
                    submenu.CssClass = "submenu " + "fl";
                    submenu.ID = "div_submenu_" + sm_0;
                    pop_menu.Controls.Add(submenu);
                }
                submenu = (Panel)pop_menu.FindControl("div_submenu_" + sm_0);
                clrmenu = (Panel)pop_menu.FindControl("div_clrmenu_" + sm_0);
                if(clrmenu==null)
                {
                    clrmenu = new Panel();
                    clrmenu.CssClass = "clr";
                    clrmenu.ID = "div_clrmenu_" + sm_0;
                    pop_menu.Controls.Add(clrmenu);
                }
                
               
                am_1 = new HyperLink();
                am_1.NavigateUrl = "~/Defalut.aspx?win_id=" + Datar["win_id"].ToString();
                am_1.ID = "am_1" + Datar["win_id"].ToString();
                am_1.CssClass = "m1";
                am_1.Text = Datar["win_name"].ToString();
                submenu.Controls.Add(am_1);
            }

            
        }
        database.close();
           
    }
    #endregion
    protected void Btn_H_Click(object sender, EventArgs e)
    {
        Session.Add("res_id", 1);
        Response.Redirect("~/Default.aspx");
        
    }

    protected void Btn_W_Click(object sender, EventArgs e)
    {
        Session.Add("res_id", 2);
        Response.Redirect("~/Default.aspx");
        
    }
    protected void OnAddCart(object sender,CommandEventArgs e)
    {
        if(!((User)Session["user"]).IsLog)
        {
            Response.Redirect("~/Login/Login.aspx");
        }
        else
        {
            string user = (((User)Session["user"]).UserName).ToString();
            string pro_id;
            pro_id = e.CommandArgument.ToString();
            DB database = new DB();
            database.getConnection();
            database.open();
            string cmdstr;
            cmdstr = "select count(*) from T_SHOPCART where cart_user_name = '" + user + "' and cart_pro_id = '" + pro_id + "'";
            int i=Convert.ToInt32(database.executeScalar(cmdstr));
            if (i > 0)
            {
                cmdstr = "update T_SHOPCART set cart_pro_num = cart_pro_num + 1 where cart_user_name = '" + user + "'";
                database.executeNonQuery(cmdstr);
            }
            else
            {
                cmdstr = "insert into T_SHOPCART (cart_user_name,cart_pro_id,cart_pro_num) values ('" + user + "','" + pro_id + "','1"+"')";
                database.executeNonQuery(cmdstr);
            }
            database.close();
        }


    }
}