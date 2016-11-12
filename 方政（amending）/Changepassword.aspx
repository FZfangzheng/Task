<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Changepassword.aspx.cs" Inherits="Changpassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        密码修改：<br />
        原密码：
        <asp:TextBox ID="txtpwd" runat="server" TextMode ="Password" ></asp:TextBox><br />
        修改密码：
        <asp:TextBox ID="txtpwd1" runat="server" TextMode ="Password" ></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="requiredfieldvalidator" runat ="server" ControlToValidate ="txtpwd1"></asp:RequiredFieldValidator>
        <asp:Button ID ="btnchang" runat ="server" Text="点击修改" OnClick ="changepassword" />
        <asp:Button ID="btnback" runat="server" Text="返回" PostBackUrl="~/Welcome.aspx" />
    </div>
    </form>
</body>
</html>
