<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="winkelkarretje.aspx.cs" Inherits="winkelkarretje" %>

<asp:Content ID="Content1" ContentPlaceHolderID="banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="inhoud" Runat="Server">
    <br />
    <asp:Label ID="lblLeeg" Visible ="false" runat="server" Text=""></asp:Label>
    <asp:GridView ID="grdReizen" CssClass="table table-striped" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="grdReizen_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="vertrekdatum" HeaderText="Vertrektijd" />
            <asp:BoundField DataField="vertrekplaats" HeaderText="Vertrekplaats" />
            <asp:BoundField DataField="aankomstdatum" HeaderText="Aankomsttijd" />
            <asp:BoundField DataField="aankomstplaats" HeaderText="Aankomstplaats" />
            <asp:BoundField DataField="typeID" HeaderText="Class" />
            <asp:BoundField DataField="totalePrijs" HeaderText="Totale prijs" />
            <asp:CommandField SelectText="Annuleer" ControlStyle-CssClass="btn btn-danger" ShowSelectButton="True" >
<ControlStyle CssClass="btn btn-danger"></ControlStyle>
                </asp:CommandField>
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="btnBoekNog" CssClass="btn btn-primary" runat="server" Text="Nog een reservatie toevoegen." OnClick="btnBoekNog_Click" />
    <asp:Button ID="btnBevestig" CssClass="btn btn-success" runat="server" Text="Bevestig uw bestelling" OnClick="btnBevestig_Click" />
    
</asp:Content>

