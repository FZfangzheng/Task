<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Newbook.aspx.cs" Inherits="Newbook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        添加新书：<br />
        <br />
        书名：<asp:TextBox ID="txtbook" runat ="server" ></asp:TextBox><br />
        作者：<asp:TextBox ID="txtauthor" runat ="server" ></asp:TextBox><br />
        数量：<asp:TextBox ID="txtcount" runat ="server" ></asp:TextBox><br />
        <asp:Button ID="btnupdata" runat="server" Text="点击添加" OnClick="upbook" />
        <asp:Button ID="btnback" runat="server" Text="返回" PostBackUrl="~/Books.aspx" />
    
    </div>
    </form>
</body>
</html>
