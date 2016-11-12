<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <br />
    <table>
        <tr>
            <td>
                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp 登录页面</td>
        </tr>
        <tr>
            <td>
    
    <table>
    <tr>
        <td>
            用户名：</td>
        <td>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            密码：</td>
        <td>
            <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>                           
        </td>
        </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="BtnLogin" runat="server"  OnClick="BtnLogin_Click" Text="登录" />
        </td>
          <td>
            <asp:Button ID="BtnRegister" runat="server" PostBackUrl="~/Register.aspx" Text="注册" />
        </td>
        <td>
            <asp:Button ID ="BtnFoundback" runat ="server" PostBackUrl ="~/Foundback.aspx" Text =" 密码找回 " Height="22px" Width="67px" />
            </td>
    </tr>
    </table>
                </td>
            </tr>
            </table>
    
    </div>
    
    </form>
</body>
</html>
