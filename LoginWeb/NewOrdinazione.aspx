<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NewOrdinazione.aspx.cs" Inherits="LoginWeb.NewOrdinazione" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
Seleziona tavolo:&nbsp; <asp:RadioButtonList ID="RadioButtonList1" runat="server" DataSourceID="SqlDataSource1" required="true" DataTextField="numero" DataValueField="numero" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
    </asp:RadioButtonList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RistoranteConnectionString %>" SelectCommand="SELECT [numero] FROM [Tavolo] ORDER BY [numero]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RistoranteConnectionString %>"></asp:SqlDataSource>
    <br />
    <br />
    <asp:Table ID="Table1" runat="server">
    </asp:Table>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Aggiungi al tavolo" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Selezionare un tavolo" ControlToValidate="RadioButtonList1" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource2" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    <br />
    <br />
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Cancella Piatto" Visible="False" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="DropDownList1" runat="server" Visible="False">
    </asp:DropDownList>
    <br />
    <br />
    </asp:Content>
