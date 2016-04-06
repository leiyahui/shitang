<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConfireOrder.aspx.cs" Inherits="ConfireOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Style/order.css" rel="stylesheet" />
    <script src="../App_Script/jquery-1.8.2.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#Btn_more").click(function () {

                var name = $(".non_first_address").CssClass;
                alert(name);
                $(".non_first_address").style.display = "block";
                alert("hello world");
            });
        })
        function AddAddress()
        {
            window.showModalDialog("Address.aspx", null, "center=yes;dialogWidth=400px;dialogHeight=200px");
        }
       
    </script>
    <style type="text/css">
        .first_address, .non_first_address
{
    display:block;
}
.non_first_address
{
    display:none;
}
.fr
{
    float:right;
}
.fl
{
    float:left;
}
.clr
{
    clear:both;
}
.safewidth
{
    width:300px;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="safewidth">
    <div id="div_receive_info">
        <div id="div_address" runat="server">
            <asp:RadioButtonList runat="server" ID="Rbl"></asp:RadioButtonList>
            <%--动态添加--%>
        
            </div>
       
    </div>
        <div id="div_pay_info">
            <asp:Label runat="server" Text="请选择付款方式"></asp:Label>
            <br />
            <br />
            <asp:RadioButtonList runat="server" ID="Rbl_pay">
                <asp:ListItem>货到付款</asp:ListItem>
                <asp:ListItem>支付宝</asp:ListItem>

            </asp:RadioButtonList>
            
        </div>
        <div id="div_order_info">
            <asp:Label runat="server" Text="送货清单"></asp:Label>
            <br />
            <asp:ListView runat="server" ID="Lv_info"
                 ItemPlaceholderID="itemPlaceHolder">
                <LayoutTemplate>
                    <table>
                        <tr>
                            <th>
                                选择
                            </th>
                            <th>
                                商品编号
                            </th>
                            <th>
                                商品名称
                            </th>
                            <th>
                                商品单价
                            </th>
                            <th>
                                数量
                            </th>
                        </tr>
                        <div runat="server" id="itemPlaceHolder"></div>
                    </table>
                    
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><asp:CheckBox  runat="server" ID="Cb_choose"  /></td>
                        <td>
                            <asp:Label runat="server" ID="pro_id" Text='<%#Eval("pro_id") %>'></asp:Label>
                           
                        </td>
                        <td>
                           <asp:Label runat="server" ID="pro_name" Text='<%#Eval("pro_name") %>'></asp:Label>
                        </td>
                        <td>
                           <asp:Label runat="server" ID="pro_price" Text='<%#Eval("pro_price") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="cart_pro_num" Text=' <%#Eval("cart_pro_num")%>'></asp:Label>
                           
                        </td>
                    </tr>
                </ItemTemplate>

            </asp:ListView>
            <asp:Button runat="server" ID="Btn_submit"  Text="提交订单" OnClick="Btn_submit_Click"/>

            
        </div>
    </div>
    </form>
</body>
</html>
