<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="BoekReis.aspx.cs" Inherits="BoekReis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="banner" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="inhoud" runat="Server">
    <p>u heeft gekozen voor reis:</p>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

    <div id="zoek" class="zoek">
        <asp:RadioButtonList ID="radList" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Selected="False">Vertreken</asp:ListItem>
            <asp:ListItem>Aankomen</asp:ListItem>
        </asp:RadioButtonList>
        <strong>
            <asp:Label ID="Label2" runat="server" Text="Dag: "></asp:Label></strong>
        <asp:DropDownList ID="drpDag" runat="server" CssClass="btn dropdown-toggle"></asp:DropDownList>

        <strong>
            <asp:Label ID="Label3" runat="server" Text="Tijdstip: "></asp:Label></strong>
        <asp:DropDownList ID="drpAankomst" runat="server" CssClass="btn dropdown-toggle"></asp:DropDownList>
        <br />
        <br />

        <asp:Button ID="btnZoek" runat="server" Text="Zoek" CssClass="btn btn-primary" />

    </div>
</asp:Content>

