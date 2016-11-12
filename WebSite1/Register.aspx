<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

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
                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp 注册页面</td>
        </tr>
        <tr>
            <td>
    
    <table>

        <tr>
            <td>
                昵称</td>
            <td>
                <asp:TextBox ID="txtnickname" runat="server" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat ="server" ErrorMessage ="昵称不能为空！" ControlToValidate ="txtnickname" ForeColor ="Red"></asp:RequiredFieldValidator> <br />
            </td>
        </tr>

    <tr>
        <td>
            用户名：</td>
        <td>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat ="server" ErrorMessage ="用户名不能为空！" ControlToValidate ="txtName" ForeColor ="Red"></asp:RequiredFieldValidator> <br />
        </td>
    </tr>
    <tr>
        <td>
            密码：</td>
        <td>
            <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>       
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat ="server" ErrorMessage ="密码不能为空！" ControlToValidate ="txtPwd" ForeColor ="Red"></asp:RequiredFieldValidator> <br />                    
        </td>
        </tr>
         <tr>
        <td>
           密码确认：</td>
        <td>
            <asp:TextBox ID="txtPasswordConfirm" runat ="server" TextMode="Password"></asp:TextBox>  
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat ="server" ErrorMessage ="密码确认不能为空！" ControlToValidate ="txtPasswordConfirm" ForeColor ="Red"></asp:RequiredFieldValidator> <br />  
             <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage ="前后密码不一致！" ControlToCompare="txtPwd" ControlToValidate="txtPasswordConfirm" ForeColor ="Red"></asp:CompareValidator> <br />                          
        </td>
        </tr>
        <tr>
            <td>
                 手机号码：</td>
          <td>
              <asp:TextBox ID ="txtphonenumble" runat ="server" onkeyup="this.value=this.value.replace(/\D/g,'')"></asp:TextBox>
          </td>
        </tr>

        <tr>
    </tr>
    <tr>
        <td>
            </td>
        <td>
            <asp:Button ID="BtnRegister" runat="server"  OnClick="BtnRegister_Click" Text="注册" />
        </td>
        <td>
           <asp:Button ID="btnReturn" runat="server" Text="返回"  PostBackUrl="~/Login.aspx" />
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
