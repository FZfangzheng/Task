<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Foundback.aspx.cs" Inherits="Foundback" %>

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
                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp 找回页面</td>
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
            手机号码：</td>
        <td>
            <asp:TextBox ID="txtPho" runat="server"></asp:TextBox>                           
        </td>
        </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="foundback" runat="server"  OnClick="BtnFound_Click" Text=" 找回 " />
             <asp:Button ID ="button1" runat ="server" PostBackUrl="~/Login.aspx" Text="返回" />
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
