<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="Users" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Repeater ID="RptUser" runat="server" OnItemCommand="RptUser_ItemCommand">
            <Headertemplate>
                <table>
                    <tr>
                        <th>昵称</th>
                        <th>用户名</th>
                        <th>密码</th>
                        <th>手机号码</th>
                        <th>删除</th>
                        <th>修改</th>
                        <th>借阅情况查询</th>
                    </tr>
            </Headertemplate>

            <ItemTemplate>
                <tr>
                    <td><%# Eval("nickname") %></td>
                    <td><%# Eval("username") %></td>
                    <td><%# Eval("password") %></td>
                    <td><%# Eval("phonenumble") %></td>
                    <td><asp:LinkButton ID="lbtDelete" runat="server" Text="删除" CommandName="Delete" CommandArgument='<%#Eval("id") %>'></asp:LinkButton></td>
                    <td><asp:LinkButton ID="lbtEditor" runat="server" Text="修改" PostBackUrl='<%#"Editor_user.aspx?id="+Eval("id")%>'></asp:LinkButton></td>
                    <td><asp:LinkButton ID="lbtSelect" runat="server" Text="查询" PostBackUrl='<%#"Manage_user_borrowbook.aspx?id="+Eval("id")%>'></asp:LinkButton> </td>
                </tr>

            </ItemTemplate>

            <FooterTemplate>
                </table>

            </FooterTemplate>


        </asp:Repeater>
             <asp:Button ID="btnUp" runat="server" Text="上一页" OnClick="btnUp_Click" />
        <asp:Button ID="btnDown" runat="server" Text="下一页"  OnClick="btnDown_Click"/>
        <asp:Button ID="btnFirst" runat="server" Text="首页" OnClick="btnFirst_Click" />
        <asp:Button ID="btnLast" runat="server" Text="尾页"  OnClick="btnLast_Click"/>
        页次：<asp:Label ID="lbNow" runat="server" Text="1"></asp:Label>
        /<asp:Label ID="lbTotal" runat="server" Text="1"></asp:Label>
        转<asp:TextBox ID="txtJump" Text="1" runat="server" Width="16px" onkeyup="this.value=this.value.replace(/\D/g,'')"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat ="server" ControlToValidate ="txtJump" ></asp:RequiredFieldValidator> 
        <asp:Button ID="btnJump" runat="server" Text="Go"  OnClick="btnJump_Click"/>
          <asp:Button ID="btnback" runat="server" Text="返回" PostBackUrl="~/Manager_use.aspx" />
    </div>
    </form>
</body>
</html>
