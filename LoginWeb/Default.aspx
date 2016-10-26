<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LoginWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 125px">
        Ciao,
        <asp:LoginName ID="LoginName1" runat="server" />
        <br />
        <br />
        <asp:Menu ID="Menu1" runat="server" BackColor="#FFFBD6" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" StaticSubMenuIndent="10px">
            <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <DynamicMenuStyle BackColor="#FFFBD6" />
            <DynamicSelectedStyle BackColor="#FFCC66" />
            <Items>
                <asp:MenuItem Text="Aggiungi" Value="Aggiungi">
                    <asp:MenuItem NavigateUrl="~/AddPrimo.aspx" Text="Primo" Value="Primo"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/AddSecondo.aspx" Text="Secondo" Value="Secondo"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/AddBibita.aspx" Text="Bibita" Value="Bibita"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Home/Menu.aspx" Text="Menù del giorno" Value="Menù del giorno"></asp:MenuItem>
            </Items>
            <StaticHoverStyle BackColor="#990000" ForeColor="White" />
            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <StaticSelectedStyle BackColor="#FFCC66" />
        </asp:Menu>
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ChangePassword.aspx">Cambia Password</asp:HyperLink>
        </div>
</asp:Content>
