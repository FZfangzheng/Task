<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Foundback.aspx.cs" Inherits="Foundback" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divfoundback1" runat="server" visible="true">
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
            <asp:Button ID="question" runat="server" OnClick ="Question" Text="密保找回" />
        </td>
        
           
        
    </tr>
    </table>
                </td>
            </tr>
            </table>
    
    </div>
        <div id="divfoundback2" runat="server" visible="false" >
            用户名：
            <asp:TextBox ID="username" runat="server" ></asp:TextBox><br />

            <asp:Button ID="step" runat="server" Text="下一步"  OnClick="BtnFound_Click2" />
             <asp:Button ID ="button2" runat ="server" PostBackUrl="~/Login.aspx" Text="返回" />
        </div>
        <div id="divfoundback3" runat="server" visible="false" >
            密保问题：
            <asp:Label ID="question1" runat="server" ></asp:Label><br />
            答案：
            <asp:TextBox ID="answer" runat="server" ></asp:TextBox><br />
            <asp:Button ID="back" runat ="server" Text="找回" OnClick="BtnFound_Click3"  />
             <asp:Button ID ="button3" runat ="server" PostBackUrl="~/Login.aspx" Text="返回" />
        </div>


    </form>
</body>
</html>
