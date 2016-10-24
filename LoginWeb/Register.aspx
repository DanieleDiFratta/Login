<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="LoginWeb.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Table ID="Table1" runat="server" Height="115px" Width="343px">
        <asp:TableRow>
            <asp:TableCell>
    Username
            </asp:TableCell>
            <asp:TableCell>
                <input id="usernameInputText" type="text" required ="required" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
    Email
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="emailInputText" AutoCompleteType ="Email"  ValidateRequestMode="Enabled" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
    Password
            </asp:TableCell>
            <asp:TableCell>
                <input id="passwordInputText" type="password" required ="required" runat="server"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
    Conferma Password
            </asp:TableCell>
            <asp:TableCell>
                <input id="confermaPasswordInputText" type="password" required ="required" runat="server"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <asp:Label ID="errorLabel" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Conferma" OnClick="Button1_Click" />
</asp:Content>
