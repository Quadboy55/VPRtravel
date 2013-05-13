<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="winkelkarretje.aspx.cs" Inherits="winkelkarretje" %>

<asp:Content ID="Content1" ContentPlaceHolderID="banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="inhoud" Runat="Server">
    <br />
    <asp:Label ID="lblLeeg" Visible ="false" runat="server" Text=""></asp:Label>
    <asp:GridView ID="grdReizen" CssClass="table table-striped" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="vertrekdatum" HeaderText="Vertrektijd" />
            <asp:BoundField DataField="vertrekplaats" HeaderText="Vertrekplaats" />
            <asp:BoundField DataField="aankomstdatum" HeaderText="Aankomsttijd" />
            <asp:BoundField DataField="aankomstplaats" HeaderText="Aankomstplaats" />
            <asp:BoundField DataField="typeID" HeaderText="Class" />
            <asp:BoundField DataField="totalePrijs" HeaderText="Totale prijs" />
            <asp:ButtonField Text="Details" ControlStyle-CssClass="btn btn-info" />
            <asp:ButtonField Text="Annuleer" ControlStyle-CssClass="btn btn-danger">
<ControlStyle CssClass="btn btn-danger"></ControlStyle>
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="btnBevestig" CssClass="btn btn-primary" runat="server" Text="Bevestig uw bestelling" OnClick="btnBevestig_Click" />

</asp:Content>

