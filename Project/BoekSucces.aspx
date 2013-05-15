<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="BoekSucces.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="inhoud" Runat="Server">
    <h2> Uw boeking is geslaagd </h2>

    <strong>
        <asp:Label ID="lblReis" runat="server" Text=""></asp:Label>
    </strong>
    <br />
    <asp:GridView ID="grdRitten" runat="server"  CssClass="table table-striped" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="Treinnr." />
            <asp:BoundField DataField="vertrekID" HeaderText="VertrekPlaats" />
            <asp:BoundField DataField="aankomstID" HeaderText="Aankomstplaats" />
            <asp:BoundField DataField="prijs" HeaderText="Prijs/pers." />
            <asp:BoundField DataField="Duur" HeaderText="Duur" />
            <asp:BoundField DataField="vertrekUur" HeaderText="Vertrek uur" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:GridView ID="grdPersonen" runat="server" AutoGenerateColumns="False"  CssClass="table table-striped">
        <Columns>
            <asp:BoundField DataField="voornaam" HeaderText="Voornaam" />
            <asp:BoundField DataField="naam" HeaderText="Naam" />
            <asp:BoundField DataField="stoelnr" HeaderText="Stoelnummers" />
        </Columns>
</asp:GridView>
    
</asp:Content>

