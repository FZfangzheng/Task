<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User_information.aspx.cs" Inherits="User_information" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <asp:Repeater ID="RptBook" runat="server" >  
            <HeaderTemplate> 
                <table>
                    <tr>
                        <th>昵称</th>
                       <th>用户名</th>
                        <th>手机号码</th> 
                        
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td><%# Eval("nickname") %></td>
                    <td><%# Eval("username")%></td>
                    <td><%# Eval("phonenumble")%></td>
                   
                    
                   
                </tr>
            </ItemTemplate>

            <FooterTemplate>
               </table>

            </FooterTemplate>
     

        </asp:Repeater>
       
         <asp:LinkButton ID="lbtEditor" runat="server" Text="修改" PostBackUrl="~/Editor_user_information.aspx"></asp:LinkButton>
          <asp:Button ID="btnback" runat="server" Text="返回" PostBackUrl="~/Welcome.aspx" />
    </div>
    </form>
</body>
</html>
