<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Login_Regist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    
    <script type="text/javascript">
        function checkpasswd()
        {
            var Pwd1 = document.getElementById("Tb_passwd").value;
            var Pwd2 = document.getElementById("Tb_passwd2").value;
            
            if(Pwd1!=Pwd2)
            {
                
                document.getElementById("Lb2").value = "两次输入的密码不一致";
                return false;
            }
            return true;

        }
    </script>
    

</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center">
        <div id="username"> 
            <asp:Label runat="server" ID="Lb_name" Text="用户名"></asp:Label>
            <asp:TextBox runat="server" ID="Tb_name"></asp:TextBox>
            <asp:Label runat="server" ID="Lb1"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Tb_name" runat="server" Text="用户名不能为空"></asp:RequiredFieldValidator>
        </div>
        <div id="passwd">
            <asp:Label runat="server" ID="Lb_passwd" Text="密 码"></asp:Label>
            <asp:TextBox runat="server" ID="Tb_passwd"></asp:TextBox>
            
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Tb_passwd" runat="server" Text="密码不能为空"></asp:RequiredFieldValidator>
        </div>
        <div id="passwd2">
            <asp:Label runat="server" ID="Lb_passwd2" Text="请再输一遍密码">
            </asp:Label>
            
            <asp:TextBox runat="server" ID="Tb_passwd2">

            </asp:TextBox> 
            <asp:Label runat="server" ID="Lb2"></asp:Label>
            
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Tb_passwd2" Text="密码不能为空"></asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:Button runat="server" ID="Btn_Register"  Text="注册" OnClientClick="checkpasswd()" OnClick="Btn_Register_Click"/>
        </div>
    
    </div>
    </form>
</body>
</html>
