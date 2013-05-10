<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="BoekReis.aspx.cs" Inherits="BoekReis" %>


<asp:Content ID="Content1" ContentPlaceHolderID="banner" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="inhoud" runat="Server">

    <script src="JS/Profiel.js"></script>

    <div id="zoek" class="zoek">
        <asp:Label ID="Label4" runat="server" Text="U heeft gekozen vor reis: "></asp:Label>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>



        <br />
        <strong>
            <asp:Label ID="Label2" runat="server" Text="Dag: "></asp:Label>
        </strong>

        <asp:Calendar ID="CalDate" runat="server"></asp:Calendar>

        <br />
        <strong>
            <asp:Label ID="Label3" runat="server" Text="Vertrekuur: "></asp:Label></strong>
        <asp:DropDownList ID="drpUur" runat="server" CssClass="btn dropdown-toggle"></asp:DropDownList>
        <br />
        <br />

        <asp:Button ID="btnZoek" runat="server" Text="Zoek" CssClass="btn btn-primary" OnClick="btnZoek_Click" />

    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="grdRitten" CssClass="table table-striped" runat="server" Visible="False" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="vertrekUur" HeaderText="Vertrektijd" />
                    <asp:BoundField HeaderText="Aankomsttijd" />
                    <asp:BoundField DataField="vertrekID" HeaderText="Vertrekplaats" />
                    <asp:BoundField DataField="AankomstID" HeaderText="Aankomstplaats" />
                </Columns>
            </asp:GridView>

            <div id="atlTickets" class="zoek" runat="server" visible="false">


                        <strong>
                            <asp:Label ID="Label6" runat="server" Text="Aantal Personen: "></asp:Label>
                        </strong>
                        <asp:DropDownList ID="drpClass" runat="server" AutoPostBack="True">
                        </asp:DropDownList>
                     
                        <strong>
                            <asp:Label ID="Label5" runat="server" Text="Aantal Personen: "></asp:Label>
                        </strong>
                        <asp:DropDownList ID="drpPersonen" runat="server" Height="32px" Width="120px" OnSelectedIndexChanged="drpPersonen_SelectedIndexChanged" AutoPostBack="True">

                            <asp:ListItem>--Aantal--</asp:ListItem>

                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem> 
                            <asp:ListItem>10</asp:ListItem>

                        </asp:DropDownList>
                        <asp:CustomValidator ID="valPers" runat="server" ValidationGroup="namen" ErrorMessage="Kies het aantal reizigers" ControlToValidate="drpPersonen" OnServerValidate="valPers_ServerValidate"></asp:CustomValidator>
                   

                <asp:Panel ID="p1" runat="server" Visible="false">
                    <strong>
                        <asp:Label ID="Label9" runat="server" Text="Reiziger 1: "></asp:Label><br />
                    </strong>
                    <asp:Label ID="Label7" runat="server" Text="Naam: "></asp:Label>
                    <asp:TextBox ID="txtnaam1" runat="server"></asp:TextBox>
                    <asp:Label ID="Label8" runat="server" Text="Voornaam: "></asp:Label>
                    <asp:TextBox ID="txtvrnaam1" runat="server"></asp:TextBox>
                </asp:Panel>
                <asp:Panel ID="p2" runat="server" Visible="false">
                    <strong>
                        <asp:Label ID="Label13" runat="server" Text="Reiziger 2: "></asp:Label><br />
                    </strong>
                    <asp:Label ID="Label14" runat="server" Text="Naam: "></asp:Label>
                    <asp:TextBox ID="txtnaam2" runat="server"></asp:TextBox>
                    <asp:Label ID="Label15" runat="server" Text="Voornaam: "></asp:Label>
                    <asp:TextBox ID="txtvrnaam2" runat="server"></asp:TextBox>
                </asp:Panel>
                <asp:Panel ID="p3" runat="server" Visible="false">
                    <strong>
                        <asp:Label ID="Label16" runat="server" Text="Reiziger 3: "></asp:Label><br />
                    </strong>
                    <asp:Label ID="Label17" runat="server" Text="Naam: "></asp:Label>
                    <asp:TextBox ID="txtnaam3" runat="server"></asp:TextBox>
                    <asp:Label ID="Label18" runat="server" Text="Voornaam: "></asp:Label>
                    <asp:TextBox ID="txtvrnaam3" runat="server"></asp:TextBox>
                </asp:Panel>
                <asp:Panel ID="p4" runat="server" Visible="false">
                    <strong>
                        <asp:Label ID="Label19" runat="server" Text="Reiziger 4: "></asp:Label><br />
                    </strong>
                    <asp:Label ID="Label20" runat="server" Text="Naam: "></asp:Label>
                    <asp:TextBox ID="txtnaam4" runat="server"></asp:TextBox>
                    <asp:Label ID="Label21" runat="server" Text="Voornaam: "></asp:Label>
                    <asp:TextBox ID="txtvrnaam4" runat="server"></asp:TextBox>
                </asp:Panel>
                <asp:Panel ID="p5" runat="server" Visible="false">
                    <strong>
                        <asp:Label ID="Label22" runat="server" Text="Reiziger 5: "></asp:Label><br />
                    </strong>
                    <asp:Label ID="Label23" runat="server" Text="Naam: "></asp:Label>
                    <asp:TextBox ID="txtnaam5" runat="server"></asp:TextBox>
                    <asp:Label ID="Label24" runat="server" Text="Voornaam: "></asp:Label>
                    <asp:TextBox ID="txtvrnaam5" runat="server"></asp:TextBox>
                </asp:Panel>
                <asp:Panel ID="p6" runat="server" Visible="false">
                    <strong>
                        <asp:Label ID="Label25" runat="server" Text="Reiziger 6: "></asp:Label><br />
                    </strong>
                    <asp:Label ID="Label26" runat="server" Text="Naam: "></asp:Label>
                    <asp:TextBox ID="txtnaam6" runat="server"></asp:TextBox>
                    <asp:Label ID="Label27" runat="server" Text="Voornaam: "></asp:Label>
                    <asp:TextBox ID="txtvrnaam6" runat="server"></asp:TextBox>
                </asp:Panel>
                <asp:Panel ID="p7" runat="server" Visible="false">
                    <strong>
                        <asp:Label ID="Label28" runat="server" Text="Reiziger 7: "></asp:Label><br />
                    </strong>
                    <asp:Label ID="Label29" runat="server" Text="Naam: "></asp:Label>
                    <asp:TextBox ID="txtnaam7" runat="server"></asp:TextBox>
                    <asp:Label ID="Label30" runat="server" Text="Voornaam: "></asp:Label>
                    <asp:TextBox ID="txtvrnaam7" runat="server"></asp:TextBox>
                </asp:Panel>
                <asp:Panel ID="p8" runat="server" Visible="false">
                    <strong>
                        <asp:Label ID="Label31" runat="server" Text="Reiziger 8: "></asp:Label><br />
                    </strong>
                    <asp:Label ID="Label32" runat="server" Text="Naam: "></asp:Label>
                    <asp:TextBox ID="txtnaam8" runat="server"></asp:TextBox>
                    <asp:Label ID="Label33" runat="server" Text="Voornaam: "></asp:Label>
                    <asp:TextBox ID="txtvrnaam8" runat="server"></asp:TextBox>
                </asp:Panel>
                <asp:Panel ID="p9" runat="server" Visible="false">
                    <strong>
                        <asp:Label ID="Label34" runat="server" Text="Reiziger 9: "></asp:Label><br />
                    </strong>
                    <asp:Label ID="Label35" runat="server" Text="Naam: "></asp:Label>
                    <asp:TextBox ID="txtnaam9" runat="server"></asp:TextBox>
                    <asp:Label ID="Label36" runat="server" Text="Voornaam: "></asp:Label>
                    <asp:TextBox ID="txtvrnaam9" runat="server"></asp:TextBox>
                </asp:Panel>
                <asp:Panel ID="p10" runat="server" Visible="false">
                    <strong>
                        <asp:Label ID="Label37" runat="server" Text="Reiziger 10: "></asp:Label><br />
                    </strong>
                    <asp:Label ID="Label38" runat="server" Text="Naam: "></asp:Label>
                    <asp:TextBox ID="txtnaam10" runat="server"></asp:TextBox>
                    <asp:Label ID="Label39" runat="server" Text="Voornaam: "></asp:Label>
                    <asp:TextBox ID="txtvrnaam10" runat="server"></asp:TextBox>
                </asp:Panel>

                <asp:Button ID="btnMand" runat="server" Text="Zet in winkelmandje" CssClass="btn btn-primary" OnClick="btnMand_Click" Visible="false" ValidationGroup="namen" />
            </div>


        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnZoek" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <input id="hdValCal" type="hidden" value="0" />
</asp:Content>

