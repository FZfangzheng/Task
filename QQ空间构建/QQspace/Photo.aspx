<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Photo.aspx.cs" Inherits="Photo2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Button ID="creatphoto" runat="server" OnClick="creatphoto_Click" Text="创建相册" />
    <asp:Panel ID="pn_creatphoto" runat="server" Visible="false" >
       相册名称： <asp:TextBox ID="photoname" runat="server" ></asp:TextBox><br />
        <asp:Button ID="yes" runat="server" Text ="确定" OnClick="yes_Click" /><br />
        <asp:Button ID="no" runat="server" Text="取消" OnClick ="no_Click" />
    </asp:Panel>
   
    <asp:Repeater ID="Rptphoto" runat="server" OnItemCommand="Rptphoto_ItemCommand" >  
            <HeaderTemplate> 
                <table>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label ID="photoname" runat="server" Text='<%# Eval("photoname") %>'></asp:Label><br />
                        <asp:ImageButton ID="photo" runat="server" Width ="100" Height="100" ImageUrl='<%#Eval("cover") %>' CommandName="Photo" CommandArgument='<%#Eval("photoname") %>' />
                    </td>
                    <td><asp:LinkButton ID="lbtDelete" runat="server" Text="删除" CommandName="Delete" CommandArgument='<%#Eval("photoname") %>' ></asp:LinkButton></td>
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
         <asp:Button ID="btnback" runat="server" Text="返回" PostBackUrl="~/Personal_center.aspx" />
        
</asp:Content>

