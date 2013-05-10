<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="Trein.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="banner" runat="Server">
    <div class="slider-wrapper theme-dark">
        <div id="slider" class="nivoSlider">
            <a href="#">
                <img src="Banner/img_algemeen/trein1.png" alt="" /></a>
            <a href="#">
                <img src="Banner/img_algemeen/trein2.png" alt="" /></a>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="inhoud" runat="Server">
    <div class="container">
        <a href="javascript:zoek()" id="btnZoekFunc" role="button" class="btn btn-primary">Zoek reis</a>
        <div id="zoek" class="zoek">
            <br />
            <strong>
                <asp:Label ID="Label1" runat="server" Text="Vertrekplaats: "></asp:Label></strong>
            <asp:DropDownList ID="drpVertrek" runat="server" CssClass="btn dropdown-toggle"></asp:DropDownList>

            <strong>
                <asp:Label ID="Label2" runat="server" Text="Bestemming: "></asp:Label></strong>
            <asp:DropDownList ID="drpAankomst" runat="server" CssClass="btn dropdown-toggle"></asp:DropDownList>
            <br />
            <br />

            <asp:Button ID="btnZoek" runat="server" Text="Zoek" CssClass="btn btn-primary" OnClick="btnZoek_Click" />

        </div>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <asp:GridView ID="GridTrein" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" OnSelectedIndexChanged="GridTrein_SelectedIndexChanged">
            <columns>
            <asp:CommandField SelectText="Bestel" ControlStyle-CssClass="btn btn-danger" ShowSelectButton="True" >
<ControlStyle CssClass="btn btn-danger"></ControlStyle>
                </asp:CommandField>
            <asp:BoundField DataField="ID" HeaderText="Reisnr." />
            <asp:BoundField DataField="vertrekID" HeaderText="Vertrekplaats" />
            <asp:BoundField DataField="aankomstID" HeaderText="Bestemming" />
            <asp:BoundField DataField="Prijs" HeaderText="Prijs/pers." />
        </columns>
        </asp:GridView>
        </ContentTemplate>

        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnZoek" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <input id="hdFilter" type="hidden" value="0" runat="server"/>
</asp:Content>

