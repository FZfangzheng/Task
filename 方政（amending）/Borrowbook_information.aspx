<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Borrowbook_information.aspx.cs" Inherits="Borrowbook_information" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        借阅情况如下：
     <asp:Repeater ID="RptBook" runat="server" OnItemCommand="RptBook_ItemCommand" >
            <HeaderTemplate> 
                <table>
                    <tr>
                        <th>书名</th>
                        <th>作者</th>
                        <th>借阅时间</th>
                        <th>到期时间</th>
                        <th>还书</th>
                      
                        
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td><%# Eval("bookname")%></td>
                    <td><%# Eval("author")%></td>
                    <td><%# Eval("time") %></td>
                    <td><%# Eval("endtime") %></td>
                     <td><asp:LinkButton ID="lbtreturn" runat="server" Text="还书" CommandName="Return" CommandArgument='<%#Eval("NO") %>' ></asp:LinkButton></td>
                   
                   
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
        <asp:Button ID="btnJump" runat="server" Text="Go"  OnClick="btnJump_Click"/>
        <asp:Button ID="btnback" runat="server" Text="返回" PostBackUrl="~/Welcome.aspx" />
    </div>
    </form>
</body>
</html>
