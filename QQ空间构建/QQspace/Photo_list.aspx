<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Photo_list.aspx.cs" Inherits="Photo_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:FileUpload ID="upphoto" runat="server" />
    <asp:Button ID="btnphoto" runat="server" Text="上传照片" OnClick="btnphoto_Click" />
   
    <asp:Repeater ID="Rptphoto" runat="server" OnItemCommand="Rptphoto_ItemCommand" >  
            <HeaderTemplate> 
                <table>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td>
                        <img src='<%# Eval("photo") %>' runat="server" width="100" height="100" />
                    </td>
                    <td>点赞：<%# Eval("good")%></td>
                    <td><asp:LinkButton ID="lbtGood" runat="server" Text="点赞" CommandName="Good" CommandArgument='<%#Eval("id") %>' ></asp:LinkButton></td>
                    <td><asp:LinkButton ID="lbcover" runat="server" Text="设为封面" CommandName="Cover" CommandArgument='<%#Eval("id") %>'></asp:LinkButton></td>
                    <td><asp:LinkButton ID="lbtDelete" runat="server" Text="删除" CommandName="Delete" CommandArgument='<%#Eval("id") %>' ></asp:LinkButton></td>
                </tr>

            </ItemTemplate>

            <FooterTemplate>
               </table>

            </FooterTemplate>
     

        </asp:Repeater>
        <br />

        <asp:Button ID="btnUp" runat="server" Text="上一页" OnClick="btnUp_Click" />
        <asp:Button ID="btnDown" runat="server" Text="下一页"  OnClick="btnDown_Click"/>
        <asp:Button ID="btnFirst" runat="server" Text="首页" OnClick="btnFirst_Click" />
        <asp:Button ID="btnLast" runat="server" Text="尾页"  OnClick="btnLast_Click"/>
        页次：<asp:Label ID="lbNow" runat="server" Text="1"></asp:Label>
        /<asp:Label ID="lbTotal" runat="server" Text="1"></asp:Label>
        转<asp:TextBox ID="txtJump" Text="1" runat="server" Width="16px" onkeyup="this.value=this.value.replace(/\D/g,'')"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat ="server" ControlToValidate ="txtJump" ></asp:RequiredFieldValidator> 
        <asp:Button ID="btnJump" runat="server" Text="Go"  OnClick="btnJump_Click"/>
         <asp:Button ID="btnback" runat="server" Text="返回" PostBackUrl="~/Photo.aspx" />
</asp:Content>

