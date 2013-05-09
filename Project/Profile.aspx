﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="banner" runat="Server">
    <link href="CSS/Profiel.css" rel="stylesheet" />
    <script src="JS/Profiel.js"></script>
    <script src="JS/jExpand.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="inhoud" runat="Server">
    <div class="btn-group center">
        <button class="btn active" id="btnProfiel" onclick="return false;">Profiel</button>
        <button class="btn" id="btnHistoriek" onclick="return false;">Historiek</button>
        <button class="btn" id="btnRitten" onclick="return false;">Geplande Ritten</button>
    </div>
    <div id="Profiel">
        <div class="links">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Gebruikersnaam:"></asp:Label></td>
                    <td>
                        <asp:Label ID="lblGebruiker" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Passwoord:"></asp:Label></td>
                    <td><a href="#" id="pop">Passwoord wijzigen</a></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Voornaam:"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtVoornaam" runat="server" Width="213px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Familienaam:"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtNaam" runat="server" Width="213px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Email:"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" Width="213px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="Straat + Huisnr:"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtStraat" runat="server" Width="170px"></asp:TextBox><asp:TextBox ID="txtHuisnr" runat="server" Width="30px"></asp:TextBox></td>
                </tr>
                <tr>

                    <td>
                        <asp:Label ID="Label9" runat="server" Text="Postcode + Gemeente:"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtPostcode" runat="server" Width="80px"></asp:TextBox><asp:TextBox ID="txtGemeente" runat="server" Width="120px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnOpslaan" runat="server" Text="Wijzigingen Opslaan" OnClick="btnOpslaan_Click" /></td>
                </tr>

            </table>
        </div>
        <div class="rechts" id="popshow">
            <div class="popover fade right in" style="top: 5.5px; left: 41%; display: block;">
                <div class="arrow">
                </div>
                <h3 class="popover-title">Change Passwoord</h3>
                <div class="popover-content">
                    <asp:ChangePassword ID="cngPass" runat="server"></asp:ChangePassword>

                </div>

            </div>
        </div>
    </div>
    <div id="Historiek">
        <asp:Repeater ID="rptRepeater" runat="server" DataSourceID="SqlDataSource1">
            <HeaderTemplate>
                <table id="report">
                    <tr class="header">
                        <td><b>Datum</b></td>
                        <td><b>Verstrekpunt</b></td>
                        <td><b>Aankomstpunt</b></td>
                        <td><b>Betaald</b></td>
                        <td><b></b></td>

                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="odd">
                    <td><%# Eval("Datum") %></td>
                    <td><%# Eval("Vertrek") %></td>
                    <td><%# Eval("Aankomst") %></td>
                    <td><%# Eval("Betaald") %></td>
                    <td>
                        <div class="arrow"></div>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <h4>Details:</h4>
                        <ul>
                            <li>test</li>
                            <li>test</li>
                            <li>test</li>

                        </ul>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr>
                    <td bgcolor="#DDD"><%# Eval("Datum") %></td>
                    <td bgcolor="#DDD"><%# Eval("Vertrek") %></td>
                    <td bgcolor="#DDD"><%# Eval("Aankomst") %></td>
                    <td bgcolor="#DDD"><%# Eval("Betaald") %></td>
                </tr>
                <tr>
                    <td colspan="5">
                        <h4>Details:</h4>
                        <ul>
                            <li>test</li>
                            <li>test</li>
                            <li>test</li>

                        </ul>
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <FooterTemplate>
                <tr>
                    <td colspan="5" style="text-align: center;">- Einde van de lijst -</td>
                </tr>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DB_99C675_VPRTravelConnectionString %>" SelectCommand="SELECT tblTicket.vertrekDatum AS Datum, tblTrein.vertrekID AS Vertrek, tblTrein.aankomstID AS Aankomst, tblTrein.prijs AS Betaald FROM tblTicket INNER JOIN tblTrein ON tblTicket.treinID = tblTrein.ID INNER JOIN tblGebruikers ON tblTicket.gebruikerID = tblGebruikers.ID WHERE (tblGebruikers.ID = @gebruikersid) and (tblTicket.vertrekDatum &lt; CURRENT_TIMESTAMP) ORDER BY Datum
       ">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="-1" Name="gebruikersid" SessionField="VPR_id" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    <div id="Ritten">
        <asp:GridView ID="grdRitten" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
            <Columns>

                <asp:BoundField DataField="Datum" HeaderText="Datum" />
                <asp:BoundField DataField="Vertrek" HeaderText="Vertrek" />
                <asp:BoundField DataField="Aankomst" HeaderText="Aankomst" />
                <asp:BoundField DataField="Betaald" HeaderText=" Totale Prijs" />
                <asp:CommandField SelectText="Annuleer" ControlStyle-CssClass="btn btn-danger" ShowSelectButton="True">
                    <ControlStyle CssClass="btn btn-danger"></ControlStyle>
                </asp:CommandField>
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>

