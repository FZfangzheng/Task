<%@ Page Language="C#" AutoEventWireup="true" CodeFile="APersonal_center.aspx.cs" Inherits="Personal_center" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lable" runat="server" ></asp:Label>
        &nbsp;<asp:LinkButton ID="personal_center1" runat="server" OnClick="personal_center_Click" Text="个人中心" ></asp:LinkButton>
        &nbsp;<asp:DropDownList ID="myhomepage" runat="server" >
            <asp:ListItem >个人中心</asp:ListItem>
            <asp:ListItem >。。。。</asp:ListItem>
        </asp:DropDownList>
        &nbsp;<asp:LinkButton ID="friend" runat="server" PostBackUrl="~/Friend.aspx" Text="好友"></asp:LinkButton>
        &nbsp;<asp:LinkButton ID="special" runat="server" PostBackUrl="~/Special.aspx" Text="特别关心"></asp:LinkButton>
        &nbsp;<asp:LinkButton ID="set" runat="server" PostBackUrl="~/Set.aspx" Text="设置权限"></asp:LinkButton>
        &nbsp;<asp:LinkButton ID="out" runat="server" OnClick="out_Click" Text="注销"></asp:LinkButton><br />
        <asp:Label ID="lbname" runat="server"></asp:Label>
        <asp:ImageButton ID="Image1" runat="server" ToolTip="更换头像" OnClick="Image1_Click" Height="77px" Width="63px" />
        <asp:Panel ID="panel" runat="server" Visible="false"  >
              <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="Button1" runat="server" Text="上传" OnClick="btnupload_Click" /><br />
        </asp:Panel>
         <asp:LinkButton ID="homepage" runat="server" PostBackUrl="~/Homepage.aspx" Text="主页"></asp:LinkButton>
         &nbsp;<asp:LinkButton ID="dairy" runat="server" PostBackUrl="~/Dairy.aspx" Text="日志"></asp:LinkButton>
         &nbsp;<asp:LinkButton ID="photo" runat="server" PostBackUrl="~/Photo.aspx" Text="相册"></asp:LinkButton>
         &nbsp;<asp:LinkButton ID="message" runat="server" PostBackUrl="~/Message.aspx" Text="留言板"></asp:LinkButton>
         &nbsp;<asp:LinkButton ID="say" runat="server" PostBackUrl="~/Say.aspx" Text="说说"></asp:LinkButton>
         &nbsp;<asp:LinkButton ID="person" runat="server" PostBackUrl="~/Person.aspx" Text="个人档"></asp:LinkButton><br />
        <asp:TextBox ID="saysay" runat="server" Height="47px" Width="255px" TextMode="MultiLine"></asp:TextBox>
        <asp:Button ID="printsay" runat="server" OnClick="printsay_Click"  Text="发表" />

         <asp:Repeater ID="RptPerson" runat="server"  OnItemDataBound="RptPerson_ItemDataBound">
            <ItemTemplate>
                <h2>姓名：
                <%#Eval("username") %></h2>
                <br />
                <asp:Repeater ID="RptSay" runat="server" >
                    <ItemTemplate>
                        <%#Eval("say") %>
                        <br />
                    </ItemTemplate>
                </asp:Repeater>

            </ItemTemplate>
        </asp:Repeater>
    
    </div>
    </form>
</body>
</html>
