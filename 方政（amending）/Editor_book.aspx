﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Editor_book.aspx.cs" Inherits="Editor_book" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      书名：<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <br />
        作者：<asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox>
        <br />
        数量：<asp:TextBox ID="txtCount" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnSubmit" runat="server"  Text="修改" OnClick="amend"/>
        <asp:Button ID="btnback" runat="server" Text="返回" PostBackUrl="~/Books.aspx" />
    </div>
    </form>
</body>
</html>
