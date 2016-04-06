<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="Order_Order" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="border">
       <%-- <asp:GridView runat="server" ID="Gv_order">
            <Columns>
                <asp:BoundField DataField="order_id" HeaderText="订单号" />
                <asp:BoundField DataField="pro_name" HeaderText="商品名称" />
                <asp:BoundField DataField="order_pro_num" HeaderText="数量" />
                <asp:BoundField DataField="order_money" HeaderText="总价" />
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <asp:Button runat="server" ID="Btn_evalute" OnCommand="OnCommandEvaluate" Text="评价" CommandArgument='<%#Eval("pro_id") %>' />
                        <asp:Button runat="server" ID="Btn_buy" OnCommand="OnCommandBuy" Text="继续购买" CommandArgument='<%#Eval("pro_id") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>


        </asp:GridView>--%>
        <asp:ListView runat="server" ID="Lv_order"
           ItemPlaceholderID="itemPlaceholder">
            <LayoutTemplate>
                <table>
                    <tr>
                        <th>
                            订单号
                        </th>
                        <th>
                            商品名称
                        </th>
                        <th>
                            数量
                        </th>
                        <th>
                            总价
                        </th>
                        <th>
                            操作
                        </th>
                    </tr>
                <div runat="server" id="itemPlaceholder"></div>
                    </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Eval("order_id") %>
                    </td>
                    <td>
                        <%#Eval("pro_name") %>
                    </td>
                    <td>
                        <%#Eval("order_pro_num") %>
                    </td>
                    <td>
                        <%#Eval("order_money") %>
                    </td>
                    <td>
                        <asp:Button runat="server" ID="Btn_evalute" OnCommand="OnCommandEvaluate" Text="评价" CommandArgument='<%#Eval("pro_id") %>' />
                        <asp:Button runat="server" ID="Btn_buy" OnCommand="OnCommandBuy" Text="继续购买" CommandArgument='<%#Eval("pro_id") %>'/>
                    </td>
                </tr>
                
            </ItemTemplate>
        </asp:ListView>
    
    </div>
    </form>
</body>
</html>
