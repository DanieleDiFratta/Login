<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddSecondo.aspx.cs" Inherits="LoginWeb.AddSecondo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="successLabel" runat="server" ForeColor="Red" Text="Piatto inserito correttamente" Visible="False"></asp:Label>
        <asp:table runat="server" Height="127px" Width="479px" CssClass="auto-style1">
            <asp:tablerow>
                <asp:tablecell>
                    <label>Nome:</label>
                </asp:tablecell>
                <asp:tablecell>
                    <asp:TextBox ID="nomebox" runat="server" required="true">
                    </asp:TextBox>
                </asp:tablecell>
            </asp:tablerow>
            <asp:tablerow>
                <asp:tablecell>
                    <label>Prezzo:</label>
                </asp:tablecell>
                <asp:tablecell>
                    <asp:TextBox ID="prezzobox" runat="server" required="true"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RangeValidator ID="RangeValidator1" forecolor="red" controltovalidate="prezzobox" runat="server" ErrorMessage="Inserire un prezzo" type="double"></asp:RangeValidator>
                </asp:tablecell>
            </asp:tablerow>
        </asp:table>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Aggiungi" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Indietro</asp:HyperLink>
    </div>
</asp:Content>
