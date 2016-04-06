<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Evaluate.aspx.cs" Inherits="Eva_Evaluate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
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
            width:250px;
        }
        .div_submit
        {
            text-align:center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="safewidth">
        <div class="fl">
    <asp:Label runat="server" ID="Lb_sore" Text="评分"></asp:Label>
            </div>
        <div class="fl">
     <asp:RadioButtonList runat="server" ID="Rbl_sore" RepeatDirection="Horizontal" CellPadding="5" CellSpacing="1">

            <asp:ListItem Text="1"></asp:ListItem>
            <asp:ListItem Text="2"></asp:ListItem>
            <asp:ListItem Text="3"></asp:ListItem>
            <asp:ListItem Text="4"></asp:ListItem>
            <asp:ListItem Text="5"></asp:ListItem>
        </asp:RadioButtonList>
            </div>
        <div class="clr"></div>
        <div class="fl">
       <asp:Label runat="server" ID="Lb_idea" Text="心得"></asp:Label>
            </div>
        <div class="fl">
        <asp:TextBox runat="server" ID="Tb_idea" TextMode="MultiLine"></asp:TextBox>
            </div>
        <div class="clr"></div>
        <div class="div_submit">
            <asp:Button runat="server" ID="Btn_submit" Text="提交" OnClick="Btn_submit_Click" />
        </div>
    </div>
        
    </form>
</body>
</html>
