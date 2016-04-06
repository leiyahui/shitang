<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProDetailed.aspx.cs" Inherits="ProDetailed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        #Cph1_Image_pro
        {
            width:150px;
            height:200px;
        }
        .inform
        {
            font-size:20px;
        }
        .inform div
        {
            height:50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph1" Runat="Server">
    <div class="fl image">
    <asp:Image runat="server" ID="Image_pro" />
        </div>
    <div class="fl inform">
        <div>
        <asp:Label runat="server" Text="产品编号:"></asp:Label>
        <asp:Label runat="server" ID="Lb_id"></asp:Label>
        </div>
        <div>
        <asp:Label runat="server" Text="产品名称:"></asp:Label>
        <asp:Label runat="server" ID="Lb_name"></asp:Label>
        </div>
        <div>
        <asp:Label runat="server" Text="产品价格:"></asp:Label>
        <asp:Label runat="server" ID="Lb_price"></asp:Label>
        </div>
        <div>
        <asp:Button runat="server" ID="Btn_addshopCart" Text="加入购物车" OnClick="Btn_addshopCart_Click" />
        </div>
    </div>
    <div class="clr">

    </div>
    <div id="eva">
        <asp:ListView runat="server" ID="Lv_eva"
           ItemPlaceholderID="itemPlaceholder">
            <LayoutTemplate>
                
                    <table>
                        <tr>
                            <th>
                                商品评价
                            </th>
                            <th>
                                规格参数
                            </th>
                        </tr>
                        <div runat="server" id="itemPlaceholder"></div>
                    </table>
                
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Eval("eva_text") %>
                        
                    </td>
                    <td>
                        <%#Eval("eva_sore") %>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>

