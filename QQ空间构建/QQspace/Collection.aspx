<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Collection.aspx.cs" Inherits="Collection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:LinkButton ID="say" runat="server" Text="说说" OnClick="say_Click" ></asp:LinkButton>
    <asp:LinkButton ID="dairy" runat="server" Text="日志" OnClick="dairy_Click" ></asp:LinkButton>
    <asp:Panel ID="pnsay" runat="server" Visible="false" >
    <asp:Repeater ID="say_dairy" runat="server" OnItemCommand="say_dairy_ItemCommand" >
        <HeaderTemplate >
            <table>

        </HeaderTemplate>
        <ItemTemplate >                        
          <tr>
              <td>
                   <h2>
                <%# Eval("nickname") %>
                <%#Eval("username") %>:</h2>
                <h3> <%#Eval("say") %></h3>
              </td>
          </tr>
        </ItemTemplate>
        <FooterTemplate >
            </table>
        </FooterTemplate>
    </asp:Repeater>
    </asp:Panel>
    <asp:Panel ID="pndairy" runat="server" Visible ="false" >


    </asp:Panel>
</asp:Content>

