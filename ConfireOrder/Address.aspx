<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Address.aspx.cs" Inherits="ConfireOrder_Address" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label runat="server" ID="Lb1" Text="新增收货人地址"></asp:Label>
        <div>
           
            <br />
            <div id="div_place">
                <asp:Label runat="server" ID="Lb_plcae" Text="请选择地址"></asp:Label>
                <asp:DropDownList runat="server" ID="Dl_building">
                    <asp:ListItem Value="1">一斋</asp:ListItem>
                    <asp:ListItem Value="2">二斋</asp:ListItem>
                    <asp:ListItem Value="3">三斋</asp:ListItem>
                    <asp:ListItem Value="4">四斋</asp:ListItem>
                    <asp:ListItem Value="5">五斋</asp:ListItem>
                    <asp:ListItem Value="6">六斋</asp:ListItem>
                    <asp:ListItem Value="7">七斋</asp:ListItem>
                    <asp:ListItem Value="8">八斋</asp:ListItem>
                    <asp:ListItem Value="9">九斋</asp:ListItem>
                    <asp:ListItem Value="10">十斋</asp:ListItem>
                    <asp:ListItem Value="11">十一斋</asp:ListItem>
                    <asp:ListItem Value="12">十二斋</asp:ListItem>
                </asp:DropDownList>
                 <asp:DropDownList runat="server" ID="Dl_floor">
                    <asp:ListItem Value="1">一楼</asp:ListItem>
                    <asp:ListItem Value="2">二楼</asp:ListItem>
                    <asp:ListItem Value="3">三楼</asp:ListItem>
                    <asp:ListItem Value="4">四楼</asp:ListItem>
                    <asp:ListItem Value="5">五楼</asp:ListItem>
                    <asp:ListItem Value="6">六楼</asp:ListItem>
                    <asp:ListItem Value="7">七楼</asp:ListItem>
                    <asp:ListItem Value="8">八楼</asp:ListItem>
                    <asp:ListItem Value="9">九楼</asp:ListItem>
                    <asp:ListItem Value="10">十楼</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div id="div_detail">
                <asp:Label runat="server" ID="Lb_detail" Text="详细地址"></asp:Label>
                <asp:TextBox runat="server" ID="Tb_detail" ></asp:TextBox>
            </div>
            <div id="div_phone">
                <asp:Label runat="server" ID="Lb_phone" Text="手机号码"></asp:Label>
                <asp:TextBox runat="server" ID="Tb_phone" ></asp:TextBox>
            </div>
            <div id="div_save">
                <asp:Button runat="server" Text="保存收货人信息" ID="Btn_save" OnClick="Btn_save_Click" OnClientClick="window.close()" />
            </div>
        </div>
    </div>

    </form>
</body>
</html>
