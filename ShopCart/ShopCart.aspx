<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShopCart.aspx.cs" Inherits="ShopCart_ShopCart" EnableEventValidation="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript">
        function Reduce(obj,price)
        {
            obj.value = parseInt(obj.value) + 1;
            var element = document.getElementById("Lb_total");
            var total = parseInt(element.innerHTML);
            total += price;
            element.innerHTML = total;
            
        }
        function Plus(obj,price) 
        {
            if (parseInt(obj.value) > 1) {
                obj.value = parseInt(obj.value) - 1;
                var element = document.getElementById("Lb_total");
                var total = parseInt(element.innerHTML);
                total -= price;
                element.innerHTML = total;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="div_Border">
        
        <%--<asp:GridView runat="server" ID="Gd_Cart" OnRowDataBound="Gd_CartDataBound">
            <Columns>
                <asp:TemplateField HeaderText="选择">
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="Chk_pro" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="pro_id" HeaderText="商品编号" />
                <asp:BoundField DataField="pro_name" HeaderText="商品名称" />
                <asp:BoundField DataField="pro_price" HeaderText="商品价格" SortExpression="”pro_price“" />
                <asp:TemplateField HeaderText="商品数量">

                    <ItemTemplate>
                        <input runat="server" type="button" value="+" id="input_reduce"/>
                        <asp:TextBox runat="server" ID="Tb_num" Text='<%#Eval("cart_pro_num") %>'>

                        </asp:TextBox>
                        <input type="button" runat="server" value="-" id="input_plus"/>
                    </ItemTemplate>
                </asp:TemplateField>       
                <asp:TemplateField HeaderText="删除">
                    <ItemTemplate>
                        <asp:Button runat="server" ID="Btn_delete" Text="删除" OnCommand="OnDeleting" CommandArgument='<%#Eval("cart_pro_id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                你没有添加任何商品
            </EmptyDataTemplate>

        </asp:GridView>--%>
        <asp:ListView runat="server" ID="Lv_Cart"
            ItemPlaceholderID="itemPlaceHolder" OnItemDataBound="Lv_CartDataBound">
            <LayoutTemplate>
                <table>
                    <tr>
                        <th>
                            商品编号
                        </th>
                        <th>
                            商品名称
                        </th>
                        <th>
                            单价
                        </th>
                        <th>
                            数量
                        </th>
                        <th>
                            删除
                        </th>
                    </tr>
                <div runat="server" id="itemPlaceHolder">

                </div>
                    </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="Lb_pro_id" Text='<%#Eval("pro_id") %>'></asp:Label>
                        
                    </td>
                    <td>
                        <asp:Label runat="server" ID="Lb_pro_name" Text='<%#Eval("pro_name")%>'></asp:Label>
                        
                    </td>
                    <td>
                        <asp:Label runat=server ID="Lb_price" Text='<%#Eval("pro_price") %>'></asp:Label>
                    </td>
                    <td>
                        <input runat="server" id="input_reduce" type="button" value="+" />
                       <asp:TextBox runat=server ID="Tb_num" Text='<%#Eval("cart_pro_num") %>' ></asp:TextBox>
                        <input runat="server" id="input_plus" type="button" value="-" />
                    </td>
                    <td>
                        <asp:Button runat="server" Text="删除" ID="Btn_Delete" OnCommand="OnDeleting" CommandArgument='<%#Eval("pro_id") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <EmptyItemTemplate>
                您没有添加任何商品
            </EmptyItemTemplate>
            
        </asp:ListView>
        <asp:Label runat="server" ID="Lb_total" style="text-align:right"></asp:Label>
        <asp:Button runat="server" Text="去结算" ID="Btn_Submit" style="text-align:right" OnClick="Btn_Submit_Click" />
    </div>
    </div>
    </form>
</body>
</html>
