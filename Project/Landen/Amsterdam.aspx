<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="Amsterdam.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="banner" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="inhoud" runat="Server">

    <h1 class="LandHead">Amsterdam</h1>
    <div class="LandTemp">
        <asp:Label ID="lblTemp" runat="server" Text="Label"></asp:Label>
    </div>
    <div class="LandInfo">

    </div>
    <div class="LandHotels">
        <div class="hotel1">
            <asp:Label ID="lblHotel1Naam" runat="server" Text="[HotelNaam]"></asp:Label>
            <asp:Image ID="imgHotel1" runat="server" />
            <asp:Label ID="lblHotel1Beschrijving" runat="server" Text="[HotelBeschrijving]"></asp:Label>
            <asp:LinkButton ID="lblHotel1URL" runat="server">[HotelURL]</asp:LinkButton>
            <asp:Label ID="lblHotel1Prijs" runat="server" Text="Label"></asp:Label>
        </div>
        <div class="hotel2">
            <asp:Label ID="lblHotel2Naam" runat="server" Text="[HotelNaam]"></asp:Label>
            <asp:Image ID="imgHotel2" runat="server" />
            <asp:Label ID="lblHotel2Beschrijving" runat="server" Text="[HotelBeschrijving]"></asp:Label>
            <asp:LinkButton ID="lblHotel2URL" runat="server">[HotelURL]</asp:LinkButton>
            <asp:Label ID="lblHotel2Prijs" runat="server" Text="Label"></asp:Label>
        </div>
        <div class="hotel3">
            <asp:Label ID="lblHotel3Naam" runat="server" Text="[HotelNaam]"></asp:Label>
            <asp:Image ID="imgHotel3" runat="server" />
            <asp:Label ID="lblHotel3Beschrijving" runat="server" Text="[HotelBeschrijving]"></asp:Label>
            <asp:LinkButton ID="lblHotel3URL" runat="server">[HotelURL]</asp:LinkButton>
            <asp:Label ID="lblHotel3Prijs" runat="server" Text="Label"></asp:Label>
        </div>
    </div>


</asp:Content>

