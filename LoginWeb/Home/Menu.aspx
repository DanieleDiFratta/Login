<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="LoginWeb.Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table ID="Table1" runat="server" GridLines="Both" Height="98px" Width="191px">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="nomePrimo" runat="server" Text="Primo"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="prezzoPrimo" runat="server" Text="Prezzo"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="nomeSecondo" runat="server" Text="Secondo"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="prezzoSecondo" runat="server" Text="Prezzo"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="nomeBibita" runat="server" Text="Bibita"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="prezzoBibita" runat="server" Text="Prezzo"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    Ad un incredibile prezzo di:
    <br />
&nbsp;&nbsp;&nbsp; €
    <asp:Label ID="totaleLabel" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">« Indietro</asp:HyperLink>
</asp:Content>
