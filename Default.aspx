<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    <script src="App_Script/jquery-1.8.2.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".menuset").mouseenter(function () {
                $("+.submenu",this).show();
            });
            $(".menuset").mouseleave(function () {
                $(".menuset+ .submenu").hide();
            });
        });
    </script>
 <style type="text/css">
  a.m0
{
    padding:2px;
    border:2px solid black;
    margin:5px;
   
    font-size:40px;
    text-decoration:none !important;
}
 a.m1
{
    padding:2px;
    border:2px solid yellow;
    margin:2px;
    color:grey;
    font-size:12px;
    text-decoration:none !important;
   
}
 .menuset
 {
     width:102px;
     text-align:center;
 }
 .submenu
 {
     display:none;
 }
 .image
 {
     width:150px;
 }
 /*子菜单的宽度*/
 #pop_menu
{
     width:300px;
 }
 .mainContent 
 {
     width:610px;
 }

     </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph1" Runat="Server">
    <div class="fl">
        <div id="res">
            <asp:Button  runat="server" Text="鸿博园" ID="Btn_H" OnClick="Btn_H_Click"/>
            <asp:Button runat="server"  Text="万秀园" ID="Btn_W" OnClick="Btn_W_Click" />
        </div>
        <div id="pop_menu" runat="server">

        </div>
    </div>
    
        <<div class ="mainContent fr">
            <div class="lv_prodList">
                <asp:ListView ID="ListView1" runat="server"
                    GroupPlaceholderID="groupHolder"
                    ItemPlaceholderID="itemHolder"
                    GroupItemCount="3"
                >
                    <LayoutTemplate>
                       <div runat="server" id="groupHolder" ></div>  
                       <div class="clr"></div>                       
                    </LayoutTemplate>


                    <GroupTemplate>
                        <div runat="server" id="itemHolder"></div>
                    </GroupTemplate>


                    <GroupSeparatorTemplate>
                        <hr class="clr"  />
                    </GroupSeparatorTemplate>


                    <ItemTemplate>
                        <div>
                        <div>
                        <a href='<%#Eval("pro_id","proDetailed.aspx?proid={0}") %>'>
                            <asp:Image ImageUrl='<%#Eval("image_url") %>' runat="server" />
                        </a>
                         </div>
                        <div>
                          <asp:Label runat="server" Text='<%#Eval("pro_name") %>'/>
                          <asp:Button runat="server" ID="Btn_AddCart" Text="加入购物车" CommandArgument='<%#Eval("pro_id") %>' OnCommand="OnAddCart"/>
                         </div>
                            </div>
                    </ItemTemplate>


                </asp:ListView>
            
     
            </div>
            </div>
       
  
     
    <div class="clr">

    </div>
</asp:Content>

