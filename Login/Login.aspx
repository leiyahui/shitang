<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div style="text-align:center">
        <div id="username">
            <asp:Label runat="server" Text="用户名"></asp:Label>
            <asp:TextBox runat="server" ID="Tb_name"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Tb_name" Text="用户名不能为空"></asp:RequiredFieldValidator>
        </div>
        <div id="passwd">
            <asp:Label runat="server" Text="密  码"></asp:Label>
            <asp:TextBox runat="server" ID="Tb_passwd"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Tb_passwd" Text="密码不能为空"></asp:RequiredFieldValidator>
        </div>
        <div>
        <asp:CheckBox runat="server" ID="Chk_islog" Text="自动登陆" />
            </div>
        <asp:Button runat="server" ID="Btn_log"  Text="登陆" OnClick="Btn_log_Click"/>
    
    </div>
    </div>
    </form>
</body>
</html>
