<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="BoekReis.aspx.cs" Inherits="BoekReis" %>


<asp:Content ID="Content1" ContentPlaceHolderID="banner" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="inhoud" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <script src="JS/Profiel.js"></script>

            <div id="zoek" class="zoek">
                <asp:Label ID="Label4" runat="server" Text="U heeft gekozen vor reis: "></asp:Label>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

            

                <br />
                <strong>
                    <asp:Label ID="Label2" runat="server" Text="Dag: "></asp:Label>
                </strong>


                <asp:TextBox ID="txtDate" runat="server" />


                <br />
                <strong>
                    <asp:Label ID="Label3" runat="server" Text="Vertrekuur: "></asp:Label></strong>
                <asp:DropDownList ID="drpUur" runat="server" CssClass="btn dropdown-toggle" OnSelectedIndexChanged="drpUur_SelectedIndexChanged"></asp:DropDownList>
                <br />
                <br />

                <asp:Button ID="btnZoek" runat="server" Text="Zoek" CssClass="btn btn-primary" OnClick="btnZoek_Click" />

            </div>
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

                <div id="namen" runat="server">
                    
                </div>

                <asp:Button ID="btnMand" runat="server" Text="Zet in winkelmandje" CssClass="btn btn-primary" OnClick="btnMand_Click"  Visible ="false" ValidationGroup="namen"/>
            </div>

            
        </ContentTemplate>
    </asp:UpdatePanel>
    <input id="hdValCal" type="hidden" value="0" />
</asp:Content>

