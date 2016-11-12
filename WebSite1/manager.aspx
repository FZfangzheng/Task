<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manager.aspx.cs" Inherits="manager" %>

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
                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp 管理员登录页面</td>
        </tr>
        <tr>
            <td>
    
    <table>
    <tr>
        <td>
            管理员名：</td>
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
    </tr>
    <tr>
        <td>
            </td>
        <td>
            <asp:Button ID="BtnLogin" runat="server"  OnClick="BtnManager_Click" Text="登录" />
             <asp:Button ID="btnquit" runat="server" Text="用户登录界面" PostBackUrl="~/Login.aspx" /><br />
        </td>
          <td> 
        </td>
        <td>
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
