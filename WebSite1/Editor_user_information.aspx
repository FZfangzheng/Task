<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Editor_user_information.aspx.cs" Inherits="Editor_user_information" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        昵称：<asp:TextBox ID="txtnickname" runat="server" ></asp:TextBox>
        手机号码：<asp:TextBox ID="txtphone" runat="server"></asp:TextBox>
        <br />
      
   

        <asp:Button ID="btnSubmit" runat="server"  Text="修改" OnClick="amend"/>
        <asp:Button ID="btnback" runat="server" Text="返回" PostBackUrl="~/User_information.aspx" />
    </div>
    </form>
</body>
</html>
