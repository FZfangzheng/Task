<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manager_use.aspx.cs" Inherits="Manager_use" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        欢迎您,管理员：
        <asp:Label ID="lbname" runat="server"></asp:Label><br />
      
     <asp:Button ID ="btnbook" runat ="server" PostBackUrl="~/Books.aspx" Text="图书管理"/>
        <asp:Button ID ="btnuser" runat ="server" PostBackUrl="~/Users.aspx" Text ="用户管理" />
         <asp:Button ID="btnquit" runat="server" Text="退出登录" OnClick="exit" /><br />
        
    </div>
    </form>
</body>
</html>
