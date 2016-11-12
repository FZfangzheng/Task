<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Welcome.aspx.cs" Inherits="Welcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       欢迎您：
        <asp:Label ID="lbname" runat="server"></asp:Label>
        <asp:Button ID="Btnchang" runat="server" Text="修改密码" PostBackUrl="~/Changepassword.aspx" />
        <asp:Button ID="btnquit" runat="server" Text="退出登录" OnClick ="up" /><br />
        查询图书：<br />
        请输入书名或作者名：
        <asp:TextBox ID="txtselect" runat="server" ></asp:TextBox>
        <asp:Button ID="btnselect" runat="server" Text="点击查询" OnClick="select" /><br />
        <asp:LinkButton ID="lbinformation" runat="server" Text="当前信息" PostBackUrl="~/User_information.aspx" ></asp:LinkButton>


    </div>
        <p>
        <asp:LinkButton ID="LinkButton1" runat="server" Text="当前借阅" PostBackUrl="~/Borrowbook_information.aspx" ></asp:LinkButton>


        </p>
    </form>
</body>
</html>
