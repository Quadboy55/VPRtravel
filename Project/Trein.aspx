﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="Trein.aspx.cs" Inherits="_Default" %>

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
        <asp:Button ID="btnZoekFunc" runat="server" Text="Zoeken naar reis" CssClass="btn btn-primary" OnClick="btnZoekFunc_Click"/>
        
        <div id="zoek" runat="server" class="zoek">
            <br />
            <strong><asp:Label ID="Label1" runat="server" Text="Vertrekplaats: "></asp:Label></strong>
            <asp:DropDownList ID="drpVertrek" runat="server" CssClass="btn dropdown-toggle"></asp:DropDownList>    

            <strong><asp:Label ID="Label2" runat="server" Text="Bestemming: "></asp:Label></strong>
                <asp:DropDownList ID="drpAankomst" runat="server" CssClass="btn dropdown-toggle"></asp:DropDownList>  <br /> <br />
               
            <asp:Button ID="btnZoek" runat="server" Text="Zoek" CssClass="btn btn-primary" OnClick="btnZoek_Click"/>
         
         </div>
    </div>

    <asp:GridView ID="GridTrein" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="Reisnr." />
            <asp:BoundField DataField="vertrekID" HeaderText="Vertrekplaats" />
            <asp:BoundField DataField="aankomstID" HeaderText="Bestemming" />
            <asp:BoundField DataField="typeID" HeaderText="Type" />
            <asp:BoundField DataField="capaciteit" HeaderText="Aantal plaatsen" />
            <asp:BoundField DataField="prijs" HeaderText="Prijs/pers." />
        </Columns>
    </asp:GridView>

</asp:Content>

