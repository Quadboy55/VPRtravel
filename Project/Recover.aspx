<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="Recover.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="inhoud" Runat="Server">
    <h1>Wachtwoord recovery</h1>

    <h4>Geef uw gebruikersnaam in:</h4>
    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><br />
    <asp:Button ID="btnSend" runat="server" Text="Verstuur Nieuw Wachtwoord" OnClick="btnSend_Click" />
    <br />
    <br />
    <asp:Label ID="lblStatus" CssClass="error" runat="server"></asp:Label>
    <br />
</asp:Content>

